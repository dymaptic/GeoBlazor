// override generated code in this file
import Mesh from "@arcgis/core/geometry/Mesh";
import {arcGisObjectRefs, hasValue } from './geoBlazorCore';
import {buildDotNetMeshComponent, buildJsMeshComponent} from "./meshComponent";
import {buildDotNetSpatialReference, buildJsSpatialReference } from "./spatialReference";
import {buildDotNetMeshTransform, buildJsMeshTransform } from "./meshTransform";
import {buildDotNetMeshVertexAttributes, buildJsMeshVertexAttributes} from "./meshVertexAttributes";
import { buildDotNetExtent } from "./extent";
import { buildDotNetPoint } from "./point";

export function buildJsMesh(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.components)) {
        properties.components = dotNetObject.components.map(i => buildJsMeshComponent(i)) as any;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
    }
    if (hasValue(dotNetObject.transform)) {
        properties.transform = buildJsMeshTransform(dotNetObject.transform) as any;
    }
    if (hasValue(dotNetObject.vertexAttributes)) {
        properties.vertexAttributes = buildJsMeshVertexAttributes(dotNetObject.vertexAttributes) as any;
    }

    if (hasValue(dotNetObject.hasM)) {
        properties.hasM = dotNetObject.hasM;
    }
    if (hasValue(dotNetObject.hasZ)) {
        properties.hasZ = dotNetObject.hasZ;
    }
    if (hasValue(dotNetObject.vertexSpace)) {
        properties.vertexSpace = dotNetObject.vertexSpace;
    }

    let jsMesh = new Mesh(properties);

    return jsMesh;
}     

export function buildDotNetMesh(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMesh: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.components)) {
        dotNetMesh.components = jsObject.components.map(i => buildDotNetMeshComponent(i));
    }
    if (hasValue(jsObject.extent)) {
        dotNetMesh.extent = buildDotNetExtent(jsObject.extent);
    }
    if (hasValue(jsObject.origin)) {
        dotNetMesh.origin = buildDotNetPoint(jsObject.origin);
    }
    if (hasValue(jsObject.spatialReference)) {
        dotNetMesh.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }
    if (hasValue(jsObject.transform)) {
        dotNetMesh.transform = buildDotNetMeshTransform(jsObject.transform);
    }
    if (hasValue(jsObject.vertexAttributes)) {
        dotNetMesh.vertexAttributes = buildDotNetMeshVertexAttributes(jsObject.vertexAttributes);
    }
    if (hasValue(jsObject.cache)) {
        dotNetMesh.cache = jsObject.cache;
    }
    if (hasValue(jsObject.hasM)) {
        dotNetMesh.hasM = jsObject.hasM;
    }
    if (hasValue(jsObject.hasZ)) {
        dotNetMesh.hasZ = jsObject.hasZ;
    }
    if (hasValue(jsObject.type)) {
        dotNetMesh.type = jsObject.type;
    }
    if (hasValue(jsObject.vertexSpace)) {
        dotNetMesh.vertexSpace = jsObject.vertexSpace;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMesh.id = k;
                break;
            }
        }
    }

    return dotNetMesh;
}
