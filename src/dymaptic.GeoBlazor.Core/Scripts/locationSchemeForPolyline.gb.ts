import {buildDotNetLocationSchemeForPolyline} from './locationSchemeForPolyline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsLocationSchemeForPolylineGenerated(dotNetObject: any): Promise<any> {
    let jsLocationSchemeForPolyline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsLocationSchemeForPolyline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.opacity)) {
        jsLocationSchemeForPolyline.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.width)) {
        jsLocationSchemeForPolyline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLocationSchemeForPolyline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLocationSchemeForPolyline;

    let dnInstantiatedObject = await buildDotNetLocationSchemeForPolyline(jsLocationSchemeForPolyline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LocationSchemeForPolyline', e);
    }

    return jsLocationSchemeForPolyline;
}

export async function buildDotNetLocationSchemeForPolylineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLocationSchemeForPolyline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetLocationSchemeForPolyline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.opacity)) {
        dotNetLocationSchemeForPolyline.opacity = jsObject.opacity;
    }
    if (hasValue(jsObject.width)) {
        dotNetLocationSchemeForPolyline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLocationSchemeForPolyline.id = k;
                break;
            }
        }
    }

    return dotNetLocationSchemeForPolyline;
}

