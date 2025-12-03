import {DotNetExtent, IPropertyWrapper} from "./definitions";
import Extent from "@arcgis/core/geometry/Extent";
import {arcGisObjectRefs, buildJsStreamReference, copyValuesIfExists, hasValue, jsObjectRefs} from './geoBlazorCore';
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {buildJsPoint} from "./point";
import {buildJsGeometry} from "./geometry";

export default class ExtentWrapper implements IPropertyWrapper {
    public extent: Extent;
    
    constructor(extent: Extent) {
        this.extent = extent;
    }
    
    setProperty(prop: string, value: any): void {
        this.extent[prop] = value;
    }
    getProperty(prop: string) {
        return this.extent[prop];
    }
    unwrap() {
        return this.extent;
    }
    
    centerAt(point: any) {
        let jsPoint = buildJsPoint(point);
        let jsExtent = this.extent.centerAt(jsPoint);
        return buildDotNetExtent(jsExtent);
    }
    
    contains(geometry: any) {
        let jsGeometry = buildJsGeometry(geometry);
        return this.extent.contains(jsGeometry);
    }
    
    expand(factor: number) {
        let jsExtent = this.extent.expand(factor);
        return buildDotNetExtent(jsExtent);
    }
    
    intersection(extent: any) {
        let jsExtent = buildJsExtent(extent);
        let jsIntersection = this.extent.intersection(jsExtent);
        return buildDotNetExtent(jsIntersection);
    }
    
    intersects(geometry: any) {
        let jsGeometry = buildJsGeometry(geometry);
        return this.extent.intersects(jsGeometry);
    }
    
    normalize() {
        let jsNormalized = this.extent.normalize();
        return jsNormalized?.map(e => buildDotNetExtent(e));
    }
    
    offset(dx, dy, dz) {
        let jsOffset = this.extent.offset(dx, dy, dz);
        return buildDotNetExtent(jsOffset);
    }
    
    union(extent: any) {
        let jsExtent = buildJsExtent(extent);
        let jsUnion = this.extent.union(jsExtent);
        return buildDotNetExtent(jsUnion);
    }
}

export function buildJsExtent(dotNetExtent: any, currentSpatialReference: any | null = null): any {
    if (!hasValue(dotNetExtent)) {
        return null;
    }
    
    let properties: any = {};
    copyValuesIfExists(dotNetExtent, properties, 'xmax', 'xmin', 'ymax', 'ymin', 'zmax', 'zmin', 'mmax', 'mmin');

    if (hasValue(dotNetExtent.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        properties.spatialReference = currentSpatialReference;
    }
    let extent = new Extent(properties);
    arcGisObjectRefs[dotNetExtent.id] = extent;
    jsObjectRefs[dotNetExtent.id] = new ExtentWrapper(extent);
    
    return extent;
}

export function buildDotNetExtent(extent: any): any {
    if (extent === undefined || extent === null) return null;
    return {
        type: 'extent',
        xmin: extent.xmin,
        ymin: extent.ymin,
        xmax: extent.xmax,
        ymax: extent.ymax,
        zmin: extent.zmin,
        zmax: extent.zmax,
        mmin: extent.mmin,
        mmax: extent.mmax,
        hasM: extent.hasM,
        hasZ: extent.hasZ,
        spatialReference: buildDotNetSpatialReference(extent.spatialReference)
    } as DotNetExtent;
}
