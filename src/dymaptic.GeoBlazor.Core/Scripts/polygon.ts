import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import Polygon from "@arcgis/core/geometry/Polygon";
import Point from "@arcgis/core/geometry/Point";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import Circle from "@arcgis/core/geometry/Circle";
import {buildDotNetPoint, buildJsPoint} from "./point";
import * as simplifyOperator from '@arcgis/core/geometry/operators/simplifyOperator';
import BaseComponent from "./baseComponent";
import {DotNetPoint, DotNetPolygon} from "./definitions";

export default class PolygonWrapper extends BaseComponent {
    component: Polygon;

    constructor(component: Polygon) {
        super();
        this.component = component;
    }
    
    addRing(points: DotNetPoint[]): DotNetPolygon {
        let jsPoints = points.map(buildJsPoint);
        let jsResult = this.component.addRing(jsPoints);
        return buildDotNetPolygon(jsResult);
    }
    
    contains(point: DotNetPoint): boolean {
        let jsPoint = buildJsPoint(point) as Point;
        return this.component.contains(jsPoint);
    }
    
    getPoint(ringIndex: number, pointIndex: number): DotNetPoint | null {
        let jsPoint = this.component.getPoint(ringIndex, pointIndex);
        return buildDotNetPoint(jsPoint);
    }
    
    insertPoint(ringIndex: number, pointIndex: number, dotNetPoint: DotNetPoint): DotNetPolygon {
        let jsPoint = buildJsPoint(dotNetPoint) as Point;
        let jsResult = this.component.insertPoint(ringIndex, pointIndex, jsPoint);
        return buildDotNetPoint(jsResult);
    }
    
    isClockwise(ring: DotNetPoint[]): boolean {
        let jsRing = ring.map(buildJsPoint);
        return this.component.isClockwise(jsRing);
    }

    removePoint(ringIndex: number, pointIndex: number): DotNetPoint | null {
        let jsPoint = this.component.removePoint(ringIndex, pointIndex);
        return buildDotNetPoint(jsPoint);
    }
    
    removeRing(index: number): DotNetPoint[] | null {
        let jsRing = this.component.removeRing(index);
        if (!jsRing) {
            return null;
        }
        
        return jsRing.map(buildJsPoint);
    }

    setPoint(ringIndex: number, pointIndex: number, dotNetPoint: DotNetPoint): DotNetPolygon {
        let jsPoint = buildJsPoint(dotNetPoint) as Point;
        let jsResult = this.component.setPoint(ringIndex, pointIndex, jsPoint);
        return buildDotNetPoint(jsResult);
    }
}

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

    try {
        dnPolygon.isSimple = simplifyOperator.isSimple(polygon);
    } catch (e) {
        // invalid token
        console.error(e);
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

export function buildJsPolygon(dnPolygon: any): any {
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
    
    jsObjectRefs[dnPolygon.id] = new PolygonWrapper(polygon);
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
