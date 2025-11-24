import Geometry from "@arcgis/core/geometry/Geometry";
import Polygon from "@arcgis/core/geometry/Polygon";
import Polyline from "@arcgis/core/geometry/Polyline";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Point from "@arcgis/core/geometry/Point";
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline
} from "./definitions";
import Extent from "@arcgis/core/geometry/Extent";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import LinearUnits = __esri.LinearUnits;
import SpatialReferenceInfo = __esri.SpatialReferenceInfo;
import AreaUnits = __esri.AreaUnits;
import Mesh from "@arcgis/core/geometry/Mesh";
import Multipoint from "@arcgis/core/geometry/Multipoint";
import { hasValue } from './arcGisJsInterop';
import GeometryUnion = __esri.GeometryUnion;
import BaseComponent from "./baseComponent";

export default class GeometryEngineWrapper extends BaseComponent {
    
    async buffer(geometries: DotNetGeometry | Array<DotNetGeometry>, distances: number | Array<number>,
                 unit: LinearUnits | null, unionResults: boolean | null): Promise<any> {
        let bufferOperator = await import('@arcgis/core/geometry/operators/bufferOperator');
        let jsGeometries: Geometry | Array<Geometry>;
        let jsBuffer: Polygon | Polygon[];
        let options: any = {};
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<Geometry>).push(buildJsGeometry(g) as Geometry));
            if (hasValue(unit)) {
                options.unit = unit;
            }
            if (hasValue(unionResults)) {
                options.union = unionResults;
            }
            jsBuffer = bufferOperator.executeMany(jsGeometries as GeometryUnion[], distances as number[], options);
            return jsBuffer.map(g => buildDotNetPolygon(g) as DotNetPolygon);
        }

        jsGeometries = buildJsGeometry(geometries) as Geometry;
        if (hasValue(unit)) {
            options.unit = unit;
        }
        jsBuffer = bufferOperator.execute(jsGeometries as GeometryUnion, distances as number, options) as Polygon;
        
        return buildDotNetPolygon(jsBuffer);

    }

    async clip(geometry: DotNetGeometry, extent: DotNetExtent): Promise<any> {
        let clipOperator = await import('@arcgis/core/geometry/operators/clipOperator');
        let jsClip = clipOperator.execute(buildJsGeometry(geometry) as any, buildJsExtent(extent, null));
        return buildDotNetGeometry(jsClip);
    }

    async contains(containerGeometry: DotNetGeometry, insideGeometry: DotNetGeometry): Promise<any> {
        let containsOperator = await import('@arcgis/core/geometry/operators/containsOperator');
        return containsOperator.execute(buildJsGeometry(containerGeometry) as GeometryUnion,
            buildJsGeometry(insideGeometry) as GeometryUnion);
    }

    async convexHull(geometries: Array<DotNetGeometry> | DotNetGeometry, merge: boolean | null): Promise<any> {
        let convexHullOperator = await import('@arcgis/core/geometry/operators/convexHullOperator');
        let jsGeometries: Geometry | Array<Geometry>;
        let jsHull: GeometryUnion | GeometryUnion[];
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            let options: any = {};
            if (hasValue(merge)) {
                options.merge = merge;
            }
            jsHull = convexHullOperator.executeMany(jsGeometries as GeometryUnion[], options) as GeometryUnion[];
            return jsHull.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        jsGeometries = buildJsGeometry(geometries) as Geometry;
        jsHull = convexHullOperator.execute(jsGeometries as any) as GeometryUnion;
        
        return buildDotNetGeometry(jsHull);
    }

    async crosses(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        let crossesOperator = await import('@arcgis/core/geometry/operators/crossesOperator');
        return crossesOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion);
    }

    async cut(geometry: DotNetGeometry, cutter: DotNetPolyline): Promise<any> {
        let cutOperator = await import('@arcgis/core/geometry/operators/cutOperator');
        let jsCut = cutOperator.execute(buildJsGeometry(geometry) as GeometryUnion, buildJsPolyline(cutter) as Polyline);
        return jsCut.map(g => buildDotNetGeometry(g) as DotNetGeometry);
    }

    async densify(geometry: DotNetGeometry, maxSegmentLength: number, maxSegmentLengthUnit: LinearUnits | null)
        : Promise<any> {
        let densifyOperator = await import('@arcgis/core/geometry/operators/densifyOperator');
        let jsGeometry = buildJsGeometry(geometry) as GeometryUnion;
        let jsDensified: Geometry;
        let options: any = {};
        if (hasValue(maxSegmentLengthUnit)) {
            options.unit = maxSegmentLengthUnit;
        }
        jsDensified = densifyOperator.execute(jsGeometry, maxSegmentLength, options);

        return buildDotNetGeometry(jsDensified);
    }

    async difference(geometries: Array<DotNetGeometry> | DotNetGeometry, subtractor: DotNetGeometry)
        : Promise<any> {
        let differenceOperator = await import('@arcgis/core/geometry/operators/differenceOperator');
        let jsGeometries: GeometryUnion | Array<GeometryUnion>;
        let jsDifference: any;
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            jsDifference = differenceOperator.executeMany(jsGeometries as GeometryUnion[], buildJsGeometry(subtractor) as GeometryUnion);
            return jsDifference.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        jsGeometries = buildJsGeometry(geometries) as GeometryUnion;
        jsDifference = differenceOperator.execute(jsGeometries as any, buildJsGeometry(subtractor) as GeometryUnion);
        return buildDotNetGeometry(jsDifference);
    }

    async disjoint(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<any> {
        let disjointOperator = await import('@arcgis/core/geometry/operators/disjointOperator');
        return disjointOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion);
    }

    async distance(geometry1: DotNetGeometry, geometry2: DotNetGeometry, distanceUnit: LinearUnits | null)
        : Promise<number | null> {
        let distanceOperator = await import('@arcgis/core/geometry/operators/distanceOperator');
        let jsGeometry1 = buildJsGeometry(geometry1) as GeometryUnion;
        let jsGeometry2 = buildJsGeometry(geometry2) as GeometryUnion;
        let options: any = {};
        if (hasValue(distanceUnit)) {
            options.unit = distanceUnit;
        }
        
        return distanceOperator.execute(jsGeometry1, jsGeometry2, options);
    }

    async areEqual(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        let equalsOperator = await import('@arcgis/core/geometry/operators/equalsOperator');
        return equalsOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion);
    }

    async extendedSpatialReferenceInfo(spatialReference: SpatialReference)
        : Promise<SpatialReferenceInfo | null> {
        let geometryEngine = await import('@arcgis/core/geometry/geometryEngine');
        return geometryEngine.extendedSpatialReferenceInfo(spatialReference);
    }

    async flipHorizontal(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<any> {
        let { default: Transformation } = await import('@arcgis/core/geometry/operators/support/Transformation');
        let transformation = new Transformation();
        let affineTransformOperator = await import('@arcgis/core/geometry/operators/affineTransformOperator');
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let y0 = jsGeometry.extent?.ymin ?? 0;
        let y1 = jsGeometry.extent?.ymax ?? 0;
        if (hasValue(flipOrigin?.y)) {
            // without a flip origin, the flip point is halfway between the min and max y values
            let center = y1 - y0;
            // with a set y origin point, we need to calculate the distance from the min and max y values
            let flipY = flipOrigin!.y;
            if (flipY < center) {
                y0 = y1 - (flipY * 2);
            } else if (flipY > center) {
                y1 = y0 + (flipY * 2);
            }
        }
        transformation.flipY(y0, y1);
        let jsFlip = affineTransformOperator.execute(jsGeometry as any, transformation);

        return buildDotNetGeometry(jsFlip);
    }

    async flipVertical(geometry: DotNetGeometry, flipOrigin: DotNetPoint | null): Promise<any> {
        let { default: Transformation } = await import('@arcgis/core/geometry/operators/support/Transformation');
        let transformation = new Transformation();
        let affineTransformOperator = await import('@arcgis/core/geometry/operators/affineTransformOperator');
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let x0 = jsGeometry.extent?.xmin ?? 0;
        let x1 = jsGeometry.extent?.xmax ?? 0;
        if (hasValue(flipOrigin?.x)) {
            // without a flip origin, the flip point is halfway between the min and max x values
            let center = x1 - x0;
            // with a set x origin point, we need to calculate the distance from the min and max x values
            let flipX = flipOrigin!.x;
            if (flipX < center) {
                x0 = x1 - (flipX * 2);
            } else if (flipX > center) {
                x1 = x0 + (flipX * 2);
            }
        }
        transformation.flipX(x0, x1);
        let jsFlip = affineTransformOperator.execute(jsGeometry as any, transformation);

        return buildDotNetGeometry(jsFlip);
    }

    async generalize(geometry: DotNetGeometry, maxDeviation: number, removeDegenerateParts: boolean | null,
                     maxDeviationUnit: LinearUnits | null): Promise<any> {
        let generalizeOperator = await import('@arcgis/core/geometry/operators/generalizeOperator');
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsGeneralize: GeometryUnion;
        let options: any = {};
        if (hasValue(removeDegenerateParts)) {
            options.removeDegenerateParts = removeDegenerateParts;
        }
        if (hasValue(maxDeviationUnit)) {
            options.unit = maxDeviationUnit;
        }
        
        jsGeneralize = generalizeOperator.execute(jsGeometry as GeometryUnion, maxDeviation, options) as GeometryUnion;

        return buildDotNetGeometry(jsGeneralize);
    }

    async geodesicArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<any> {
        let geodeticAreaOperator = await import('@arcgis/core/geometry/operators/geodeticAreaOperator');
        if (!geodeticAreaOperator.isLoaded()) {
            await geodeticAreaOperator.load();
        }
        let options: any = {
            curveType: "geodesic"
        };
        if (hasValue(unit)) {
            options.unit = unit;
        }
        
        return geodeticAreaOperator.execute(buildJsPolygon(geometry) as Polygon, options);
    }

    async geodesicBuffer(geometries: Array<DotNetGeometry> | DotNetGeometry, distances: Array<number> | number,
                         unit: LinearUnits | null, unionResults: boolean | null): Promise<any> {
        let geodesicBufferOperator = await import('@arcgis/core/geometry/operators/geodesicBufferOperator');
        if (!geodesicBufferOperator.isLoaded()) {
            await geodesicBufferOperator.load();
        }
        let jsGeometries: Geometry | Array<Geometry>;
        let jsBuffer: Polygon | Polygon[];
        let options: any = {
            curveType: "geodesic"
        };
        if (hasValue(unit)) {
            options.unit = unit;
        }
        if (hasValue(unionResults)) {
            options.union = unionResults;
        }
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            jsBuffer = geodesicBufferOperator.executeMany(jsGeometries as GeometryUnion[], distances as number[], options);
            return jsBuffer.map(g => buildDotNetPolygon(g) as DotNetPolygon);
        }

        jsGeometries = buildJsGeometry(geometries) as Geometry;
        jsBuffer = geodesicBufferOperator.execute(jsGeometries as GeometryUnion, distances as number, options) as Polygon;
        return buildDotNetPolygon(jsBuffer);
    }

    async geodesicDensify(geometry: DotNetGeometry, maxSegmentLength: number,
                          maxSegmentLengthUnit: LinearUnits | null): Promise<any> {
        let geodeticDensifyOperator = await import('@arcgis/core/geometry/operators/geodeticDensifyOperator');
        if (!geodeticDensifyOperator.isLoaded()) {
            await geodeticDensifyOperator.load();
        }
        let jsDensify: GeometryUnion;
        let options: any = {};
        if (hasValue(maxSegmentLengthUnit)) {
            options.unit = maxSegmentLengthUnit;
        }
        jsDensify = geodeticDensifyOperator.execute(buildJsGeometry(geometry) as GeometryUnion, maxSegmentLength, options) as GeometryUnion;
        
        return buildDotNetGeometry(jsDensify);

    }

    async geodesicLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        let geodeticLengthOperator = await import('@arcgis/core/geometry/operators/geodeticLengthOperator');
        if (!geodeticLengthOperator.isLoaded()) {
            await geodeticLengthOperator.load();
        }
        let options: any = {};
        if (hasValue(unit)) {
            options.unit = unit;
        }
        return geodeticLengthOperator.execute(buildJsGeometry(geometry) as GeometryUnion, options);
    }

    async intersect(geometry1: DotNetGeometry | Array<DotNetGeometry>, geometry2: DotNetGeometry)
        : Promise<any> {
        let intersectionOperator = await import('@arcgis/core/geometry/operators/intersectionOperator');
        let jsGeometries: GeometryUnion | Array<GeometryUnion>;
        let jsIntersection: GeometryUnion | Array<GeometryUnion>;
        if (Array.isArray(geometry1)) {
            jsGeometries = [];
            geometry1.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            jsIntersection = intersectionOperator.executeMany(jsGeometries as GeometryUnion[], buildJsGeometry(geometry2) as GeometryUnion);
            return jsIntersection.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }

        jsGeometries = buildJsGeometry(geometry1) as GeometryUnion;
        jsIntersection = intersectionOperator.execute(jsGeometries, buildJsGeometry(geometry2) as GeometryUnion) as GeometryUnion;
        return buildDotNetGeometry(jsIntersection);

    }

    async intersects(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        let intersectsOperator = await import('@arcgis/core/geometry/operators/intersectsOperator');
        return intersectsOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion);

    }

    async isSimple(geometry: DotNetGeometry): Promise<boolean | null> {
        let simplifyOperator = await import('@arcgis/core/geometry/operators/simplifyOperator');
        return simplifyOperator.isSimple(buildJsGeometry(geometry) as GeometryUnion);

    }

    async nearestCoordinate(geometry: DotNetGeometry, inputPoint: DotNetPoint)
        : Promise<any> {
        let proximityOperator = await import('@arcgis/core/geometry/operators/proximityOperator');
        let jsResult = proximityOperator.getNearestCoordinate(buildJsGeometry(geometry) as any, buildJsPoint(inputPoint) as Point);
        return {
            coordinate: buildJsPoint(jsResult.coordinate),
            distance: jsResult.distance,
            isEmpty: jsResult.isEmpty,
            vertexIndex: jsResult.vertexIndex,
            isRightSide: jsResult.isRightSide
        };
    }

    async nearestVertex(geometry: DotNetGeometry, inputPoint: DotNetPoint): Promise<any> {
        let proximityOperator = await import('@arcgis/core/geometry/operators/proximityOperator');
        let jsResult = proximityOperator.getNearestVertex(buildJsGeometry(geometry) as GeometryUnion, buildJsPoint(inputPoint) as Point);
        return {
            coordinate: buildDotNetPoint(jsResult.coordinate) as DotNetPoint,
            distance: jsResult.distance,
            vertexIndex: jsResult.vertexIndex,
            isEmpty: jsResult.isEmpty
        };

    }

    async nearestVertices(geometry: DotNetGeometry, inputPoint: DotNetPoint, searchRadius: number,
                          maxVertexCountToReturn: number): Promise<any> {
        let proximityOperator = await import('@arcgis/core/geometry/operators/proximityOperator');
        let jsResult = proximityOperator.getNearestVertices(
            buildJsGeometry(geometry) as GeometryUnion, buildJsPoint(inputPoint) as Point,
            searchRadius, maxVertexCountToReturn);
        return jsResult.filter(v => v !== undefined).map(r => {
            return {
                coordinate: buildDotNetPoint(r.coordinate) as DotNetPoint,
                distance: r.distance,
                vertexIndex: r.vertexIndex,
                isEmpty: r.isEmpty
            };
        });

    }

    async offset(geometries: Array<DotNetGeometry> | DotNetGeometry, offsetDistance: number,
                 offsetUnit: LinearUnits | null | undefined, joinType: any | null | undefined,
                 bevelRatio: number | null | undefined, flattenError: number | null | undefined): Promise<any> {
        let offsetOperator = await import('@arcgis/core/geometry/operators/offsetOperator');
        let jsGeometries: GeometryUnion | Array<GeometryUnion>
        let options: any = {};
        if (hasValue(offsetUnit)) {
            options.unit = offsetUnit;
        }
        if (hasValue(joinType)) {
            options.joins = joinType;
        }
        if (hasValue(flattenError)) {
            options.flattenError = flattenError;
        }
        if (Array.isArray(geometries)) {
            jsGeometries = [];
            geometries.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            let jsOffset = offsetOperator.executeMany(jsGeometries as GeometryUnion[], offsetDistance, options);
            return jsOffset.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        } 
            
        jsGeometries = buildJsGeometry(geometries as DotNetGeometry) as GeometryUnion;
        let jsOffset = offsetOperator.execute(jsGeometries as GeometryUnion, offsetDistance, options) as GeometryUnion;
        return buildDotNetGeometry(jsOffset);
    }

    async overlaps(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        let overlapsOperator = await import('@arcgis/core/geometry/operators/overlapsOperator');
        return overlapsOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion);

    }

    async planarArea(geometry: DotNetPolygon, unit: AreaUnits | null): Promise<number | null> {
        let areaOperator = await import('@arcgis/core/geometry/operators/areaOperator');
        if (unit === null) {
            return areaOperator.execute(buildJsPolygon(geometry) as Polygon);
        }
        return areaOperator.execute(buildJsPolygon(geometry) as Polygon, {unit: unit as any});
    }

    async planarLength(geometry: DotNetGeometry, unit: LinearUnits | null): Promise<number | null> {
        let lengthOperator = await import('@arcgis/core/geometry/operators/lengthOperator');
        if (unit === null) {
            return lengthOperator.execute(buildJsGeometry(geometry) as GeometryUnion);
        }
        return lengthOperator.execute(buildJsGeometry(geometry) as GeometryUnion, {unit: unit as any});

    }

    async relate(geometry1: DotNetGeometry, geometry2: DotNetGeometry, relation: string): Promise<boolean | null> {
        let relateOperator = await import('@arcgis/core/geometry/operators/relateOperator');
        return relateOperator.execute(buildJsGeometry(geometry1) as GeometryUnion, buildJsGeometry(geometry2) as GeometryUnion, relation);

    }

    async rotate(geometry: DotNetGeometry, angle: number, rotationOrigin: DotNetPoint): Promise<any> {
        let { default: Transformation } = await import('@arcgis/core/geometry/operators/support/Transformation');
        let transformation = new Transformation();
        let affineTransformOperator = await import('@arcgis/core/geometry/operators/affineTransformOperator');
        let jsRotationOrigin = buildJsPoint(rotationOrigin) as Point;
        transformation.rotate(angle, jsRotationOrigin.x, jsRotationOrigin.y)
        let jsRotated = affineTransformOperator.execute(buildJsGeometry(geometry) as GeometryUnion, 
            transformation);
        return buildDotNetGeometry(jsRotated);

    }

    async simplify(geometry: DotNetGeometry): Promise<any> {
        let simplifyOperator = await import('@arcgis/core/geometry/operators/simplifyOperator');
        let jsSimplified = simplifyOperator.execute(buildJsGeometry(geometry) as GeometryUnion);
        return buildDotNetGeometry(jsSimplified);

    }

    async symmetricDifference(leftGeometry: Array<DotNetGeometry> | DotNetGeometry, rightGeometry: DotNetGeometry)
        : Promise<any> {
        let symmetricDifferenceOperator = await import('@arcgis/core/geometry/operators/symmetricDifferenceOperator');
        let jsGeometries: GeometryUnion | Array<GeometryUnion>
        if (Array.isArray(leftGeometry)) {
            jsGeometries = [];
            leftGeometry.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
            let jsDifference = symmetricDifferenceOperator.executeMany(jsGeometries as GeometryUnion[], buildJsGeometry(rightGeometry) as GeometryUnion);
            return jsDifference.map(g => buildDotNetGeometry(g) as DotNetGeometry);
        }
        
        jsGeometries = buildJsGeometry(leftGeometry) as GeometryUnion;
        let jsDifference = symmetricDifferenceOperator.execute(jsGeometries as GeometryUnion, buildJsGeometry(rightGeometry) as GeometryUnion);
        return buildDotNetGeometry(jsDifference);

    }

    async touches(geometry1: DotNetGeometry, geometry2: DotNetGeometry): Promise<boolean | null> {
        let touchesOperator = await import('@arcgis/core/geometry/operators/touchesOperator');
        return touchesOperator.execute(buildJsGeometry(geometry1) as GeometryUnion,
            buildJsGeometry(geometry2) as GeometryUnion);
    }

    async union(...args: Array<any>): Promise<any> {
        let unionOperator = await import('@arcgis/core/geometry/operators/unionOperator');
        let jsGeometries: Array<GeometryUnion> = [];
        if (Array.isArray(args[0])) {
            args[0].forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
        } else {
            args.forEach(g => (jsGeometries as Array<GeometryUnion>).push(buildJsGeometry(g) as GeometryUnion));
        }

        let jsUnion = unionOperator.executeMany(jsGeometries);
        return buildDotNetGeometry(jsUnion);
    }

    async within(innerGeometry: DotNetGeometry, outerGeometry: DotNetGeometry): Promise<boolean | null> {
        let withinOperator = await import('@arcgis/core/geometry/operators/withinOperator');
        return withinOperator.execute(buildJsGeometry(innerGeometry) as GeometryUnion,
            buildJsGeometry(outerGeometry) as GeometryUnion);
    }

    async fromArcGisJson(json: string, typeName: string): Promise<any> {
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
            case "Mesh":
                jsGeometry = Mesh.fromJSON(jsonObject);
                break;
            case "Multipoint":
                jsGeometry = Multipoint.fromJSON(jsonObject);
                break;
            default:
                throw new Error("Invalid geometry type");
        }
        return buildDotNetGeometry(jsGeometry);

    }

    async toArcGisJson(geometry: any): Promise<string | null> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        return JSON.stringify(jsGeometry.toJSON());
    }

    async clone(geometry: DotNetGeometry): Promise<any> {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let clonedGeometry = jsGeometry.clone();
        return buildDotNetGeometry(clonedGeometry);

    }

    async centerExtentAt(extent: DotNetExtent, center: DotNetPoint): Promise<any> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let newExtent = jsExtent.centerAt(buildJsPoint(center) as Point);
        return buildDotNetExtent(newExtent);
    }

    async expand(extent: DotNetExtent, factor: number): Promise<any> {
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

    getPoint(geometry: DotNetGeometry, firstIndex: number, secondIndex: number) : DotNetPoint | null {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsPoint = (jsGeometry as any).getPoint(firstIndex, secondIndex);
        return buildDotNetPoint(jsPoint);
    }

    insertPoint(geometry: DotNetGeometry, firstIndex: number, secondIndex: number, point: DotNetPoint)
        : DotNetPolyline | null {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolyline = (jsGeometry as any).insertPoint(firstIndex, secondIndex, jsPoint);
        return buildDotNetGeometry(newPolyline);
    }

    removePath(polyline: DotNetPolyline, pathIndex: number): any | null {
        let jsPolyline = buildJsPolyline(polyline) as Polyline;
        let path = jsPolyline.removePath(pathIndex);
        let newLine = buildDotNetPolyline(jsPolyline) as DotNetPolyline;
        return {
            polyLine: newLine,
            path: path?.map(p => buildDotNetPoint(p) as DotNetPoint)
        }
    }

    removePoint(geometry: DotNetGeometry, firstIndex: number, secondIndex: number): any | null {
        let jsGeometry = buildJsPolyline(geometry) as Geometry;
        let point = (jsGeometry as any).removePoint(firstIndex, secondIndex);
        return {
            geometry: buildDotNetGeometry(jsGeometry) as DotNetGeometry,
            point: buildDotNetPoint(point) as DotNetPoint
        };
    }

    setPoint(geometry: DotNetGeometry, firstIndex: number, secondIndex: number, point: DotNetPoint)
        : DotNetPolyline | null {
        let jsGeometry = buildJsGeometry(geometry) as Geometry;
        let jsPoint = buildJsPoint(point) as Point;
        let newPolyline = (jsGeometry as any).setPoint(firstIndex, secondIndex, jsPoint);
        return buildDotNetGeometry(newPolyline);
    }

    async addRing(polygon: DotNetPolygon, ring: any): Promise<DotNetPolygon | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let newPolygon = jsPolygon.addRing(ring);
        return buildDotNetPolygon(newPolygon);
    }

    async polygonFromExtent(extent: DotNetExtent): Promise<DotNetPolygon | null> {
        let jsExtent = buildJsExtent(extent, null) as Extent;
        let jsPolygon = Polygon.fromExtent(jsExtent);
        return buildDotNetPolygon(jsPolygon);
    }


    async isClockwise(polygon: DotNetPolygon, ring: any): Promise<boolean | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        return jsPolygon.isClockwise(ring);
    }

    async removeRing(polygon: DotNetPolygon, index: number): Promise<any | null> {
        let jsPolygon = buildJsPolygon(polygon) as Polygon;
        let ring = jsPolygon.removeRing(index);
        return {
            polygon: buildDotNetPolygon(jsPolygon) as DotNetPolygon,
            ring: ring?.map(p => buildDotNetPoint(p) as DotNetPoint)
        };
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

    async intersectLinesToPoints(line1: any,
                                 line2: any): Promise<any> {
        let intersectionOperator = await import('@arcgis/core/geometry/operators/intersectionOperator');
        let {buildJsPolyline} = await import('./polyline');
        let jsLine1 = buildJsPolyline(line1) as any;
        let jsLine2 = buildJsPolyline(line2) as any;
        let results = intersectionOperator.executeMany(jsLine1, jsLine2);
        if (results.length === 0) {
            return [];
        }
        
        let pointResults: any = [];
        
        for (let i = 0; i < results.length; i++) {
            let result = results[i];
            if (result instanceof Multipoint) {
                for (let j = 0; j < result.points.length; j++) {
                    let c = result.points[j];
                    pointResults.push({
                        x: c[0],
                            y: c[1],
                        spatialReference: result.spatialReference,
                        hasM: result.hasM,
                        hasZ: result.hasZ,
                        z: c.length > 2 ? c[2] : null
                    });
                }
            } else if (result instanceof Polyline) {
                pointResults[i] = [];
                
                for (let j = 0; j < result.paths.length; j++) {
                    for (let k = 0; k < result.paths[j].length; k++) {
                        let c = result.paths[j][k];
                        pointResults[i].push({
                            x: c[0],
                            y: c[1],
                            spatialReference: result.spatialReference,
                            hasM: result.hasM,
                            hasZ: result.hasZ,
                            z: c.length > 2 ? c[2] : null
                        });
                    }
                }
            }
        }
        
        return pointResults;
    }
    
    async convertMultipartGeometriesToSinglePartGeometries(geometries: DotNetGeometry[], simplifyPolygons: boolean)
        : Promise<DotNetGeometry[]> {
        const jsGeometries = geometries.map(buildJsGeometry);
        let multiPartToSinglePartOperator = await import("@arcgis/core/geometry/operators/multiPartToSinglePartOperator");
        const results = multiPartToSinglePartOperator.executeMany(jsGeometries,
            {simplifyPolygons: simplifyPolygons});
        return results.map(buildDotNetGeometry);
    }
}

export async function buildJsGeometryEngine(dotNetObject: any, viewId: string | null): Promise<any> {
    // excluded
}

export async function buildDotNetGeometryEngine(jsObject: any, viewId: string | null): Promise<any> {
    // excluded
}
