import {buildEncodedJson, hasValue, loadProtobuf, ProtoTypes} from "./arcGisJsInterop";

export default class BaseComponent {
    
    async invokeSerializedMethod(methodName: string, useStreams: boolean, ...parameters: any[]): Promise<any> {
        await loadProtobuf();
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
        
        if (useStreams) {
            return buildEncodedJson(result);
        }
        
        return result;
    }

    async invokeVoidSerializedMethod(methodName: string, useStreams: boolean, ...parameters: any[]): Promise<void> {
        await loadProtobuf();
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
        
        if (this.simpleDotNetTypes.includes(paramType.toLowerCase())) {
            // don't convert simple types
            return paramValue;
        }
        
        // server is sending a stream, could be a protobuf or json stream
        if (useStreams) {
            return await this.parseDotNetStream(paramType, paramValue);
        }
        
        // server is sending a byte array, should be protobuf, but falls back to json for unknown types
        if (paramValue instanceof Uint8Array) {
            return this.parseDotNetUint8Array(paramType, paramValue);
        }

        // server is sending a string of a non-simple type, should be json
        return this.parseDotNetJson(paramValue);
    }

    async parseDotNetStream(typeName: string, streamRef: any): Promise<any> {
        let arrayBuffer: ArrayBuffer = await streamRef.arrayBuffer();
        let uint8 = new Uint8Array(arrayBuffer);

        return this.parseDotNetUint8Array(typeName, uint8);
    }
    
    parseDotNetUint8Array(typeName: string, uint8: Uint8Array): any {
        if (Object.hasOwn(ProtoTypes, typeName)) {
            const protoType = ProtoTypes[typeName];
            try {
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

        // Fallback to JSON parsing
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
                return text.replace(/"(.*)"/, "$&");
            }
            
            return text;
        } catch (e) {
            console.error(e);
            return null;
        }
    }
    
    simpleDotNetTypes = ['int32', 'int64', 'long', 'decimal', 'double', 'single', 'float', 'int', 'bool',
        'ulong', 'uint', 'ushort', 'byte', 'sbyte', 'char',
        'string', 'datetime', 'dateonly', 'timeonly', 'guid', 'datetimeoffset', 'timespan'];
}