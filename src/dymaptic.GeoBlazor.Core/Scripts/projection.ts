import esriConfig from "@arcgis/core/config";
import * as projection from "@arcgis/core/geometry/projection";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildDotNetGeometry} from "./dotNetBuilder";
import GeographicTransformation from "@arcgis/core/geometry/support/GeographicTransformation";

let dotNetRef: any = null;

export function initialize(dotNetReference, apiKey) {
    dotNetRef = dotNetReference;
    esriConfig.apiKey = apiKey;
}

export async function project(geometry: any[], outSpatialReference, geographicTransformation?): 
    Promise<any[] | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        let result = projection.project(geometry, outSpatialReference, geographicTransformation);
        if (result === null) return null;
        let resultArray: any[] = [];
        if (Array.isArray(result)) {
            (result as Geometry[]).forEach(g => resultArray.push(buildDotNetGeometry(g)));
        } else {
            resultArray.push(buildDotNetGeometry(result));
        }
        return resultArray;
    } catch (error) {
        logError(error);
        return null;
    }
}

export async function getTransformation(inSpatialReference, outSpatialReference, extent): 
    Promise<GeographicTransformation | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        return projection.getTransformation(inSpatialReference, outSpatialReference, extent);
    } catch (error) {
        logError(error);
        return null;
    }
}

export async function getTransformations(inSpatialReference, outSpatialReference, extent):
    Promise<GeographicTransformation[] | null> {
    try {
        await waitForInitialization();
        await loadIfNeeded();
        return projection.getTransformations(inSpatialReference, outSpatialReference, extent);
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
    if (error.stack !== undefined && error.stack !== null) {
        console.log(error.stack);
        dotNetRef?.invokeMethodAsync('OnJavascriptError', error.stack);
    } else {
        console.log(error.message);
        dotNetRef?.invokeMethodAsync('OnJavascriptError', error.message);
    }
}

function cleanJsObject(dotNetObject: any): any {
    delete dotNetObject.id;
    Object.keys(dotNetObject).forEach((key, _) => {
        delete dotNetObject[key]?.id;
    });
    return dotNetObject;
}