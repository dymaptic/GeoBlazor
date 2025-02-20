import {buildDotNetSizeSchemeForPointOutline} from './sizeSchemeForPointOutline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeSchemeForPointOutlineGenerated(dotNetObject: any): Promise<any> {
    let jsSizeSchemeForPointOutline: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsSizeSchemeForPointOutline.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.width)) {
        jsSizeSchemeForPointOutline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSizeSchemeForPointOutline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSizeSchemeForPointOutline;

    let dnInstantiatedObject = await buildDotNetSizeSchemeForPointOutline(jsSizeSchemeForPointOutline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeSchemeForPointOutline', e);
    }

    return jsSizeSchemeForPointOutline;
}

export async function buildDotNetSizeSchemeForPointOutlineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeSchemeForPointOutline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetSizeSchemeForPointOutline.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.width)) {
        dotNetSizeSchemeForPointOutline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeSchemeForPointOutline.id = k;
                break;
            }
        }
    }

    return dotNetSizeSchemeForPointOutline;
}

