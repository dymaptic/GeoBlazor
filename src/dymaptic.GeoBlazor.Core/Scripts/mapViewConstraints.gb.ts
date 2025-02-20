import {buildDotNetMapViewConstraints} from './mapViewConstraints';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsMapViewConstraintsGenerated(dotNetObject: any): Promise<any> {
    let jsMapViewConstraints: any = {}
    if (hasValue(dotNetObject.geometry)) {
        let {buildJsGeometry} = await import('./geometry');
        jsMapViewConstraints.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }

    if (hasValue(dotNetObject.effectiveLODs)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedEffectiveLODs} = dotNetObject.effectiveLODs;
        jsMapViewConstraints.effectiveLODs = sanitizedEffectiveLODs;
    }
    if (hasValue(dotNetObject.effectiveMaxScale)) {
        jsMapViewConstraints.effectiveMaxScale = dotNetObject.effectiveMaxScale;
    }
    if (hasValue(dotNetObject.effectiveMaxZoom)) {
        jsMapViewConstraints.effectiveMaxZoom = dotNetObject.effectiveMaxZoom;
    }
    if (hasValue(dotNetObject.effectiveMinScale)) {
        jsMapViewConstraints.effectiveMinScale = dotNetObject.effectiveMinScale;
    }
    if (hasValue(dotNetObject.effectiveMinZoom)) {
        jsMapViewConstraints.effectiveMinZoom = dotNetObject.effectiveMinZoom;
    }
    if (hasValue(dotNetObject.lods)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedLods} = dotNetObject.lods;
        jsMapViewConstraints.lods = sanitizedLods;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsMapViewConstraints.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.maxZoom)) {
        jsMapViewConstraints.maxZoom = dotNetObject.maxZoom;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsMapViewConstraints.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.minZoom)) {
        jsMapViewConstraints.minZoom = dotNetObject.minZoom;
    }
    if (hasValue(dotNetObject.rotationEnabled)) {
        jsMapViewConstraints.rotationEnabled = dotNetObject.rotationEnabled;
    }
    if (hasValue(dotNetObject.snapToZoom)) {
        jsMapViewConstraints.snapToZoom = dotNetObject.snapToZoom;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMapViewConstraints);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMapViewConstraints;

    let dnInstantiatedObject = await buildDotNetMapViewConstraints(jsMapViewConstraints);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MapViewConstraints', e);
    }

    return jsMapViewConstraints;
}

export async function buildDotNetMapViewConstraintsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapViewConstraints: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.geometry)) {
        let {buildDotNetGeometry} = await import('./geometry');
        dotNetMapViewConstraints.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    if (hasValue(jsObject.effectiveLODs)) {
        dotNetMapViewConstraints.effectiveLODs = jsObject.effectiveLODs;
    }
    if (hasValue(jsObject.effectiveMaxScale)) {
        dotNetMapViewConstraints.effectiveMaxScale = jsObject.effectiveMaxScale;
    }
    if (hasValue(jsObject.effectiveMaxZoom)) {
        dotNetMapViewConstraints.effectiveMaxZoom = jsObject.effectiveMaxZoom;
    }
    if (hasValue(jsObject.effectiveMinScale)) {
        dotNetMapViewConstraints.effectiveMinScale = jsObject.effectiveMinScale;
    }
    if (hasValue(jsObject.effectiveMinZoom)) {
        dotNetMapViewConstraints.effectiveMinZoom = jsObject.effectiveMinZoom;
    }
    if (hasValue(jsObject.lods)) {
        dotNetMapViewConstraints.lods = jsObject.lods;
    }
    if (hasValue(jsObject.maxScale)) {
        dotNetMapViewConstraints.maxScale = jsObject.maxScale;
    }
    if (hasValue(jsObject.maxZoom)) {
        dotNetMapViewConstraints.maxZoom = jsObject.maxZoom;
    }
    if (hasValue(jsObject.minScale)) {
        dotNetMapViewConstraints.minScale = jsObject.minScale;
    }
    if (hasValue(jsObject.minZoom)) {
        dotNetMapViewConstraints.minZoom = jsObject.minZoom;
    }
    if (hasValue(jsObject.rotationEnabled)) {
        dotNetMapViewConstraints.rotationEnabled = jsObject.rotationEnabled;
    }
    if (hasValue(jsObject.snapToZoom)) {
        dotNetMapViewConstraints.snapToZoom = jsObject.snapToZoom;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMapViewConstraints.id = k;
                break;
            }
        }
    }

    return dotNetMapViewConstraints;
}

