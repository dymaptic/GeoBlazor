import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {DotNetPolyline} from "./definitions";
import Polyline from "@arcgis/core/geometry/Polyline";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import {copyValuesIfExists, hasValue} from "./arcGisJsInterop";

export function buildDotNetPolyline(polyline: any): any {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: buildDotNetSpatialReference(polyline.spatialReference)
    };
}

export function buildJsPolyline(dnPolyline: DotNetPolyline): Polyline | null {
    if (dnPolyline === undefined || dnPolyline === null) return null;
    let polyline = new Polyline({
        paths: buildJsPathsOrRings(dnPolyline.paths) ?? undefined
    });
    if (hasValue(dnPolyline.spatialReference)) {
        polyline.spatialReference = buildJsSpatialReference(dnPolyline.spatialReference);
    } else {
        polyline.spatialReference = new SpatialReference({wkid: 4326});
    }

    copyValuesIfExists(dnPolyline, polyline, 'hasZ', 'hasM');
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
