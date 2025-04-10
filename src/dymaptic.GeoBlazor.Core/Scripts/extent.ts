import {DotNetExtent, IPropertyWrapper} from "./definitions";
import Extent from "@arcgis/core/geometry/Extent";
import {arcGisObjectRefs, buildJsStreamReference, copyValuesIfExists, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {buildJsPoint} from "./point";
import {buildJsGeometry} from "./geometry";

export default class ExtentWrapper implements IPropertyWrapper {
    public extent: Extent;
    public geoBlazorId: string | null = null;
    
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
        let dotNetExtent = buildDotNetExtent(jsExtent);
        return dotNetExtent;
    }
    
    contains(geometry: any) {
        let jsGeometry = buildJsGeometry(geometry);
        let contains = this.extent.contains(jsGeometry);
        return contains;
    }
    
    expand(factor: number) {
        let jsExtent = this.extent.expand(factor);
        let dotNetExtent = buildDotNetExtent(jsExtent);
        return dotNetExtent;
    }
    
    intersection(extent: any) {
        let jsExtent = buildJsExtent(extent);
        let jsIntersection = this.extent.intersection(jsExtent);
        let dotNetIntersection = buildDotNetExtent(jsIntersection);
        return dotNetIntersection;
    }
    
    intersects(geometry: any) {
        let jsGeometry = buildJsGeometry(geometry);
        let intersects = this.extent.intersects(jsGeometry);
        return intersects;
    }
    
    normalize() {
        let jsNormalized = this.extent.normalize();
        let dotNetNormalized = jsNormalized?.map(buildDotNetExtent);
        return dotNetNormalized;
    }
    
    offset(dx, dy, dz) {
        let jsOffset = this.extent.offset(dx, dy, dz);
        let dotNetOffset = buildDotNetExtent(jsOffset);
        return dotNetOffset;
    }
    
    union(extent: any) {
        let jsExtent = buildJsExtent(extent);
        let jsUnion = this.extent.union(jsExtent);
        let dotNetUnion = buildDotNetExtent(jsUnion);
        return dotNetUnion;
    }
}

export function buildJsExtent(dotNetExtent, currentSpatialReference: any | null = null): any {
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

    let extentWrapper = new ExtentWrapper(extent);
    extentWrapper.geoBlazorId = dotNetExtent.id;

    let jsObjectRef = DotNet.createJSObjectReference(extentWrapper);
    jsObjectRefs[dotNetExtent.id] = jsObjectRef;

    try {
        let dnInstantiatedExtent = buildDotNetExtent(extent);
        let dnStream = buildJsStreamReference(dnInstantiatedExtent);
        dotNetExtent.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, dnStream);
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FeatureLayer', e);
    }
    
    return extent;
}

export function buildDotNetExtent(extent: Extent): DotNetExtent | null {
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
