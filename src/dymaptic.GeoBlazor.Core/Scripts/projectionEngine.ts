import Geometry from "@arcgis/core/geometry/Geometry";
import {DotNetGeographicTransformation, DotNetGeometry} from "./definitions";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import {buildJsSpatialReference} from "./spatialReference";
import {hasValue} from "./arcGisJsInterop";
import {buildJsExtent} from "./extent";
import BaseComponent from "./baseComponent";

export default class ProjectionWrapper extends BaseComponent {
    async load(): Promise<void> {
        let projectionOperator = await import('@arcgis/core/geometry/operators/projectOperator');
        if (!projectionOperator.isLoaded()) {
            await projectionOperator.load();
        }
    }
    async project(geometry: any[] | any, outSpatialReference, geographicTransformation?):
        Promise<any> {
        let projectionOperator = await import('@arcgis/core/geometry/operators/projectOperator');
        if (!projectionOperator.isLoaded()) {
            await projectionOperator.load();
        }
        let options: any = {};
        if (hasValue(geographicTransformation)) {
            options.geographicTransformation = geographicTransformation;
        }
        
        if (geometry === null) return null;

        if (Array.isArray(geometry)) {
            let jsGeometries = geometry.map(g => buildJsGeometry(g));
            let result = projectionOperator.executeMany(jsGeometries, buildJsSpatialReference(outSpatialReference) as any,
                options);
            
            let resultArray: DotNetGeometry[] = [];
            (result as Geometry[]).forEach(g => {
                let dotNetGeom = buildDotNetGeometry(g);
                if (dotNetGeom !== null) {
                    resultArray.push(dotNetGeom);
                }
            });

            return resultArray;
        }

        let jsGeometry = buildJsGeometry(geometry);
        let result = projectionOperator.execute(jsGeometry, buildJsSpatialReference(outSpatialReference) as any,
            options);
        
        return buildDotNetGeometry(result);
    }

    async getTransformation(inSpatialReference, outSpatialReference, extent):
        Promise<DotNetGeographicTransformation | null> {
        let geographicTransformationUtils = await import('@arcgis/core/geometry/operators/support/geographicTransformationUtils');
        if (!geographicTransformationUtils.isLoaded()) {
            await geographicTransformationUtils.load();
        }
        
        let geoTransform;
        if (hasValue(extent)) {
            let jsExtent = buildJsExtent(extent, buildJsSpatialReference(inSpatialReference));
            geoTransform = geographicTransformationUtils.getTransformation(buildJsSpatialReference(inSpatialReference) as any,
                buildJsSpatialReference(outSpatialReference) as any, jsExtent)
        } else {
            geoTransform = geographicTransformationUtils.getTransformation(buildJsSpatialReference(inSpatialReference) as any,
                buildJsSpatialReference(outSpatialReference) as any)
        }
        let {buildDotNetGeographicTransformation} = await import('./geographicTransformation');
        return buildDotNetGeographicTransformation(geoTransform);
    }

    async getTransformations(inSpatialReference, outSpatialReference, extent):
        Promise<DotNetGeographicTransformation[] | null> {
        let geographicTransformationUtils = await import('@arcgis/core/geometry/operators/support/geographicTransformationUtils');
        if (!geographicTransformationUtils.isLoaded()) {
            await geographicTransformationUtils.load();
        }
        
        let geoTransforms;
        if (hasValue(extent)) {
            let jsExtent = buildJsExtent(extent, buildJsSpatialReference(inSpatialReference));
            geoTransforms = geographicTransformationUtils.getTransformations(buildJsSpatialReference(inSpatialReference) as any,
                buildJsSpatialReference(outSpatialReference) as any, jsExtent);
        } else {
            geoTransforms = geographicTransformationUtils.getTransformations(buildJsSpatialReference(inSpatialReference) as any,
                buildJsSpatialReference(outSpatialReference) as any);
        }
        let dotNetTransforms: Array<DotNetGeographicTransformation> = [];
        let {buildDotNetGeographicTransformation} = await import('./geographicTransformation');
        geoTransforms.forEach(t => {
            let dotNetT = buildDotNetGeographicTransformation(t);
            if (dotNetT !== null) {
                dotNetTransforms.push(dotNetT);
            }
        });
        return dotNetTransforms;
    }
}

export async function buildJsProjection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // not used
}

export async function buildDotNetProjection(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // not used
}
