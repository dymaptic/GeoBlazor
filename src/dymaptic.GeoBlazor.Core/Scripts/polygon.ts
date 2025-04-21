import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {DotNetPolygon} from "./definitions";
import Polygon from "@arcgis/core/geometry/Polygon";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import {arcGisObjectRefs, copyValuesIfExists, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import Circle from "@arcgis/core/geometry/Circle";
import {buildDotNetPoint, buildJsPoint} from "./point";

export function buildDotNetPolygon(polygon: any): any {
    if (polygon === undefined || polygon === null) return null;
    let dnPolygon: any = {
        type: 'polygon'
    };
    
    if (hasValue(polygon.rings)) {
        dnPolygon.rings = polygon.rings;
    }
    
    if (hasValue(polygon.spatialReference)) {
        dnPolygon.spatialReference = buildDotNetSpatialReference(polygon.spatialReference);
    }

    if (hasValue(polygon.extent)) {
        dnPolygon.extent = buildDotNetExtent(polygon.extent);
    }
    
    if (hasValue(polygon.hasM)) {
        dnPolygon.hasM = polygon.hasM;
    }
    
    if (hasValue(polygon.hasZ)) {
        dnPolygon.hasZ = polygon.hasZ;
    }
    
    if (hasValue(polygon.centroid)) {
        dnPolygon.centroid = buildDotNetPoint(polygon.centroid);
    }
    
    // circle properties
    if (hasValue(polygon.center)) {
        dnPolygon.center = buildDotNetPoint(polygon.center);
    }
    
    if (hasValue(polygon.radius)) {
        dnPolygon.radius = polygon.radius;
    }
    
    if (hasValue(polygon.geodesic)) {
        dnPolygon.geodesic = polygon.geodesic;
    }
    
    if (hasValue(polygon.isSelfIntersecting)) {
        dnPolygon.isSelfIntersecting = polygon.isSelfIntersecting;
    }
    
    if (hasValue(polygon.numberOfPoints)) {
        dnPolygon.numberOfPoints = polygon.numberOfPoints;
    }
    
    if (hasValue(polygon.radiusUnit)) {
        dnPolygon.radiusUnit = polygon.radiusUnit;
    }
    
    return dnPolygon;
}

export function buildJsPolygon(dnPolygon): any {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    
    let properties : any = {};
    if (hasValue(dnPolygon.rings)) {
        properties.rings = buildJsPathsOrRings(dnPolygon.rings);
    }
    if (hasValue(dnPolygon.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    }
    if (hasValue(dnPolygon.hasM)) {
        properties.hasM = dnPolygon.hasM;
    }
    if (hasValue(dnPolygon.hasZ)) {
        properties.hasZ = dnPolygon.hasZ;
    }
    if (hasValue(dnPolygon.centroid)) {
        properties.centroid = buildJsPoint(dnPolygon.centroid);
    }

    let polygon: Polygon;
    if (hasValue(dnPolygon.center) && hasValue(dnPolygon.radius)) {
        properties.center = buildJsPoint(dnPolygon.center);
        properties.radius = dnPolygon.radius;
        if (hasValue(dnPolygon.geodesic)) {
            properties.geodesic = dnPolygon.geodesic;
        }
        if (hasValue(dnPolygon.numberOfPoints)) {
            properties.numberOfPoints = dnPolygon.numberOfPoints;
        }
        if (hasValue(dnPolygon.radiusUnit)) {
            properties.radiusUnit = dnPolygon.radiusUnit;
        }
        polygon = new Circle(properties);
    } else {
        polygon = new Polygon(properties);
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(polygon);
    jsObjectRefs[dnPolygon.id] = jsObjectRef;
    arcGisObjectRefs[dnPolygon.id] = polygon;
    return polygon;
}

function buildJsPathsOrRings(pathsOrRings: any) {
    if (!hasValue(pathsOrRings)) return null;
    if (pathsOrRings[0].hasOwnProperty("points")) {
        let array: [][][] = [];
        for (let i = 0; i < pathsOrRings.length; i++) {
            let points = pathsOrRings[i].points;
            let pointsArray: [][] = [];
            for (let j = 0; j < points.length; j++) {
                pointsArray.push(points[j].coordinates);
            }
            array.push(pointsArray);
        }
        return array;
    }
    return pathsOrRings;
}
