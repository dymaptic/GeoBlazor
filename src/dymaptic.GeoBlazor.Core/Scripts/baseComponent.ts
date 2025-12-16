import {Field, Type } from "protobufjs";
import {
    hasValue,
    loadProtobuf,
    protobufRoot,
    ProtoTypes,
    updateGeometryForProtobuf,
    updateGraphicForProtobuf, updateSymbolForProtobuf
} from "./arcGisJsInterop";
import {buildEncodedJson} from "./geoBlazorCore";
import {IPropertyWrapper} from "./definitions";

// base class for components that need to invoke methods with serialized parameters
export default class BaseComponent implements IPropertyWrapper {
    component: any;
    
    constructor(component: any) {
        this.component = component;
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
    getProperty(prop: string) {
        return this.component[prop];
    }
    unwrap() {
        return this.component;
    }
    
    async invokeSerializedMethod(methodName: string, useStreams: boolean, returnAsProtobuf: boolean, 
                                 protoReturnType: string, ...parameters: any[]): Promise<any> {
        loadProtobuf();
        let methodParams: any[] = [];
        for (let i = 0; i < parameters.length; i += 2) {
            let paramType = parameters[i];
            let paramValue = parameters[i + 1];
            methodParams.push(await this.parseParameter(paramType, paramValue, useStreams));
        }

        let result = this[methodName](...methodParams);
        if (result instanceof Error) {
            throw result;
        }
        if (result instanceof Promise) {
            result = await result;
        }
        
        if (result instanceof ArrayBuffer || result instanceof Uint8Array) {
            return result;
        }
        
        if (returnAsProtobuf) {
            return this.serializeProtobufReturnValue(result, protoReturnType);
        }

        if (useStreams) {
            return buildEncodedJson(result);
        }

        return result;
    }

    async invokeVoidSerializedMethod(methodName: string, useStreams: boolean, ...parameters: any[]): Promise<void> {
        loadProtobuf();
        let methodParams: any[] = [];
        for (let i = 0; i < parameters.length; i += 2) {
            let paramType = parameters[i];
            let paramValue = parameters[i + 1];
            methodParams.push(await this.parseParameter(paramType, paramValue, useStreams));
        }

        await this[methodName](...methodParams);
    }

    async parseParameter(paramType: string, paramValue: any, useStreams: boolean): Promise<any> {
        if (!hasValue(paramValue)) {
            return null;
        }

        if (paramType === 'JsObject') {
            // don't parse JsObjectReferences
            return paramValue;
        }

        if (Array.isArray(paramValue)) {
            let arrayValues: any[] = [];
            for (let i = 0; i < paramValue.length; i++) {
                let itemValue = paramValue[i];
                let parsedItem = await this.parseParameter(paramType, itemValue, useStreams);
                arrayValues.push(parsedItem);
            }
            return arrayValues;
        }

        let isArrayType = false;
        if (paramType.endsWith('Collection')) {
            isArrayType = true;
            paramType = paramType.replace("Collection", "");
        }

        // server is sending a stream, could be a protobuf or json stream
        if (useStreams && paramValue.hasOwnProperty('_streamPromise')) {
            return await this.parseDotNetStream(paramType, paramValue, isArrayType);
        }

        // server is sending a byte array, should be protobuf, but falls back to json for unknown types
        if (paramValue instanceof Uint8Array) {
            return this.parseDotNetUint8Array(paramType, paramValue, isArrayType);
        }

        if (!isArrayType && this.simpleDotNetTypes.includes(paramType.toLowerCase())) {
            // don't convert simple types, but trim quotes
            if (typeof paramValue === 'string') {
                return paramValue.replace(/^"(.*)"$/, "$1");
            }
            return paramValue;
        }

        // server is sending a string of a non-simple type, should be json
        return this.parseDotNetJson(paramValue);
    }

    async parseDotNetStream(typeName: string, streamRef: any, isArrayType: boolean): Promise<any> {
        let arrayBuffer: ArrayBuffer = await streamRef.arrayBuffer();
        let uint8 = new Uint8Array(arrayBuffer);

        return this.parseDotNetUint8Array(typeName, uint8, isArrayType);
    }

    parseDotNetUint8Array(typeName: string, uint8: Uint8Array, isArrayType: boolean): any {
        if (Object.hasOwn(ProtoTypes, typeName)) {
            try {
                const protoType = ProtoTypes[typeName];
                
                if (isArrayType) {
                    let collectionType = `${typeName}Collection`;
                    let ProtoCollectionType: any = ProtoTypes[collectionType];
                    if (!ProtoCollectionType) {
                        // create missing protobuf type for array of this type
                        ProtoCollectionType = new Type(collectionType)
                            .add(new Field('items', 1, protoType.name, 'repeated'));
                        ProtoTypes[collectionType] = ProtoCollectionType;
                        protobufRoot.nested.dymaptic.GeoBlazor.Core.add(ProtoCollectionType)
                    }

                    const decodedCollection = ProtoCollectionType.decode(uint8);
                    let parsedCollection = ProtoCollectionType.toObject(decodedCollection, {
                        defaults: false,
                        enums: String,
                        longs: String,
                        arrays: true,
                        objects: false
                    });

                    let resultArray: any[] = [];
                    for (let i = 0; i < parsedCollection.items.length; i++) {
                        let itemValue = parsedCollection.items[i];
                        resultArray.push(itemValue);
                    }
                    return resultArray;
                }
            
                const decoded = protoType.decode(uint8);
                return protoType.toObject(decoded, {
                    defaults: false,
                    enums: String,
                    longs: String,
                    arrays: false,
                    objects: false
                });
            } catch (e) {
                console.error(e);
                return null;
            }
        }

        // Fallback to JSON parsing for simple types
        let decoder = new TextDecoder();
        let text = decoder.decode(uint8);
        return this.parseDotNetJson(text);
    }

    parseDotNetJson(text: string): any {
        try {
            // valid JSON must start with { or [
            if (text[0] === '{' || text[0] === '[') {
                if (!hasValue(text)) {
                    return null;
                }

                return JSON.parse(text);
            }

            if (text[0] === '"') {
                // trim off leading and trailing quotes
                return text.replace(/^"(.*)"$/, "$1");
            }

            return text;
        } catch (e) {
            console.error(e);
            return null;
        }
    }
    
    serializeProtobufReturnValue(returnValue: any, protoReturnType: string): Uint8Array {
        if (!hasValue(returnValue)) {
            returnValue = {
                isNull: true
            }
        }
        let isArrayType = false;
        if (protoReturnType.endsWith('Collection')) {
            isArrayType = true;
            protoReturnType = protoReturnType.replace("Collection", "");
        }

        if (Object.hasOwn(ProtoTypes, protoReturnType)) {
            try {
                const protoType = ProtoTypes[protoReturnType];

                if (isArrayType) {
                    let collectionType = `${protoReturnType}Collection`;
                    let protoCollectionType: any = ProtoTypes[collectionType];
                    if (!protoCollectionType) {
                        // create missing protobuf type for array of this type
                        protoCollectionType = new Type(collectionType)
                            .add(new Field('items', 1, protoType.name, 'repeated'));
                        ProtoTypes[collectionType] = protoCollectionType;
                        protobufRoot.nested.dymaptic.GeoBlazor.Core.add(protoCollectionType)
                    }
                    
                    this.checkObjectForGraphics(protoCollectionType, returnValue, true);

                    return protoCollectionType.encode({
                        items: returnValue
                    }).finish();
                }
                
                this.checkObjectForGraphics(protoType, returnValue, false);

                return protoType.encode(returnValue).finish();
            } catch (e) {
                console.error(e);
                throw e;
            }
        }
        
        return buildEncodedJson(returnValue);
    }
    
    checkObjectForGraphics(protoType: any, returnValue: any, isArrayType: boolean): void {
        if (this.updateGraphicsForProtobuf(protoType, returnValue, isArrayType)) {
            return;
        }
        for (let nested of protoType.nestedArray) {
            this.checkObjectForGraphics(nested, returnValue, isArrayType);
        }
    }
    
    updateGraphicsForProtobuf(protoType: any, returnValue: any, isArrayType: boolean): boolean {
        switch (protoType.name) {
            case 'Graphic':
                if (isArrayType) {
                    for(let val of returnValue as Array<any>) {
                        updateGraphicForProtobuf(val, null);
                    }
                } else {
                    updateGraphicForProtobuf(returnValue, null);
                }
                return true;
            case 'Geometry':
                if (isArrayType) {
                    for(let val of returnValue as Array<any>) {
                        updateGeometryForProtobuf(val);
                    }
                } else {
                    updateGeometryForProtobuf(returnValue);
                }
                return true;
            case 'Symbol':
                if (isArrayType) {
                    for(let val of returnValue as Array<any>) {
                        updateSymbolForProtobuf(val);
                    }
                } else {
                    updateSymbolForProtobuf(returnValue);
                }
                return true;
            default:
                return false;
        }
    }

    simpleDotNetTypes = ['int32', 'int64', 'long', 'decimal', 'double', 'single', 'float', 'int', 'bool',
        'ulong', 'uint', 'ushort', 'byte', 'sbyte', 'char',
        'string', 'datetime', 'dateonly', 'timeonly', 'guid', 'datetimeoffset', 'timespan'];
}