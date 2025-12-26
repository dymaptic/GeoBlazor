import PolylineGenerated from './polyline.gb';
import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import Polyline from "@arcgis/core/geometry/Polyline";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import * as simplifyOperator from '@arcgis/core/geometry/operators/simplifyOperator';

export function buildDotNetPolyline(polyline: any): any {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: buildDotNetSpatialReference(polyline.spatialReference),
        isSimple: simplifyOperator.isSimple(polyline)
    };
}

export function buildJsPolyline(dnPolyline: any): any {
    if (dnPolyline === undefined || dnPolyline === null) return null;
    let properties: any = {};
    if (hasValue(dnPolyline.paths)) {
        properties.paths = buildJsPathsOrRings(dnPolyline.paths);
    }
    if (hasValue(dnPolyline.hasZ)) {
        properties.hasZ = dnPolyline.hasZ;
    }
    if (hasValue(dnPolyline.hasM)) {
        properties.hasM = dnPolyline.hasM;
    }
    if (hasValue(dnPolyline.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dnPolyline.spatialReference);
    }
    let polyline = new Polyline(properties);
    let jsObjectRef = DotNet.createJSObjectReference(polyline);
    jsObjectRefs[dnPolyline.id] = jsObjectRef;
    arcGisObjectRefs[dnPolyline.id] = polyline;
    
    return polyline;
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

export default class PolylineWrapper extends PolylineGenerated {

    constructor(component: Polyline) {
        super(component);
    }
    
}

