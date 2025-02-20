import {buildDotNetSizeSchemes} from './sizeSchemes';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeSchemesGenerated(dotNetObject: any): Promise<any> {
    let jsSizeSchemes: any = {}

    if (hasValue(dotNetObject.basemapId)) {
        jsSizeSchemes.basemapId = dotNetObject.basemapId;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jsSizeSchemes.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.primaryScheme)) {
        jsSizeSchemes.primaryScheme = dotNetObject.primaryScheme;
    }
    if (hasValue(dotNetObject.secondarySchemes)) {
        jsSizeSchemes.secondarySchemes = dotNetObject.secondarySchemes;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSizeSchemes);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSizeSchemes;

    let dnInstantiatedObject = await buildDotNetSizeSchemes(jsSizeSchemes);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeSchemes', e);
    }

    return jsSizeSchemes;
}

export async function buildDotNetSizeSchemesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeSchemes: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.basemapId)) {
        dotNetSizeSchemes.basemapId = jsObject.basemapId;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetSizeSchemes.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.primaryScheme)) {
        dotNetSizeSchemes.primaryScheme = jsObject.primaryScheme;
    }
    if (hasValue(jsObject.secondarySchemes)) {
        dotNetSizeSchemes.secondarySchemes = jsObject.secondarySchemes;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeSchemes.id = k;
                break;
            }
        }
    }

    return dotNetSizeSchemes;
}

