import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {DotNetPolygon} from "./definitions";
import Polygon from "@arcgis/core/geometry/Polygon";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import {arcGisObjectRefs, copyValuesIfExists, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildDotNetPolygon(polygon: any): any {
    if (polygon === undefined || polygon === null) return null;
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: buildDotNetExtent(polygon.extent),
        spatialReference: buildDotNetSpatialReference(polygon.spatialReference)
    };
}

export function buildJsPolygon(dnPolygon): any {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    let properties : any = {};
    if (hasValue(dnPolygon.rings)) {
        properties.rings = buildJsPathsOrRings(dnPolygon.rings);
    }
    if (hasValue(dnPolygon.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    } else {
        properties.spatialReference = new SpatialReference({wkid: 4326});
    }
    if (hasValue(dnPolygon.hasM)) {
        properties.hasM = dnPolygon.hasM;
    }
    if (hasValue(dnPolygon.hasZ)) {
        properties.hasZ = dnPolygon.hasZ;
    }
    let polygon = new Polygon(properties);
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
