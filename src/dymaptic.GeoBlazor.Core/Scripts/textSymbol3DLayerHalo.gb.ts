import {buildDotNetTextSymbol3DLayerHalo} from './textSymbol3DLayerHalo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTextSymbol3DLayerHaloGenerated(dotNetObject: any): Promise<any> {
    let jsTextSymbol3DLayerHalo: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsTextSymbol3DLayerHalo.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.size)) {
        jsTextSymbol3DLayerHalo.size = dotNetObject.size;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTextSymbol3DLayerHalo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsTextSymbol3DLayerHalo;

    let dnInstantiatedObject = await buildDotNetTextSymbol3DLayerHalo(jsTextSymbol3DLayerHalo);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TextSymbol3DLayerHalo', e);
    }

    return jsTextSymbol3DLayerHalo;
}

export async function buildDotNetTextSymbol3DLayerHaloGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTextSymbol3DLayerHalo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetTextSymbol3DLayerHalo.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.size)) {
        dotNetTextSymbol3DLayerHalo.size = jsObject.size;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTextSymbol3DLayerHalo.id = k;
                break;
            }
        }
    }

    return dotNetTextSymbol3DLayerHalo;
}

