import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {DotNetPolygon} from "./definitions";
import Polygon from "@arcgis/core/geometry/Polygon";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import {hasValue} from "./jsBuilder";
import {copyValuesIfExists} from "./arcGisJsInterop";

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

export function buildJsPolygon(dnPolygon: DotNetPolygon): Polygon | null {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    let polygon = new Polygon({
        rings: buildJsPathsOrRings(dnPolygon.rings) ?? undefined
    });
    if (hasValue(dnPolygon.spatialReference)) {
        polygon.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    } else {
        polygon.spatialReference = new SpatialReference({wkid: 4326});
    }

    copyValuesIfExists(dnPolygon, polygon, 'hasZ', 'hasM');
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
