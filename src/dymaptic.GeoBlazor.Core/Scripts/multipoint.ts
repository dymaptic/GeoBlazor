import {hasValue} from "./arcGisJsInterop";
import Multipoint from "@arcgis/core/geometry/Multipoint";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {buildDotNetExtent} from "./extent";

export function buildJsMultipoint(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.hasM)) {
        properties.hasM = dotNetObject.hasM;
    }
    if (hasValue(dotNetObject.hasZ)) {
        properties.hasZ = dotNetObject.hasZ;
    }
    if (hasValue(dotNetObject.points) && dotNetObject.points.length > 0) {
        properties.points = dotNetObject.points;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference);
    }
    let jsMultipoint = new Multipoint(properties);
    
    return jsMultipoint;
}     

export function buildDotNetMultipoint(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMultipoint: any = {
        type: 'multipoint'
    };

    if (hasValue(jsObject.extent)) {
        dotNetMultipoint.extent = buildDotNetExtent(jsObject.extent);
    }

    if (hasValue(jsObject.cache)) {
        dotNetMultipoint.cache = jsObject.cache;
    }

    if (hasValue(jsObject.hasM)) {
        dotNetMultipoint.hasM = jsObject.hasM;
    }

    if (hasValue(jsObject.hasZ)) {
        dotNetMultipoint.hasZ = jsObject.hasZ;
    }

    if (hasValue(jsObject.points)) {
        dotNetMultipoint.points = jsObject.points;
    }

    if (hasValue(jsObject.spatialReference)) {
        dotNetMultipoint.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }

    return dotNetMultipoint;
}
