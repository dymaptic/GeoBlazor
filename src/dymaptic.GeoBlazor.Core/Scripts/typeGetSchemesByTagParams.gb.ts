import {buildDotNetTypeGetSchemesByTagParams} from './typeGetSchemesByTagParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTypeGetSchemesByTagParamsGenerated(dotNetObject: any): Promise<any> {
    let jstypeGetSchemesByTagParams: any = {}

    if (hasValue(dotNetObject.basemap)) {
        jstypeGetSchemesByTagParams.basemap = dotNetObject.basemap;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jstypeGetSchemesByTagParams.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.excludedTags)) {
        jstypeGetSchemesByTagParams.excludedTags = dotNetObject.excludedTags;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jstypeGetSchemesByTagParams.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.includedTags)) {
        jstypeGetSchemesByTagParams.includedTags = dotNetObject.includedTags;
    }
    if (hasValue(dotNetObject.theme)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedTheme} = dotNetObject.theme;
        jstypeGetSchemesByTagParams.theme = sanitizedTheme;
    }
    if (hasValue(dotNetObject.view)) {
        jstypeGetSchemesByTagParams.view = dotNetObject.view;
    }
    if (hasValue(dotNetObject.worldScale)) {
        jstypeGetSchemesByTagParams.worldScale = dotNetObject.worldScale;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jstypeGetSchemesByTagParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jstypeGetSchemesByTagParams;

    let dnInstantiatedObject = await buildDotNetTypeGetSchemesByTagParams(jstypeGetSchemesByTagParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TypeGetSchemesByTagParams', e);
    }

    return jstypeGetSchemesByTagParams;
}

export async function buildDotNetTypeGetSchemesByTagParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTypeGetSchemesByTagParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.basemap)) {
        dotNetTypeGetSchemesByTagParams.basemap = jsObject.basemap;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetTypeGetSchemesByTagParams.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.excludedTags)) {
        dotNetTypeGetSchemesByTagParams.excludedTags = jsObject.excludedTags;
    }
    if (hasValue(jsObject.geometryType)) {
        dotNetTypeGetSchemesByTagParams.geometryType = jsObject.geometryType;
    }
    if (hasValue(jsObject.includedTags)) {
        dotNetTypeGetSchemesByTagParams.includedTags = jsObject.includedTags;
    }
    if (hasValue(jsObject.theme)) {
        dotNetTypeGetSchemesByTagParams.theme = jsObject.theme;
    }
    if (hasValue(jsObject.view)) {
        dotNetTypeGetSchemesByTagParams.view = jsObject.view;
    }
    if (hasValue(jsObject.worldScale)) {
        dotNetTypeGetSchemesByTagParams.worldScale = jsObject.worldScale;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTypeGetSchemesByTagParams.id = k;
                break;
            }
        }
    }

    return dotNetTypeGetSchemesByTagParams;
}

