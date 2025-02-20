import {buildDotNetDotDensitySchemeOutline} from './dotDensitySchemeOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsDotDensitySchemeOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsDotDensitySchemeOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsDotDensitySchemeOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsDotDensitySchemeOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsDotDensitySchemeOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsDotDensitySchemeOutline;

    let dnInstantiatedObject = await buildDotNetDotDensitySchemeOutline(jsDotDensitySchemeOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for DotDensitySchemeOutline', e);
    }

    return jsDotDensitySchemeOutline;
}

export async function buildDotNetDotDensitySchemeOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetDotDensitySchemeOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetDotDensitySchemeOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetDotDensitySchemeOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetDotDensitySchemeOutline.id = k;
                break;
            }
        }
    }

    return dotNetDotDensitySchemeOutline;
}

