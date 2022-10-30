import {
    DotNetExtent,
    DotNetFeature, DotNetGeographicTransformation, DotNetGeographicTransformationStep, DotNetGeometry,
    DotNetGraphic,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline, DotNetSpatialReference,
    DotNetLayerView
} from "ArcGisDefinitions";
import Point from "@arcgis/core/geometry/Point";
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";
import Extent from "@arcgis/core/geometry/Extent";
import Geometry from "@arcgis/core/geometry/Geometry";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import GeographicTransformation from "@arcgis/core/geometry/support/GeographicTransformation";
import LayerView from "@arcgis/core/views/layers/LayerView";

export function buildDotNetGraphic(graphic: any): DotNetGraphic {
    let dotNetGraphic = {} as DotNetGraphic;
    dotNetGraphic.uid = graphic.uid;

    switch (graphic.geometry?.type) {
        case 'point':
            dotNetGraphic.geometry = buildDotNetPoint(graphic.geometry);
            break;
        case 'polyline':
            dotNetGraphic.geometry = buildDotNetPolyline(graphic.geometry);
            break;
        case 'polygon':
            dotNetGraphic.geometry = buildDotNetPolygon(graphic.geometry);
            break;
        case 'extent':
            dotNetGraphic.geometry = buildDotNetExtent(graphic.geometry);
            break;
    }
    return dotNetGraphic;
}

export function buildDotNetFeature(feature: any): DotNetFeature {
    let dotNetFeature = {
        attributes: feature.attributes
    } as DotNetFeature;
    dotNetFeature.uid = feature.uid;

    switch (feature.geometry?.type) {
        case 'point':
            dotNetFeature.geometry = buildDotNetPoint(feature.geometry);
            break;
        case 'polyline':
            dotNetFeature.geometry = buildDotNetPolyline(feature.geometry);
            break;
        case 'polygon':
            dotNetFeature.geometry = buildDotNetPolygon(feature.geometry);
            break;
        case 'extent':
            dotNetFeature.geometry = buildDotNetExtent(feature.geometry);
            break;
    }
    return dotNetFeature;
}

export function buildDotNetGeometry(geometry: Geometry): DotNetGeometry | null {
    switch (geometry.type) {
        case "point":
            return buildDotNetPoint(geometry as Point);
        case "polyline":
            return buildDotNetPolyline(geometry as Polyline);
        case "polygon":
            return buildDotNetPolygon(geometry as Polygon);
        case "extent":
            return buildDotNetExtent(geometry as Extent);
    }
    
    return geometry;
}

export function buildDotNetPoint(point: Point): DotNetPoint {
    return {
        type: 'point',
        latitude: point.latitude,
        longitude: point.longitude,
        hasM: point.hasM,
        hasZ: point.hasZ,
        extent: buildDotNetExtent(point.extent),
        x: point.x,
        y: point.y,
        spatialReference: point.spatialReference
    } as DotNetPoint
}

export function buildDotNetPolyline(polyline: Polyline): DotNetPolyline | null {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: polyline.spatialReference
    } as DotNetPolyline
}

export function buildDotNetPolygon(polygon: Polygon): DotNetPolygon | null {
    if (polygon === undefined || polygon === null) return null;
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: buildDotNetExtent(polygon.extent),
        spatialReference: polygon.spatialReference
    } as DotNetPolygon
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
        spatialReference: extent.spatialReference
    } as DotNetExtent;
}

export function buildDotNetSpatialReference(spatialReference: SpatialReference): DotNetSpatialReference | null {
    if (spatialReference === undefined || spatialReference === null) return null;
    
    return {
        isGeographic: spatialReference.isGeographic,
        isWebMercator: spatialReference.isWebMercator,
        isWgs84: spatialReference.isWGS84,
        isWrappable: spatialReference.isWrappable,
        wkid: spatialReference.wkid,
        wkt: spatialReference.wkt,
        imageCoordinateSystem: spatialReference.imageCoordinateSystem
    } as DotNetSpatialReference;
}


export function buildDotNetGeographicTransformation(geographicTransformation: GeographicTransformation): 
    DotNetGeographicTransformation | null {
    if (geographicTransformation === undefined || geographicTransformation === null) return null;
    let steps: Array<DotNetGeographicTransformationStep> = [];
    geographicTransformation.steps.forEach(s => {
        steps.push({
            isInverse: s.isInverse,
            wkid: s.wkid,
            wkt: s.wkt
        } as DotNetGeographicTransformationStep)
    });
    return {
        steps: steps
    } as DotNetGeographicTransformation;
}

export function buildDotNetLayerView(layerView: LayerView) : DotNetLayerView {
    return {
        layer: layerView.layer,
        spatialReferenceSupported: layerView.spatialReferenceSupported,
        suspended: layerView.suspended,
        updating: layerView.updating,
        visible: layerView.visible
    }
}