import {DotNetExtent, DotNetSpatialReference} from "ArcGisDefinitions";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";

export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    let jsSpatialRef = new SpatialReference();
    if (dotNetSpatialReference.wkid !== null) {
        jsSpatialRef.wkid = dotNetSpatialReference.wkid;
    }
    if (dotNetSpatialReference.wkt !== null) {
        jsSpatialRef.wkt = dotNetSpatialReference.wkt;
    }

    return jsSpatialRef;
}

export function buildJsExtent(dotNetExtent: DotNetExtent): Extent {
    let extent = new Extent();
    if (dotNetExtent.xmax !== undefined && dotNetExtent.xmax !== null) {
        extent.xmax = dotNetExtent.xmax;
    }
    if (dotNetExtent.xmin !== undefined && dotNetExtent.xmin !== null) {
        extent.xmin = dotNetExtent.xmin;
    }
    if (dotNetExtent.ymax !== undefined && dotNetExtent.ymax !== null) {
        extent.ymax = dotNetExtent.ymax;
    }
    if (dotNetExtent.ymin !== undefined && dotNetExtent.ymin !== null) {
        extent.ymin = dotNetExtent.ymin;
    }
    if (dotNetExtent.zmax !== undefined && dotNetExtent.zmax !== null) {
        extent.zmax = dotNetExtent.zmax;
    }
    if (dotNetExtent.zmin !== undefined && dotNetExtent.zmin !== null) {
        extent.zmin = dotNetExtent.zmin;
    }
    if (dotNetExtent.mmax !== undefined && dotNetExtent.mmax !== null) {
        extent.mmax = dotNetExtent.mmax;
    }
    if (dotNetExtent.mmin !== undefined && dotNetExtent.mmin !== null) {
        extent.mmin = dotNetExtent.mmin;
    }
    
    return extent;
}