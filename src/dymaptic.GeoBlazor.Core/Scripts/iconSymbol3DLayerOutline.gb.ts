import {buildDotNetIconSymbol3DLayerOutline} from './iconSymbol3DLayerOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsIconSymbol3DLayerOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsIconSymbol3DLayerOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsIconSymbol3DLayerOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.size)) {
        jsIconSymbol3DLayerOutline.size = dotNetObject.size;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsIconSymbol3DLayerOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsIconSymbol3DLayerOutline;

    let dnInstantiatedObject = await buildDotNetIconSymbol3DLayerOutline(jsIconSymbol3DLayerOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for IconSymbol3DLayerOutline', e);
    }

    return jsIconSymbol3DLayerOutline;
}

export async function buildDotNetIconSymbol3DLayerOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetIconSymbol3DLayerOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetIconSymbol3DLayerOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.size)) {
        dotNetIconSymbol3DLayerOutline.size = jsObject.size;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetIconSymbol3DLayerOutline.id = k;
                break;
            }
        }
    }

    return dotNetIconSymbol3DLayerOutline;
}

