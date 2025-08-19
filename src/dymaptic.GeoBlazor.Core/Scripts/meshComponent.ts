// override generated code in this file
import MeshComponent from "@arcgis/core/geometry/support/MeshComponent";
import { hasValue } from "./arcGisJsInterop";

export function buildJsMeshComponent(dotNetObject: any): any {
    let properties : any = {};

    if (hasValue(dotNetObject.faces)) {
        properties.faces = dotNetObject.faces;
    }
    if (hasValue(dotNetObject.material)) {
        properties.material = dotNetObject.material;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.shading)) {
        properties.shading = dotNetObject.shading;
    }

    let jsMeshComponent = new MeshComponent(properties);

    return jsMeshComponent;
}     

export function buildDotNetMeshComponent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMeshComponent: any = {};
    if (hasValue(jsObject.faces)) {
        dotNetMeshComponent.faces = jsObject.faces;
    }
    if (hasValue(jsObject.material)) {
        dotNetMeshComponent.material = jsObject.material;
    }
    if (hasValue(jsObject.name)) {
        dotNetMeshComponent.name = jsObject.name;
    }
    if (hasValue(jsObject.shading)) {
        dotNetMeshComponent.shading = jsObject.shading;
    }

    return dotNetMeshComponent;
}
