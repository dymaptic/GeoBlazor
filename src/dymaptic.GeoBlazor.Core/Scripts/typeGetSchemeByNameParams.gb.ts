import {buildDotNetTypeGetSchemeByNameParams} from './typeGetSchemeByNameParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTypeGetSchemeByNameParamsGenerated(dotNetObject: any): Promise<any> {
    let jstypeGetSchemeByNameParams: any = {}

    if (hasValue(dotNetObject.basemap)) {
        jstypeGetSchemeByNameParams.basemap = dotNetObject.basemap;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jstypeGetSchemeByNameParams.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jstypeGetSchemeByNameParams.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.name)) {
        jstypeGetSchemeByNameParams.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.theme)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedTheme} = dotNetObject.theme;
        jstypeGetSchemeByNameParams.theme = sanitizedTheme;
    }
    if (hasValue(dotNetObject.view)) {
        jstypeGetSchemeByNameParams.view = dotNetObject.view;
    }
    if (hasValue(dotNetObject.worldScale)) {
        jstypeGetSchemeByNameParams.worldScale = dotNetObject.worldScale;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jstypeGetSchemeByNameParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jstypeGetSchemeByNameParams;

    let dnInstantiatedObject = await buildDotNetTypeGetSchemeByNameParams(jstypeGetSchemeByNameParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TypeGetSchemeByNameParams', e);
    }

    return jstypeGetSchemeByNameParams;
}

export async function buildDotNetTypeGetSchemeByNameParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTypeGetSchemeByNameParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.basemap)) {
        dotNetTypeGetSchemeByNameParams.basemap = jsObject.basemap;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetTypeGetSchemeByNameParams.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.geometryType)) {
        dotNetTypeGetSchemeByNameParams.geometryType = jsObject.geometryType;
    }
    if (hasValue(jsObject.name)) {
        dotNetTypeGetSchemeByNameParams.name = jsObject.name;
    }
    if (hasValue(jsObject.theme)) {
        dotNetTypeGetSchemeByNameParams.theme = jsObject.theme;
    }
    if (hasValue(jsObject.view)) {
        dotNetTypeGetSchemeByNameParams.view = jsObject.view;
    }
    if (hasValue(jsObject.worldScale)) {
        dotNetTypeGetSchemeByNameParams.worldScale = jsObject.worldScale;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTypeGetSchemeByNameParams.id = k;
                break;
            }
        }
    }

    return dotNetTypeGetSchemeByNameParams;
}

