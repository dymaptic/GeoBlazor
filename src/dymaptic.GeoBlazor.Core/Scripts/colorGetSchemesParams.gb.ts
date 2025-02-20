import {buildDotNetColorGetSchemesParams} from './colorGetSchemesParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorGetSchemesParamsGenerated(dotNetObject: any): Promise<any> {
    let jscolorGetSchemesParams: any = {}

    if (hasValue(dotNetObject.basemap)) {
        jscolorGetSchemesParams.basemap = dotNetObject.basemap;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jscolorGetSchemesParams.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jscolorGetSchemesParams.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.theme)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedTheme} = dotNetObject.theme;
        jscolorGetSchemesParams.theme = sanitizedTheme;
    }
    if (hasValue(dotNetObject.view)) {
        jscolorGetSchemesParams.view = dotNetObject.view;
    }
    if (hasValue(dotNetObject.worldScale)) {
        jscolorGetSchemesParams.worldScale = dotNetObject.worldScale;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jscolorGetSchemesParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jscolorGetSchemesParams;

    let dnInstantiatedObject = await buildDotNetColorGetSchemesParams(jscolorGetSchemesParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorGetSchemesParams', e);
    }

    return jscolorGetSchemesParams;
}

export async function buildDotNetColorGetSchemesParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorGetSchemesParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.basemap)) {
        dotNetColorGetSchemesParams.basemap = jsObject.basemap;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetColorGetSchemesParams.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.geometryType)) {
        dotNetColorGetSchemesParams.geometryType = jsObject.geometryType;
    }
    if (hasValue(jsObject.theme)) {
        dotNetColorGetSchemesParams.theme = jsObject.theme;
    }
    if (hasValue(jsObject.view)) {
        dotNetColorGetSchemesParams.view = jsObject.view;
    }
    if (hasValue(jsObject.worldScale)) {
        dotNetColorGetSchemesParams.worldScale = jsObject.worldScale;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorGetSchemesParams.id = k;
                break;
            }
        }
    }

    return dotNetColorGetSchemesParams;
}

