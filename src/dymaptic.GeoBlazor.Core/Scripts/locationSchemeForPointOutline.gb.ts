import {buildDotNetLocationSchemeForPointOutline} from './locationSchemeForPointOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsLocationSchemeForPointOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsLocationSchemeForPointOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsLocationSchemeForPointOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsLocationSchemeForPointOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLocationSchemeForPointOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLocationSchemeForPointOutline;

    let dnInstantiatedObject = await buildDotNetLocationSchemeForPointOutline(jsLocationSchemeForPointOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LocationSchemeForPointOutline', e);
    }

    return jsLocationSchemeForPointOutline;
}

export async function buildDotNetLocationSchemeForPointOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLocationSchemeForPointOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetLocationSchemeForPointOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetLocationSchemeForPointOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLocationSchemeForPointOutline.id = k;
                break;
            }
        }
    }

    return dotNetLocationSchemeForPointOutline;
}

