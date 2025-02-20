import {buildDotNetSceneViewEnvironment} from './sceneViewEnvironment';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSceneViewEnvironmentGenerated(dotNetObject: any): Promise<any> {
    let jsSceneViewEnvironment: any = {}

    if (hasValue(dotNetObject.atmosphere)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedAtmosphere} = dotNetObject.atmosphere;
        jsSceneViewEnvironment.atmosphere = sanitizedAtmosphere;
    }
    if (hasValue(dotNetObject.atmosphereEnabled)) {
        jsSceneViewEnvironment.atmosphereEnabled = dotNetObject.atmosphereEnabled;
    }
    if (hasValue(dotNetObject.background)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedBackground} = dotNetObject.background;
        jsSceneViewEnvironment.background = sanitizedBackground;
    }
    if (hasValue(dotNetObject.lighting)) {
        jsSceneViewEnvironment.lighting = dotNetObject.lighting;
    }
    if (hasValue(dotNetObject.starsEnabled)) {
        jsSceneViewEnvironment.starsEnabled = dotNetObject.starsEnabled;
    }
    if (hasValue(dotNetObject.weather)) {
        jsSceneViewEnvironment.weather = dotNetObject.weather;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSceneViewEnvironment);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSceneViewEnvironment;

    let dnInstantiatedObject = await buildDotNetSceneViewEnvironment(jsSceneViewEnvironment);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SceneViewEnvironment', e);
    }

    return jsSceneViewEnvironment;
}

export async function buildDotNetSceneViewEnvironmentGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSceneViewEnvironment: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.atmosphere)) {
        dotNetSceneViewEnvironment.atmosphere = jsObject.atmosphere;
    }
    if (hasValue(jsObject.atmosphereEnabled)) {
        dotNetSceneViewEnvironment.atmosphereEnabled = jsObject.atmosphereEnabled;
    }
    if (hasValue(jsObject.background)) {
        dotNetSceneViewEnvironment.background = jsObject.background;
    }
    if (hasValue(jsObject.lighting)) {
        dotNetSceneViewEnvironment.lighting = jsObject.lighting;
    }
    if (hasValue(jsObject.starsEnabled)) {
        dotNetSceneViewEnvironment.starsEnabled = jsObject.starsEnabled;
    }
    if (hasValue(jsObject.weather)) {
        dotNetSceneViewEnvironment.weather = jsObject.weather;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSceneViewEnvironment.id = k;
                break;
            }
        }
    }

    return dotNetSceneViewEnvironment;
}

