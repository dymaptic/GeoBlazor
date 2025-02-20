import {buildDotNetColorSchemeForPointOutline} from './colorSchemeForPointOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorSchemeForPointOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsColorSchemeForPointOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForPointOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsColorSchemeForPointOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSchemeForPointOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSchemeForPointOutline;

    let dnInstantiatedObject = await buildDotNetColorSchemeForPointOutline(jsColorSchemeForPointOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSchemeForPointOutline', e);
    }

    return jsColorSchemeForPointOutline;
}

export async function buildDotNetColorSchemeForPointOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorSchemeForPointOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForPointOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetColorSchemeForPointOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSchemeForPointOutline.id = k;
                break;
            }
        }
    }

    return dotNetColorSchemeForPointOutline;
}

