import esriConfig from "@arcgis/core/config";
import * as projection from "@arcgis/core/geometry/projection";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildDotNetGeographicTransformation, buildDotNetGeometry} from "./dotNetBuilder";
import {buildJsExtent, buildJsSpatialReference} from "./jsBuilder";
import {DotNetGeographicTransformation, DotNetGeometry} from "./definitions";

export default class ProjectionWrapper {
    private dotNetRef: any;

    constructor(dotNetReference, apiKey) {
        this.dotNetRef = dotNetReference;
        esriConfig.apiKey = apiKey;
    }

    async project(geometry: any[] | any, outSpatialReference, geographicTransformation?):
        Promise<DotNetGeometry[] | DotNetGeometry | null> {
        try {
            await this.loadIfNeeded();
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
            this.logError(error);
            return null;
        }
    }

    async getTransformation(inSpatialReference, outSpatialReference, extent):
        Promise<DotNetGeographicTransformation | null> {
        try {
            await this.loadIfNeeded();
            let geoTransform = projection.getTransformation(buildJsSpatialReference(inSpatialReference),
                buildJsSpatialReference(outSpatialReference), buildJsExtent(extent, null));
            return buildDotNetGeographicTransformation(geoTransform);
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async getTransformations(inSpatialReference, outSpatialReference, extent):
        Promise<DotNetGeographicTransformation[] | null> {
        try {
            await this.loadIfNeeded();
            let geoTransforms = projection.getTransformations(buildJsSpatialReference(inSpatialReference),
                buildJsSpatialReference(outSpatialReference), buildJsExtent(extent, null));
            let dotNetTransforms: Array<DotNetGeographicTransformation> = [];
            geoTransforms.forEach(t => {
                let dotNetT = buildDotNetGeographicTransformation(t);
                if (dotNetT !== null) {
                    dotNetTransforms.push(dotNetT);
                }
            });
            return dotNetTransforms;
        } catch (error) {
            this.logError(error);
            return null;
        }
    }

    async loadIfNeeded() {
        if (!projection.isLoaded()) {
            await projection.load();
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

