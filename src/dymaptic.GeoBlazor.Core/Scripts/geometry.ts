import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {hasValue} from "./arcGisJsInterop";

export function buildDotNetGeometry(geometry): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildDotNetPoint(geometry);
        case "polyline":
            return buildDotNetPolyline(geometry);
        case "polygon":
            return buildDotNetPolygon(geometry);
        case "extent":
            return buildDotNetExtent(geometry);
        case "multipoint":
            try {
                // @ts-ignore
                let {buildDotNetMultipoint} = import("./multipoint");
                return buildDotNetMultipoint(geometry);
            } catch {
                throw new Error("Multipoint requires GeoBlazor Pro");
            }
        case "mesh":
            try {
                // @ts-ignore
                let {buildDotNetMesh} = import("./mesh");
                return buildDotNetMesh(geometry);
            } catch {
                throw new Error("Mesh requires GeoBlazor Pro");
            }
    }
}

export function buildJsGeometry(geometry): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildJsPoint(geometry);
        case "polyline":
            return buildJsPolyline(geometry);
        case "polygon":
            return buildJsPolygon(geometry);
        case "extent":
            return buildJsExtent(geometry);
        case "multipoint":
            try {
                // @ts-ignore
                let { buildJsMultipoint } = import("./multipoint");
                return buildJsMultipoint(geometry);
            } catch {
                throw new Error("Multipoint requires GeoBlazor Pro");
            }
        case "mesh":
            try {
                // @ts-ignore
                let { buildJsMesh } = import("./mesh");
                return buildJsMesh(geometry);
            } catch {
                throw new Error("Mesh requires GeoBlazor Pro");
            }
    }

    return geometry as any;
}
