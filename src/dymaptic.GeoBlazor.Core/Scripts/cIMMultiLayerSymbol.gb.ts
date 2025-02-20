import {buildDotNetCIMMultiLayerSymbol} from './cIMMultiLayerSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCIMMultiLayerSymbolGenerated(dotNetObject: any): Promise<any> {
    let jsCIMMultiLayerSymbol: any = {}

    if (hasValue(dotNetObject.effects)) {
        jsCIMMultiLayerSymbol.effects = dotNetObject.effects;
    }
    if (hasValue(dotNetObject.symbolLayers)) {
        jsCIMMultiLayerSymbol.symbolLayers = dotNetObject.symbolLayers;
    }
    if (hasValue(dotNetObject.thumbnailURI)) {
        jsCIMMultiLayerSymbol.thumbnailURI = dotNetObject.thumbnailURI;
    }
    if (hasValue(dotNetObject.useRealWorldSymbolSizes)) {
        jsCIMMultiLayerSymbol.useRealWorldSymbolSizes = dotNetObject.useRealWorldSymbolSizes;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCIMMultiLayerSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCIMMultiLayerSymbol;

    let dnInstantiatedObject = await buildDotNetCIMMultiLayerSymbol(jsCIMMultiLayerSymbol);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CIMMultiLayerSymbol', e);
    }

    return jsCIMMultiLayerSymbol;
}

export async function buildDotNetCIMMultiLayerSymbolGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCIMMultiLayerSymbol: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.effects)) {
        dotNetCIMMultiLayerSymbol.effects = jsObject.effects;
    }
    if (hasValue(jsObject.symbolLayers)) {
        dotNetCIMMultiLayerSymbol.symbolLayers = jsObject.symbolLayers;
    }
    if (hasValue(jsObject.thumbnailURI)) {
        dotNetCIMMultiLayerSymbol.thumbnailURI = jsObject.thumbnailURI;
    }
    if (hasValue(jsObject.type)) {
        dotNetCIMMultiLayerSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.useRealWorldSymbolSizes)) {
        dotNetCIMMultiLayerSymbol.useRealWorldSymbolSizes = jsObject.useRealWorldSymbolSizes;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCIMMultiLayerSymbol.id = k;
                break;
            }
        }
    }

    return dotNetCIMMultiLayerSymbol;
}

