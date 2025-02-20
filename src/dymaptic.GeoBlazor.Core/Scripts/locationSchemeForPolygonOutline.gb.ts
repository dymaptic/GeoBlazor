import {buildDotNetLocationSchemeForPolygonOutline} from './locationSchemeForPolygonOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsLocationSchemeForPolygonOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsLocationSchemeForPolygonOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsLocationSchemeForPolygonOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsLocationSchemeForPolygonOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLocationSchemeForPolygonOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLocationSchemeForPolygonOutline;

    let dnInstantiatedObject = await buildDotNetLocationSchemeForPolygonOutline(jsLocationSchemeForPolygonOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LocationSchemeForPolygonOutline', e);
    }

    return jsLocationSchemeForPolygonOutline;
}

export async function buildDotNetLocationSchemeForPolygonOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLocationSchemeForPolygonOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetLocationSchemeForPolygonOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetLocationSchemeForPolygonOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLocationSchemeForPolygonOutline.id = k;
                break;
            }
        }
    }

    return dotNetLocationSchemeForPolygonOutline;
}

