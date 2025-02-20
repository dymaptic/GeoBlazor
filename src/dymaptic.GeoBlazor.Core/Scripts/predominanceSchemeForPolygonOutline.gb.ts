import {buildDotNetPredominanceSchemeForPolygonOutline} from './predominanceSchemeForPolygonOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsPredominanceSchemeForPolygonOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsPredominanceSchemeForPolygonOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsPredominanceSchemeForPolygonOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsPredominanceSchemeForPolygonOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPredominanceSchemeForPolygonOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPredominanceSchemeForPolygonOutline;

    let dnInstantiatedObject = await buildDotNetPredominanceSchemeForPolygonOutline(jsPredominanceSchemeForPolygonOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PredominanceSchemeForPolygonOutline', e);
    }

    return jsPredominanceSchemeForPolygonOutline;
}

export async function buildDotNetPredominanceSchemeForPolygonOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPredominanceSchemeForPolygonOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetPredominanceSchemeForPolygonOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetPredominanceSchemeForPolygonOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPredominanceSchemeForPolygonOutline.id = k;
                break;
            }
        }
    }

    return dotNetPredominanceSchemeForPolygonOutline;
}

