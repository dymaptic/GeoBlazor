import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import Polyline from "@arcgis/core/geometry/Polyline";
import Point from "@arcgis/core/geometry/Point";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import * as simplifyOperator from '@arcgis/core/geometry/operators/simplifyOperator';
import BaseComponent from "./baseComponent";
import {DotNetPoint} from "./definitions";
import {buildDotNetPoint, buildJsPoint} from "./point";

export default class PolylineWrapper extends BaseComponent {
    component: Polyline;

    constructor(component: Polyline) {
        super();
        this.component = component;
    }
    
    addPath(path: DotNetPoint[]): Polyline {
        let jsPath = path.map(buildJsPoint);
        let jsResult = this.component.addPath(jsPath);
        return buildDotNetPolyline(jsResult);
    }
    
    getPoint(pathIndex: number, pointIndex: number): DotNetPoint | null {
        let jsPoint = this.component.getPoint(pathIndex, pointIndex);
        return buildDotNetPoint(jsPoint);
    }
    
    insertPoint(pathIndex: number, pointIndex: number, dotNetPoint: DotNetPoint): Polyline {
        let jsPoint = buildJsPoint(dotNetPoint) as Point;
        let jsResult = this.component.insertPoint(pathIndex, pointIndex, jsPoint);
        return buildDotNetPolyline(jsResult);
    }
    
    removePath(index: number): DotNetPoint[] | null {
        let jsResult = this.component.removePath(index);
        if (!jsResult) {
            return null;
        }
        
        return jsResult.map(buildDotNetPoint);
    }
    
    removePoint(pathIndex: number, pointIndex: number): DotNetPoint | null {
        let jsResult = this.component.removePoint(pathIndex, pointIndex);
        return buildDotNetPoint(jsResult);
    }
    
    setPoint(pathIndex: number, pointIndex: number, dotNetPoint: DotNetPoint): Polyline {
        let jsPoint = buildJsPoint(dotNetPoint) as Point;
        let jsResult = this.component.setPoint(pathIndex, pointIndex, jsPoint);
        return buildDotNetPolyline(jsResult);
    }
}

export function buildDotNetPolyline(polyline: any): any {
    let dnPolyline: any = {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: buildDotNetSpatialReference(polyline.spatialReference)
    };
    
    try {
        dnPolyline.isSimple = simplifyOperator.isSimple(polyline);
    } catch (e) {
        // invalid token
        console.error(e);
    }
    
    return dnPolyline;
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
    
    jsObjectRefs[dnPolyline.id] = new PolylineWrapper(polyline);
    arcGisObjectRefs[dnPolyline.id] = polyline;
    
    return polyline;
}

export function buildJsPathsOrRings(pathsOrRings: any) {
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

export function buildProtobufPathsOrRings(pathsOrRings: any) {
    if (!hasValue(pathsOrRings)) return null;
    let array: any = [];
    for (let i = 0; i < pathsOrRings.length; i++) {
        let points = pathsOrRings[i];
        let ring : any = {
            points: []
        }
        
        for (let j = 0; j < points.length; j++) {
            ring.points.push({
                coordinates: points[j]
            })
        }
        array.push(ring);
    }
    
    return array;
}
