import {buildDotNetFlowGetSchemeByNameParams} from './flowGetSchemeByNameParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFlowGetSchemeByNameParamsGenerated(dotNetObject: any): Promise<any> {
    let jsflowGetSchemeByNameParams: any = {}

    if (hasValue(dotNetObject.basemap)) {
        jsflowGetSchemeByNameParams.basemap = dotNetObject.basemap;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jsflowGetSchemeByNameParams.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.name)) {
        jsflowGetSchemeByNameParams.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.theme)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedTheme} = dotNetObject.theme;
        jsflowGetSchemeByNameParams.theme = sanitizedTheme;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsflowGetSchemeByNameParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsflowGetSchemeByNameParams;

    let dnInstantiatedObject = await buildDotNetFlowGetSchemeByNameParams(jsflowGetSchemeByNameParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FlowGetSchemeByNameParams', e);
    }

    return jsflowGetSchemeByNameParams;
}

export async function buildDotNetFlowGetSchemeByNameParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFlowGetSchemeByNameParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.basemap)) {
        dotNetFlowGetSchemeByNameParams.basemap = jsObject.basemap;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetFlowGetSchemeByNameParams.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.name)) {
        dotNetFlowGetSchemeByNameParams.name = jsObject.name;
    }
    if (hasValue(jsObject.theme)) {
        dotNetFlowGetSchemeByNameParams.theme = jsObject.theme;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFlowGetSchemeByNameParams.id = k;
                break;
            }
        }
    }

    return dotNetFlowGetSchemeByNameParams;
}

