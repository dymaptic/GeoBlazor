import {buildDotNetCIMPolygonSymbol} from './cIMPolygonSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCIMPolygonSymbolGenerated(dotNetObject: any): Promise<any> {
    let jsCIMPolygonSymbol: any = {}
    if (hasValue(dotNetObject.symbolLayers)) {
        let {buildJsICIMSymbolLayer} = await import('./iCIMSymbolLayer');
        jsCIMPolygonSymbol.symbolLayers = await Promise.all(dotNetObject.symbolLayers.map(async i => await buildJsICIMSymbolLayer(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.effects)) {
        jsCIMPolygonSymbol.effects = dotNetObject.effects;
    }
    if (hasValue(dotNetObject.thumbnailURI)) {
        jsCIMPolygonSymbol.thumbnailURI = dotNetObject.thumbnailURI;
    }
    if (hasValue(dotNetObject.useRealWorldSymbolSizes)) {
        jsCIMPolygonSymbol.useRealWorldSymbolSizes = dotNetObject.useRealWorldSymbolSizes;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCIMPolygonSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCIMPolygonSymbol;

    let dnInstantiatedObject = await buildDotNetCIMPolygonSymbol(jsCIMPolygonSymbol);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CIMPolygonSymbol', e);
    }

    return jsCIMPolygonSymbol;
}

export async function buildDotNetCIMPolygonSymbolGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCIMPolygonSymbol: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.effects)) {
        dotNetCIMPolygonSymbol.effects = jsObject.effects;
    }
    if (hasValue(jsObject.thumbnailURI)) {
        dotNetCIMPolygonSymbol.thumbnailURI = jsObject.thumbnailURI;
    }
    if (hasValue(jsObject.type)) {
        dotNetCIMPolygonSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.useRealWorldSymbolSizes)) {
        dotNetCIMPolygonSymbol.useRealWorldSymbolSizes = jsObject.useRealWorldSymbolSizes;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCIMPolygonSymbol.id = k;
                break;
            }
        }
    }

    return dotNetCIMPolygonSymbol;
}

