// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSceneViewConstraints } from './sceneViewConstraints';

export async function buildJsSceneViewConstraintsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSceneViewConstraints: any = {};
    if (hasValue(dotNetObject.altitude)) {
        let { buildJsSceneViewConstraintsAltitude } = await import('./sceneViewConstraintsAltitude');
        jsSceneViewConstraints.altitude = await buildJsSceneViewConstraintsAltitude(dotNetObject.altitude, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.clipDistance)) {
        let { buildJsSceneViewConstraintsClipDistance } = await import('./sceneViewConstraintsClipDistance');
        jsSceneViewConstraints.clipDistance = await buildJsSceneViewConstraintsClipDistance(dotNetObject.clipDistance, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.tilt)) {
        let { buildJsSceneViewConstraintsTilt } = await import('./sceneViewConstraintsTilt');
        jsSceneViewConstraints.tilt = await buildJsSceneViewConstraintsTilt(dotNetObject.tilt, layerId, viewId) as any;
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsSceneViewConstraints);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSceneViewConstraints;
    
    return jsSceneViewConstraints;
}


export async function buildDotNetSceneViewConstraintsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSceneViewConstraints: any = {};
    
    if (hasValue(jsObject.altitude)) {
        let { buildDotNetSceneViewConstraintsAltitude } = await import('./sceneViewConstraintsAltitude');
        dotNetSceneViewConstraints.altitude = await buildDotNetSceneViewConstraintsAltitude(jsObject.altitude, layerId, viewId);
    }
    
    if (hasValue(jsObject.clipDistance)) {
        let { buildDotNetSceneViewConstraintsClipDistance } = await import('./sceneViewConstraintsClipDistance');
        dotNetSceneViewConstraints.clipDistance = await buildDotNetSceneViewConstraintsClipDistance(jsObject.clipDistance, layerId, viewId);
    }
    
    if (hasValue(jsObject.tilt)) {
        let { buildDotNetSceneViewConstraintsTilt } = await import('./sceneViewConstraintsTilt');
        dotNetSceneViewConstraints.tilt = await buildDotNetSceneViewConstraintsTilt(jsObject.tilt, layerId, viewId);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSceneViewConstraints.id = geoBlazorId;
    }

    return dotNetSceneViewConstraints;
}

