// override generated code in this file

import {arcGisObjectRefs, hasValue, jsObjectRefs } from './arcGisJsInterop';

export function buildJsMeshVertexAttributes(dotNetObject: any): any {
    let jsMeshVertexAttributes: any = {}

    if (hasValue(dotNetObject.color)) {
        jsMeshVertexAttributes.color = dotNetObject.color;
    }
    if (hasValue(dotNetObject.normal)) {
        jsMeshVertexAttributes.normal = dotNetObject.normal;
    }
    if (hasValue(dotNetObject.position)) {
        jsMeshVertexAttributes.position = dotNetObject.position;
    }
    if (hasValue(dotNetObject.tangent)) {
        jsMeshVertexAttributes.tangent = dotNetObject.tangent;
    }
    if (hasValue(dotNetObject.uv)) {
        jsMeshVertexAttributes.uv = dotNetObject.uv;
    }

    return jsMeshVertexAttributes;
}     

export function buildDotNetMeshVertexAttributes(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMeshVertexAttributes: any = {};
    
    if (hasValue(jsObject.color)) {
        dotNetMeshVertexAttributes.color = jsObject.color;
    }
    if (hasValue(jsObject.normal)) {
        dotNetMeshVertexAttributes.normal = jsObject.normal;
    }
    if (hasValue(jsObject.position)) {
        dotNetMeshVertexAttributes.position = jsObject.position;
    }
    if (hasValue(jsObject.tangent)) {
        dotNetMeshVertexAttributes.tangent = jsObject.tangent;
    }
    if (hasValue(jsObject.uv)) {
        dotNetMeshVertexAttributes.uv = jsObject.uv;
    }

    return dotNetMeshVertexAttributes;
}
