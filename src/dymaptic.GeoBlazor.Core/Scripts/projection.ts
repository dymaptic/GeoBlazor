import esriConfig from "@arcgis/core/config";
import * as projection from "@arcgis/core/geometry/projection";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildDotNetGeographicTransformation, buildDotNetGeometry} from "./dotNetBuilder";
import {DotNetGeographicTransformation, DotNetGeometry} from "ArcGisDefinitions";
import {buildJsExtent, buildJsSpatialReference} from "./jsBuilder";

let dotNetRef: any = null;

export function initialize(dotNetReference, apiKey) {
    dotNetRef = dotNetReference;
    esriConfig.apiKey = apiKey;
}

export async function project(geometry: any[] | any, outSpatialReference, geographicTransformation?): 
    Promise<DotNetGeometry[] | DotNetGeometry | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        let result = projection.project(geometry, buildJsSpatialReference(outSpatialReference), 
            geographicTransformation);
        if (result === null) return null;
        
        if (Array.isArray(result)) {
            let resultArray: DotNetGeometry[] = [];
            (result as Geometry[]).forEach(g => {
                let dotNetGeom = buildDotNetGeometry(g);
                if (dotNetGeom !== null) {
                    resultArray.push(dotNetGeom);
                }
            });

            return resultArray;
        } else {
            return buildDotNetGeometry(result);
        }
        
    } catch (error) {
        logError(error);
        return null;
    }
}

export async function getTransformation(inSpatialReference, outSpatialReference, extent): 
    Promise<DotNetGeographicTransformation | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        let geoTransform = projection.getTransformation(buildJsSpatialReference(inSpatialReference), 
            buildJsSpatialReference(outSpatialReference), buildJsExtent(extent));
        return buildDotNetGeographicTransformation(geoTransform);
    } catch (error) {
        logError(error);
        return null;
    }
}

export async function getTransformations(inSpatialReference, outSpatialReference, extent):
    Promise<DotNetGeographicTransformation[] | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        let geoTransforms = projection.getTransformations(buildJsSpatialReference(inSpatialReference),
            buildJsSpatialReference(outSpatialReference), buildJsExtent(extent));
        let dotNetTransforms: Array<DotNetGeographicTransformation> = [];
        geoTransforms.forEach(t => {
            let dotNetT = buildDotNetGeographicTransformation(t);
            if (dotNetT !== null) {
                dotNetTransforms.push(dotNetT);
            }
        });
        return dotNetTransforms;
    } catch (error) {
        logError(error);
        return null;
    }
}

function waitForInitialization() {
    const poll = resolve => {
        if (projection !== null) resolve();
        else setTimeout(_ => poll(resolve), 400);
    }

    return new Promise(poll);
}

async function loadIfNeeded() {
    if (!projection.isLoaded()) {
        await projection.load();
    }
}

function logError(error) {
    error.message ??= error.toString();
    dotNetRef?.invokeMethodAsync('OnJavascriptError', error);
}