import * as engine from "@arcgis/core/geometry/geometryEngine";
import Geometry from "@arcgis/core/geometry/Geometry";
import Polygon from "@arcgis/core/geometry/Polygon";
import Polyline from "@arcgis/core/geometry/Polyline";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Point from "@arcgis/core/geometry/Point";
import {buildJsExtent, buildJsGeometry, buildJsPoint, buildJsPolygon, buildJsPolyline} from "./jsBuilder";
import {DotNetExtent, DotNetGeometry, DotNetPoint, DotNetPolygon, DotNetPolyline} from "./definitions";
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
                 unit: LinearUnits | null, unionResults: boolean | null): Promise<Polygon | Array<Polygon> | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(geometries)) {
                jsGeometries = [];
                geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(geometries) as Geometry;
            }
            if (unit === null || unit === undefined) {
                if (unionResults === null || unionResults === undefined) {
                    return engine.buffer(jsGeometries, distances);
                }
                return engine.buffer(jsGeometries, distances, undefined, unionResults);
            } else if (unionResults === null || unionResults === undefined) {
                return engine.buffer(jsGeometries, distances, unit);
            }
            return engine.buffer(jsGeometries, distances, unit, unionResults);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async clip(geometry: DotNetGeometry, extent: DotNetExtent): Promise<Geometry | null> {
        try {
            return engine.clip(buildJsGeometry(geometry) as Geometry, buildJsExtent(extent, null));
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async contains(containerGeometry: DotNetGeometry, insideGeometry: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.contains(buildJsGeometry(containerGeometry) as Geometry,
                buildJsGeometry(insideGeometry) as Geometry);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async convexHull(geometries: Array<DotNetGeometry> | DotNetGeometry, merge: boolean | null):
        Promise<Geometry | Array<Geometry> | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(geometries)) {
                jsGeometries = [];
                geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(geometries) as Geometry;
            }
            if (merge === null) {
                return engine.convexHull(jsGeometries);
            }

            return engine.convexHull(jsGeometries, merge);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async crosses(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.crosses(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async cut(geometry: DotNetGeometry, cutter: DotNetPolyline): Promise<Array<Geometry> | null> {
        try {
            return engine.cut(buildJsGeometry(geometry) as Geometry, buildJsPolyline(cutter) as Polyline);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async densify(geometry: DotNetGeometry, maxSegmentLength: number, maxSegmentLengthUnit: LinearUnits | null)
        : Promise<Geometry | null> {
        try {
            let jsGeometry = buildJsGeometry(geometry) as Geometry
            if (maxSegmentLengthUnit === null) {
                return engine.densify(jsGeometry, maxSegmentLength);
            }
            return engine.densify(jsGeometry, maxSegmentLength, maxSegmentLengthUnit);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async difference(geometries: Array<DotNetGeometry> | DotNetGeometry, subtractor: DotNetGeometry)
        : Promise<Array<Geometry> | Geometry | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(geometries)) {
                jsGeometries = [];
                geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(geometries) as Geometry;
            }
            return engine.difference(jsGeometries, buildJsGeometry(subtractor) as Geometry);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async disjoint(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.disjoint(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async distance(geometry1: DotNetGeometry, geometry2: DotNetGeometry, distanceUnit: LinearUnits | null)
        : Promise<number | null> {
        try {
            let jsGeometry1 = buildJsGeometry(geometry1) as Geometry;
            let jsGeometry2 = buildJsGeometry(geometry2) as Geometry;
            if (distanceUnit === null) {
                return engine.distance(jsGeometry1, jsGeometry2);
            }
            return engine.distance(jsGeometry1, jsGeometry2, distanceUnit);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async equals(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.equals(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async extendedSpatialReferenceInfo(spatialReference: SpatialReference)
        : Promise<SpatialReferenceInfo | null> {
        try {
            return engine.extendedSpatialReferenceInfo(spatialReference);
        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async flipHorizontal(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<Geometry | null> {
        try {
            let jsGeometry = buildJsGeometry(geometry) as Geometry;
            if (flipOrigin === null) {
                return engine.flipHorizontal(jsGeometry);
            }
            let jsOrigin = buildJsPoint(flipOrigin) as Point;
            return engine.flipHorizontal(jsGeometry, jsOrigin);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async flipVertical(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<Geometry | null> {
        try {
            let jsGeometry = buildJsGeometry(geometry) as Geometry;
            if (flipOrigin === null) {
                return engine.flipVertical(jsGeometry);
            }
            let jsOrigin = buildJsPoint(flipOrigin) as Point;
            return engine.flipVertical(jsGeometry, jsOrigin);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async generalize(geometry: DotNetGeometry, maxDeviation: number, removeDegenerateParts: boolean | null,
                     maxDeviationUnit: LinearUnits | null): Promise<Geometry | null> {
        try {
            let jsGeometry = buildJsGeometry(geometry) as Geometry;
            if (removeDegenerateParts === null) {
                if (maxDeviationUnit === null) {
                    return engine.generalize(jsGeometry, maxDeviation);
                }
                return engine.generalize(jsGeometry, maxDeviation, undefined, maxDeviationUnit);
            } else if (maxDeviationUnit === null) {
                return engine.generalize(jsGeometry, maxDeviation, removeDegenerateParts);
            }
            return engine.generalize(jsGeometry, maxDeviation, removeDegenerateParts, maxDeviationUnit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async geodesicArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<number | null> {
        try {
            if (unit === null) {
                return engine.geodesicArea(buildJsPolygon(geometry) as Polygon);
            }
            return engine.geodesicArea(buildJsPolygon(geometry) as Polygon, unit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async geodesicBuffer(geometries: Array<DotNetGeometry> | DotNetGeometry, distances: Array<number> | number,
                         unit: LinearUnits | null, unionResults: boolean | null)
        : Promise<Array<Geometry> | Geometry | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(geometries)) {
                jsGeometries = [];
                geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(geometries) as Geometry;
            }
            if (unit === null) {
                if (unionResults === null) {
                    return engine.geodesicBuffer(jsGeometries, distances);
                }
                return engine.geodesicBuffer(jsGeometries, distances, undefined, unionResults);
            } else if (unionResults === null) {
                return engine.geodesicBuffer(jsGeometries, distances, unit);
            }
            return engine.geodesicBuffer(jsGeometries, distances, unit, unionResults);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async geodesicDensify(geometry: DotNetGeometry, maxSegmentLength: number,
                          maxSegmentLengthUnit: LinearUnits | null): Promise<Geometry | null> {
        try {
            if (maxSegmentLengthUnit === null) {
                return engine.geodesicDensify(buildJsGeometry(geometry) as Polygon | Polyline, maxSegmentLength);
            }
            return engine.geodesicDensify(buildJsGeometry(geometry) as Polygon | Polyline, maxSegmentLength, maxSegmentLengthUnit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async geodesicLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        try {
            if (unit === null) {
                return engine.geodesicLength(buildJsGeometry(geometry) as Geometry);
            }
            return engine.geodesicLength(buildJsGeometry(geometry) as Geometry, unit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async intersect(geometry1: DotNetGeometry | Array<DotNetGeometry>, geometry2: DotNetGeometry)
        : Promise<Geometry | Array<Geometry> | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(geometry1)) {
                jsGeometries = [];
                geometry1.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(geometry1) as Geometry;
            }
            return engine.intersect(jsGeometries, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async intersects(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.intersects(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async isSimple(geometry: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.isSimple(buildJsGeometry(geometry) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async nearestCoordinate(geometry: DotNetGeometry, inputPoint: DotNetPoint)
        : Promise<NearestPointResult | null> {
        try {
            return engine.nearestCoordinate(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async nearestVertex(geometry: DotNetGeometry, inputPoint: DotNetPoint)
        : Promise<NearestPointResult | null> {
        try {
            return engine.nearestVertex(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async nearestVertices(geometry: DotNetGeometry, inputPoint: DotNetPoint, searchRadius: number,
                          maxVertexCountToReturn: number)
        : Promise<Array<NearestPointResult> | null> {
        try {
            return engine.nearestVertices(buildJsGeometry(geometry) as Geometry, buildJsPoint(inputPoint) as Point,
                searchRadius, maxVertexCountToReturn);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async offset(geometries: Array<DotNetGeometry> | DotNetGeometry, offsetDistance: number,
                 offsetUnit: LinearUnits | null | undefined, joinType: any | null | undefined,
                 bevelRatio: number | null | undefined, flattenError: number | null | undefined)
        : Promise<Geometry | Array<Geometry> | null> {
        try {
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
            return engine.offset(jsGeometries, offsetDistance, offsetUnit, joinType as any, bevelRatio, flattenError);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async overlaps(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.overlaps(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async planarArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<number | null> {
        try {
            if (unit === null) {
                return engine.planarArea(buildJsPolygon(geometry) as Polygon);
            }
            return engine.planarArea(buildJsPolygon(geometry) as Polygon, unit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async planarLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        try {
            if (unit === null) {
                return engine.planarLength(buildJsGeometry(geometry) as Geometry);
            }
            return engine.planarLength(buildJsGeometry(geometry) as Geometry, unit);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async relate(geometry1: DotNetGeometry, geometry2: DotNetGeometry, relation: string)
        : Promise<boolean | null> {
        try {
            return engine.relate(buildJsGeometry(geometry1) as Geometry, buildJsGeometry(geometry2) as Geometry, relation);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async rotate(geometry: DotNetGeometry, angle: number, rotationOrigin: DotNetPoint): Promise<Geometry | null> {
        try {
            return engine.rotate(buildJsGeometry(geometry) as Geometry, angle, buildJsPoint(rotationOrigin) as Point);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async simplify(geometry: DotNetGeometry): Promise<Geometry | null> {
        try {
            return engine.simplify(buildJsGeometry(geometry) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async symmetricDifference(leftGeometry: Array<DotNetGeometry> | DotNetGeometry, rightGeometry: DotNetGeometry)
        : Promise<Geometry | Array<Geometry> | null> {
        try {
            let jsGeometries: Geometry | Array<Geometry>
            if (Array.isArray(leftGeometry)) {
                jsGeometries = [];
                leftGeometry.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                jsGeometries = buildJsGeometry(leftGeometry) as Geometry;
            }
            return engine.symmetricDifference(jsGeometries, buildJsGeometry(rightGeometry) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async touches(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.touches(buildJsGeometry(geometry1) as Geometry,
                buildJsGeometry(geometry2) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async union(...args: Array<any>): Promise<Geometry | null> {
        try {
            let jsGeometries: Array<Geometry> = [];
            if (Array.isArray(args[0])) {
                args[0].forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            } else {
                args.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            }

            return engine.union(jsGeometries);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async within(innerGeometry: DotNetGeometry, outerGeometry: DotNetGeometry): Promise<boolean | null> {
        try {
            return engine.within(buildJsGeometry(innerGeometry) as Geometry,
                buildJsGeometry(outerGeometry) as Geometry);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    logError(error) {
        error.message ??= error.toString();
        console.debug(error);
        try {
            this.dotNetRef.invokeMethodAsync('OnJavascriptError', {
                message: error.message, name: error.name, stack: error.stack
            });
        } catch {
        }
    }
}