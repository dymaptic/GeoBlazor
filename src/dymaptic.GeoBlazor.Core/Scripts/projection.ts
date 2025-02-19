import ProjectionGenerated from './projection.gb';
import * as projection from "@arcgis/core/geometry/projection";
import Geometry from "@arcgis/core/geometry/Geometry";
import {DotNetGeographicTransformation, DotNetGeometry} from "./definitions";
import { buildDotNetGeometry } from "./geometry";
import { buildJsSpatialReference } from "./spatialReference";
import { hasValue } from "./arcGisJsInterop";
import { buildJsExtent } from "./extent";

export default class ProjectionWrapper extends ProjectionGenerated {
    private dotNetRef: any;

    constructor(component) {
        super(component);
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
            let geoTransform;
            if (hasValue(extent)) {
                let jsExtent = buildJsExtent(extent, buildJsSpatialReference(inSpatialReference));
                geoTransform = projection.getTransformation(buildJsSpatialReference(inSpatialReference),
                    buildJsSpatialReference(outSpatialReference), jsExtent)
            } else {
                geoTransform = projection.getTransformation(buildJsSpatialReference(inSpatialReference),
                    buildJsSpatialReference(outSpatialReference))
            }
            let { buildDotNetGeographicTransformation } = await import('./geographicTransformation');
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
            let geoTransforms;
            if (hasValue(extent)) {
                let jsExtent = buildJsExtent(extent, buildJsSpatialReference(inSpatialReference));
                geoTransforms = projection.getTransformations(buildJsSpatialReference(inSpatialReference),
                    buildJsSpatialReference(outSpatialReference), jsExtent);
            } else {
                geoTransforms = projection.getTransformations(buildJsSpatialReference(inSpatialReference),
                    buildJsSpatialReference(outSpatialReference));
            }
            let dotNetTransforms: Array<DotNetGeographicTransformation> = [];
            let { buildDotNetGeographicTransformation } = await import('./geographicTransformation');
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
        console.debug(error);
        throw error;
    }
}

export async function buildJsProjection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProjectionGenerated } = await import('./projection.gb');
    return await buildJsProjectionGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetProjection(jsObject: any): Promise<any> {
    let { buildDotNetProjectionGenerated } = await import('./projection.gb');
    return await buildDotNetProjectionGenerated(jsObject);
}
