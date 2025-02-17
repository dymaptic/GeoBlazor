import * as engine from "@arcgis/core/geometry/geometryEngine";
import Geometry from "@arcgis/core/geometry/Geometry";
import Polygon from "@arcgis/core/geometry/Polygon";
import Polyline from "@arcgis/core/geometry/Polyline";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Point from "@arcgis/core/geometry/Point";
import {DotNetExtent, DotNetGeometry, DotNetPoint, DotNetPolygon, DotNetPolyline} from "./definitions";
import Extent from "@arcgis/core/geometry/Extent";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import LinearUnits = __esri.LinearUnits;
import SpatialReferenceInfo = __esri.SpatialReferenceInfo;
import AreaUnits = __esri.AreaUnits;
import NearestPointResult = __esri.NearestPointResult;

export default class GeometryEngineWrapper {
    private dotNetRef: any;

    constructor(dotNetReference) {
        this.dotNetRef = dotNetReference;
    }

    async buffer(geometries: DotNetGeometry | Array<DotNetGeometry>, distances: number | Array<number>,
                 unit: LinearUnits | null, unionResults: boolean | null): Promise<DotNetPolygon | DotNetPolygon[] | null> {
        let jsGeometries: Geometry | Array<Geometry>;
        let jsBuffer: Polygon | Polygon[];
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometries) as Geometry;
        }
        if (unit === null || unit === undefined) {
            if (unionResults === null || unionResults === undefined) {
                jsBuffer = engine.buffer(jsGeometries, distances);
            } else {
                jsBuffer = engine.buffer(jsGeometries, distances, undefined, unionResults as boolean);
            }
        } else if (unionResults === null || unionResults === undefined) {
            jsBuffer = engine.buffer(jsGeometries, distances, unit as LinearUnits);
        } else {
            jsBuffer = engine.buffer(jsGeometries, distances, unit, unionResults);
        }

        if (Array.isArray(jsBuffer)) {
            return jsBuffer.map(g => buildDotNetPolygon(g) as DotNetPolygon);
        }
        return buildDotNetPolygon(jsBuffer);

    }

    async clip(geometry: DotNetGeometry, extent: DotNetExtent): Promise<DotNetGeometry | null> {
        let jsClip = engine.clip(buildJsGeometry(geometry) as Geometry, buildJsExtent(extent, null));
        return buildDotNetGeometry(jsClip);

    }

    async contains(containerGeometry: DotNetGeometry, insideGeometry: DotNetGeometry): Promise<boolean | null> {
        return engine.contains(buildJsGeometry(containerGeometry) as Geometry,
            buildJsGeometry(insideGeometry) as Geometry);

    }

    async convexHull(geometries: Array<DotNetGeometry> | DotNetGeometry, merge: boolean | null):
        Promise<DotNetGeometry | Array<DotNetGeometry> | null> {
        let jsGeometries: Geometry | Array<Geometry>;
        let jsHull: Geometry | Array<Geometry>;
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometries) as Geometry;
        }
        if (merge === null) {
            jsHull = engine.convexHull(jsGeometries);
        } else {
            jsHull = engine.convexHull(jsGeometries, merge);
        }

        if (Array.isArray(jsHull)) {
            return jsHull.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }
        return buildDotNetGeometry(jsHull);

    }

    async crosses(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.crosses(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);

    }

    async cut(geometry: DotNetGeometry, cutter: DotNetPolyline): Promise<Array<DotNetGeometry> | null> {
        let jsCut = engine.cut(buildJsGeometry(geometry) as Geometry, buildJsPolyline(cutter) as Polyline);
        return jsCut.map(g => buildDotNetGeometry(g) as DotNetGeometry);

    }

    async densify(geometry: DotNetGeometry, maxSegmentLength: number, maxSegmentLengthUnit: LinearUnits | null)
        : Promise<DotNetGeometry | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsDensified: Geometry;
        if (maxSegmentLengthUnit === null) {
            jsDensified = engine.densify(jsGeometry, maxSegmentLength);
        } else {
            jsDensified = engine.densify(jsGeometry, maxSegmentLength, maxSegmentLengthUnit);
        }

        return buildDotNetGeometry(jsDensified);

    }

    async difference(geometries: Array<DotNetGeometry> | DotNetGeometry, subtractor: DotNetGeometry)
        : Promise<Array<DotNetGeometry> | DotNetGeometry | null> {
        let jsGeometries: Geometry | Array<Geometry>;
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometries) as Geometry;
        }

        let jsDifference = engine.difference(jsGeometries, buildJsGeometry(subtractor) as Geometry);
        if (Array.isArray(jsDifference)) {
            return jsDifference.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        return buildDotNetGeometry(jsDifference);

    }

    async disjoint(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.disjoint(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);

    }

    async distance(geometry1: DotNetGeometry, geometry2: DotNetGeometry, distanceUnit: LinearUnits | null)
        : Promise<number | null> {
        let jsGeometry1 = buildJsGeometry(geometry1) as Geometry;
        let jsGeometry2 = buildJsGeometry(geometry2) as Geometry;
        if (distanceUnit === null) {
            return engine.distance(jsGeometry1, jsGeometry2);
        }
        return engine.distance(jsGeometry1, jsGeometry2, distanceUnit);

    }

    async equals(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.equals(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);

    }

    async extendedSpatialReferenceInfo(spatialReference: SpatialReference)
        : Promise<SpatialReferenceInfo | null> {
        return engine.extendedSpatialReferenceInfo(spatialReference);

    }

    async flipHorizontal(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<DotNetGeometry | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsFlip: Geometry;
        if (flipOrigin === null) {
            jsFlip = engine.flipHorizontal(jsGeometry);
        } else {
            let jsOrigin = buildJsPoint(flipOrigin) as Point;
            jsFlip = engine.flipHorizontal(jsGeometry, jsOrigin);
        }

        return buildDotNetGeometry(jsFlip);

    }

    async flipVertical(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<DotNetGeometry | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsFlip: Geometry;
        if (flipOrigin === null) {
            jsFlip = engine.flipVertical(jsGeometry);
        } else {
            let jsOrigin = buildJsPoint(flipOrigin) as Point;
            jsFlip = engine.flipVertical(jsGeometry, jsOrigin);
        }

        return buildDotNetGeometry(jsFlip);

    }

    async generalize(geometry: DotNetGeometry, maxDeviation: number, removeDegenerateParts: boolean | null,
                     maxDeviationUnit: LinearUnits | null): Promise<DotNetGeometry | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsGeneralize: Geometry;
        if (removeDegenerateParts === null) {
            if (maxDeviationUnit === null) {
                jsGeneralize = engine.generalize(jsGeometry, maxDeviation);
            } else {
                jsGeneralize = engine.generalize(jsGeometry, maxDeviation, undefined, maxDeviationUnit);
            }
        } else if (maxDeviationUnit === null) {
            jsGeneralize = engine.generalize(jsGeometry, maxDeviation, removeDegenerateParts);
        } else {
            jsGeneralize = engine.generalize(jsGeometry, maxDeviation, removeDegenerateParts, maxDeviationUnit);
        }

        return buildDotNetGeometry(jsGeneralize);

    }

    async geodesicArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<number | null> {
        if (unit === null) {
            return engine.geodesicArea(buildJsPolygon(geometry) as Polygon);
        }
        return engine.geodesicArea(buildJsPolygon(geometry) as Polygon, unit);

    }

    async geodesicBuffer(geometries: Array<DotNetGeometry> | DotNetGeometry, distances: Array<number> | number,
                         unit: LinearUnits | null, unionResults: boolean | null)
        : Promise<DotNetPolygon | DotNetPolygon[] | null> {
        let jsGeometries: Geometry | Array<Geometry>;
        let jsBuffer: Polygon | Polygon[];
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometries) as Geometry;
        }
        if (unit === null) {
            if (unionResults === null) {
                jsBuffer = engine.geodesicBuffer(jsGeometries, distances);
            } else {
                jsBuffer = engine.geodesicBuffer(jsGeometries, distances, undefined, unionResults as boolean);
            }
        } else if (unionResults === null) {
            jsBuffer = engine.geodesicBuffer(jsGeometries, distances, unit);
        } else {
            jsBuffer = engine.geodesicBuffer(jsGeometries, distances, unit as LinearUnits, unionResults as boolean);
        }

        if (Array.isArray(jsBuffer)) {
            return jsBuffer.map(g => buildDotNetPolygon(g) as DotNetPolygon);
        }

        return buildDotNetPolygon(jsBuffer);

    }

    async geodesicDensify(geometry: DotNetGeometry, maxSegmentLength: number,
                          maxSegmentLengthUnit: LinearUnits | null): Promise<DotNetGeometry | null> {
        let jsDensify: Geometry;
        if (maxSegmentLengthUnit === null) {
            jsDensify = engine.geodesicDensify(buildJsGeometry(geometry) as Polygon | Polyline, maxSegmentLength);
        } else {
            jsDensify = engine.geodesicDensify(buildJsGeometry(geometry) as Polygon | Polyline, maxSegmentLength, maxSegmentLengthUnit);
        }

        return buildDotNetGeometry(jsDensify);

    }

    async geodesicLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        if (unit === null) {
            return engine.geodesicLength(buildJsGeometry(geometry) as Geometry);
        }
        return engine.geodesicLength(buildJsGeometry(geometry) as Geometry, unit);

    }

    async intersect(geometry1: DotNetGeometry | Array<DotNetGeometry>, geometry2: DotNetGeometry)
        : Promise<DotNetGeometry | Array<DotNetGeometry> | null> {
        let jsGeometries: Geometry | Array<Geometry>;
        if (Array.isArray(geometry1)) {
            jsGeometries = [];
            geometry1.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometry1) as Geometry;
        }
        let jsIntersection = engine.intersect(jsGeometries, buildJsGeometry(geometry2) as Geometry);

        if (Array.isArray(jsIntersection)) {
            return jsIntersection.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        return buildDotNetGeometry(jsIntersection);

    }

    async intersects(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.intersects(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);

    }

    async isSimple(geometry: DotNetGeometry): Promise<boolean | null> {
        return engine.isSimple(buildJsGeometry(geometry) as Geometry);

    }

    async nearestCoordinate(geometry: DotNetGeometry, inputPoint: DotNetPoint)
        : Promise<NearestPointResult | null> {
        return engine.nearestCoordinate(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point);

    }

    async nearestVertex(geometry: DotNetGeometry, inputPoint: DotNetPoint)
        : Promise<any | null> {
        let jsResult = engine.nearestVertex(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point);
        return {
            coordinate: buildDotNetPoint(jsResult.coordinate) as DotNetPoint,
            distance: jsResult.distance,
            vertexIndex: jsResult.vertexIndex,
            isEmpty: jsResult.isEmpty
        }

    }

    async nearestVertices(geometry: DotNetGeometry, inputPoint: DotNetPoint, searchRadius: number,
                          maxVertexCountToReturn: number)
        : Promise<Array<any> | null> {
        let jsResult = engine.nearestVertices(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point,
            searchRadius, maxVertexCountToReturn);
        return jsResult.map(r => {
            return {
                coordinate: buildDotNetPoint(r.coordinate) as DotNetPoint,
                distance: r.distance,
                vertexIndex: r.vertexIndex,
                isEmpty: r.isEmpty
            }
        });

    }

    async offset(geometries: Array<DotNetGeometry> | DotNetGeometry, offsetDistance: number,
                 offsetUnit: LinearUnits | null | undefined, joinType: any | null | undefined,
                 bevelRatio: number | null | undefined, flattenError: number | null | undefined)
        : Promise<DotNetGeometry | Array<DotNetGeometry> | null> {
        let jsGeometries: Geometry | Array<Geometry>
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(geometries as DotNetGeometry) as Geometry;
        }
        if (offsetUnit === null) {
            offsetUnit = void 0;
        }
        if (joinType === null) {
            joinType = void 0;
        }
        if (bevelRatio === null) {
            bevelRatio = void 0;
        }
        if (flattenError === null) {
            flattenError = void 0;
        }
        let jsOffset = engine.offset(jsGeometries, offsetDistance, offsetUnit, joinType as any, bevelRatio, flattenError);
        if (Array.isArray(jsOffset)) {
            return jsOffset.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        return buildDotNetGeometry(jsOffset);

    }

    async overlaps(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.overlaps(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);

    }

    async planarArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<number | null> {
        if (unit === null) {
            return engine.planarArea(buildJsPolygon(geometry) as Polygon);
        }
        return engine.planarArea(buildJsPolygon(geometry) as Polygon, unit);

    }

    async planarLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        if (unit === null) {
            return engine.planarLength(buildJsGeometry(geometry) as Geometry);
        }
        return engine.planarLength(buildJsGeometry(geometry) as Geometry, unit);

    }

    async relate(geometry1: DotNetGeometry, geometry2: DotNetGeometry, relation: string)
        : Promise<boolean | null> {
        return engine.relate(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry, relation);

    }

    async rotate(geometry: DotNetGeometry, angle: number, rotationOrigin: DotNetPoint): Promise<DotNetGeometry | null> {
        let jsRotated = engine.rotate(buildJsGeometry(geometry) as Geometry, angle, buildJsPoint(rotationOrigin) as Point);
        return buildDotNetGeometry(jsRotated);

    }

    async simplify(geometry: DotNetGeometry): Promise<DotNetGeometry | null> {
        let jsSimplified = engine.simplify(buildJsGeometry(geometry) as Geometry);
        return buildDotNetGeometry(jsSimplified);

    }

    async symmetricDifference(leftGeometry: Array<DotNetGeometry> | DotNetGeometry, rightGeometry: DotNetGeometry)
        : Promise<DotNetGeometry | Array<DotNetGeometry> | null> {
        let jsGeometries: Geometry | Array<Geometry>
        if (Array.isArray(leftGeometry)) {
            jsGeometries = [];
            leftGeometry.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            jsGeometries = buildJsGeometry(leftGeometry) as Geometry;
        }
        let jsDifference = engine.symmetricDifference(jsGeometries, buildJsGeometry(rightGeometry) as Geometry);

        if (Array.isArray(jsDifference)) {
            return jsDifference.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        return buildDotNetGeometry(jsDifference);

    }

    async touches(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        return engine.touches(buildJsGeometry(geometry1) as Geometry,
            buildJsGeometry(geometry2) as Geometry);

    }

    async union(...args: Array<any>): Promise<DotNetGeometry | null> {
        let jsGeometries: Array<Geometry> = [];
        if (Array.isArray(args[0])) {
            args[0].forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        } else {
            args.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
        }

        let jsUnion = engine.union(jsGeometries);
        return buildDotNetGeometry(jsUnion);

    }

    async within(innerGeometry: DotNetGeometry, outerGeometry: DotNetGeometry): Promise<boolean | null> {
        return engine.within(buildJsGeometry(innerGeometry) as Geometry,
            buildJsGeometry(outerGeometry) as Geometry);

    }

    async fromJSON(json: string, typeName: string): Promise<DotNetGeometry | null> {
        let jsGeometry: Geometry;
        let jsonObject = JSON.parse(json);
        switch (typeName) {
            case "Point":
                jsGeometry = Point.fromJSON(jsonObject);
                break;
            case "PolyLine":
                jsGeometry = Polyline.fromJSON(jsonObject);
                break;
            case "Polygon":
                jsGeometry = Polygon.fromJSON(jsonObject);
                break;
            case "Extent":
                jsGeometry = Extent.fromJSON(jsonObject);
                break;
            default:
                throw new Error("Invalid geometry type");
        }
        return buildDotNetGeometry(jsGeometry);

    }

    async toJSON(geometry: any): Promise<string | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        return JSON.stringify(jsGeometry.toJSON());

    }

    async clone(geometry: DotNetGeometry): Promise<DotNetGeometry | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let clonedGeometry = jsGeometry.clone();
        return buildDotNetGeometry(clonedGeometry);

    }

    async centerExtentAt(extent: DotNetExtent, center: DotNetPoint): Promise<DotNetExtent | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let newExtent = jsExtent.centerAt(buildJsPoint(center) as Point);
        return buildDotNetExtent(newExtent);

    }

    async expand(extent: DotNetExtent, factor: number): Promise<DotNetExtent | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let newExtent = jsExtent.expand(factor);
        return buildDotNetExtent(newExtent);

    }

    async normalizeExtent(extent: DotNetExtent): Promise<DotNetExtent[] | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let newExtents = jsExtent.normalize();
        return newExtents.map(e => buildDotNetExtent(e) as DotNetExtent);
    }

    async offsetExtent(extent: DotNetExtent, dx: number, dy: number, dz: number): Promise<DotNetExtent | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let newExtent = jsExtent.offset(dx, dy, dz);
        return buildDotNetExtent(newExtent);
    }

    async normalizePoint(point: DotNetPoint): Promise<DotNetPoint | null> {
        let jsPoint = buildJsPoint(point) as Point;
        let newPoint = jsPoint.normalize();
        return buildDotNetPoint(newPoint);
    }

    async addPath(polyline: DotNetPolyline, path: any): Promise<DotNetPolyline | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let newPolyline = jsPolyline.addPath(path);
        return buildDotNetPolyline(newPolyline);
    }

    async getPointOnPolyline(polyline: DotNetPolyline, pathIndex: number, pointIndex: number)
        : Promise<DotNetPoint | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let jsPoint = jsPolyline.getPoint(pathIndex, pointIndex);
        return buildDotNetPoint(jsPoint);
    }

    async insertPointOnPolyline(polyline: DotNetPolyline, pathIndex: number, pointIndex: number, point: DotNetPoint)
        : Promise<DotNetPolyline | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolyline = jsPolyline.insertPoint(pathIndex, pointIndex, jsPoint);
        return buildDotNetPolyline(newPolyline);
    }

    async removePath(polyline: DotNetPolyline, pathIndex: number): Promise<any | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let path = jsPolyline.removePath(pathIndex);
        let newLine = buildDotNetPolyline(jsPolyline) as DotNetPolyline;
        return {
            polyLine: newLine,
            path: path.map(p => buildDotNetPoint(p) as DotNetPoint)
        }
    }

    async removePointOnPolyline(polyline: DotNetPolyline, pathIndex: number, pointIndex: number): Promise<any | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let point = jsPolyline.removePoint(pathIndex, pointIndex);
        return {
            polyLine: buildDotNetPolyline(jsPolyline) as DotNetPolyline,
            point: buildDotNetPoint(point) as DotNetPoint
        };
    }

    async setPointOnPolyline(polyline: DotNetPolyline, pathIndex: number, pointIndex: number, point: DotNetPoint)
        : Promise<DotNetPolyline | null> {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolyline = jsPolyline.setPoint(pathIndex, pointIndex, jsPoint);
        return buildDotNetPolyline(newPolyline);
    }

    async addRing(polygon: DotNetPolygon, ring: any): Promise<DotNetPolygon | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let newPolygon = jsPolygon.addRing(ring);
        return buildDotNetPolygon(newPolygon);
    }

    async fromExtent(extent: DotNetExtent): Promise<DotNetPolygon | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let jsPolygon = Polygon.fromExtent(jsExtent);
        return buildDotNetPolygon(jsPolygon);
    }

    async getPointOnPolygon(polygon: DotNetPolygon, ringIndex: number, pointIndex: number): Promise<DotNetPoint | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let jsPoint = jsPolygon.getPoint(ringIndex, pointIndex);
        return buildDotNetPoint(jsPoint);
    }

    async insertPointOnPolygon(polygon: DotNetPolygon, ringIndex: number, pointIndex: number, point: DotNetPoint)
        : Promise<DotNetPolygon | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolygon = jsPolygon.insertPoint(ringIndex, pointIndex, jsPoint);
        return buildDotNetPolygon(newPolygon);
    }


    async isClockwise(polygon: DotNetPolygon, ring: any): Promise<boolean | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        return jsPolygon.isClockwise(ring);
    }

    async removePointOnPolygon(polygon: DotNetPolygon, ringIndex: number, pointIndex: number): Promise<any | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let point = jsPolygon.removePoint(ringIndex, pointIndex);
        return {
            polygon: buildDotNetPolygon(jsPolygon) as DotNetPolygon,
            point: buildDotNetPoint(point[0]) as DotNetPoint
        };
    }

    async removeRing(polygon: DotNetPolygon, index: number): Promise<any | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let ring = jsPolygon.removeRing(index);
        return {
            polygon: buildDotNetPolygon(jsPolygon) as DotNetPolygon,
            ring: ring.map(p => buildDotNetPoint(p) as DotNetPoint)
        };
    }

    async setPointOnPolygon(polygon: DotNetPolygon, ringIndex: number, pointIndex: number, point: DotNetPoint)
        : Promise<DotNetPolygon | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolygon = jsPolygon.setPoint(ringIndex, pointIndex, jsPoint);
        return buildDotNetPolygon(newPolygon);
    }

    getExtentCenter(extent: DotNetExtent): DotNetPoint {
        let jsExtent = buildJsExtent(extent, null);
        return buildDotNetPoint(jsExtent.center) as DotNetPoint;
    }

    getExtentHeight(extent: DotNetExtent): number {
        let jsExtent = buildJsExtent(extent, null);
        return jsExtent.height;
    }

    getExtentWidth(extent: DotNetExtent): number {
        let jsExtent = buildJsExtent(extent, null);
        return jsExtent.width;
    }
}
