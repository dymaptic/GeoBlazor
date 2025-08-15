// override generated code in this file

import MeshTransform from "@arcgis/core/geometry/support/MeshTransform";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsMeshTransform(dotNetObject: any, viewId: string | null): any {
    let properties : any = {};

    if (hasValue(dotNetObject.rotationAngle)) {
        properties.rotationAngle = dotNetObject.rotationAngle;
    }
    if (hasValue(dotNetObject.rotationAxis)) {
        properties.rotationAxis = dotNetObject.rotationAxis;
    }
    if (hasValue(dotNetObject.scale)) {
        properties.scale = dotNetObject.scale;
    }
    if (hasValue(dotNetObject.translation)) {
        properties.translation = dotNetObject.translation;
    }

    let jsMeshTransform = new MeshTransform(properties);

    return jsMeshTransform;
}     

export function buildDotNetMeshTransform(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMeshTransform: any = {};
    if (hasValue(jsObject.rotationAngle)) {
        dotNetMeshTransform.rotationAngle = jsObject.rotationAngle;
    }
    if (hasValue(jsObject.rotationAxis)) {
        dotNetMeshTransform.rotationAxis = jsObject.rotationAxis;
    }
    if (hasValue(jsObject.scale)) {
        dotNetMeshTransform.scale = jsObject.scale;
    }
    if (hasValue(jsObject.translation)) {
        dotNetMeshTransform.translation = jsObject.translation;
    }

    return dotNetMeshTransform;
}
