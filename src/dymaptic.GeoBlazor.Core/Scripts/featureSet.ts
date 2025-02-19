// override generated code in this file

import { buildDotNetGeometry, buildJsGeometry } from "./geometry";
import { buildDotNetGraphic, buildJsGraphic } from "./graphic";
import { buildDotNetSpatialReference, buildJsSpatialReference } from "./spatialReference";
import {dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import {buildDotNetField, buildJsField} from "./field";

export function buildJsFeatureSet(dotNetFs: any): any {
    let jsFeatureSet: any = {
        features: [],
        displayFieldName: dotNetFs.displayFieldName,
        exceededTransferLimit: dotNetFs.exceededTransferLimit,
        fields: dotNetFs.fields.map(buildJsField),
        geometryType: dotNetFs.geometryType,
        queryGeometry: buildJsGeometry(dotNetFs.queryGeometry),
        spatialReference: buildJsSpatialReference(dotNetFs.spatialReference)
    };
    for (let i = 0; i < dotNetFs.features.length; i++) {
        let feature = dotNetFs.features[i];
        jsFeatureSet.features.push(buildJsGraphic(feature));
    }
    return jsFeatureSet;
}

export async function buildDotNetFeatureSet(jsFs: any, layerId: string | null, viewId: string | null): Promise<any> {
    let dotNetFeatureSet: any = {
        features: [],
        displayFieldName: jsFs.displayFieldName,
        exceededTransferLimit: jsFs.exceededTransferLimit,
        fields: jsFs.fields.map(buildDotNetField),
        geometryType: jsFs.geometryType,
        queryGeometry: buildDotNetGeometry(jsFs.queryGeometry),
        spatialReference: buildDotNetSpatialReference(jsFs.spatialReference)
    };
    let graphics: any[] = [];
    for (let i = 0; i < jsFs.features.length; i++) {
        let feature = jsFs.features[i];
        let graphic = buildDotNetGraphic(feature, layerId, viewId);
        if (viewId !== undefined && viewId !== null) {
            graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
            let groupId = layerId ?? viewId;
            if (groupId !== null) {
                if (!graphicsRefs.hasOwnProperty(groupId)) {
                    graphicsRefs[groupId] = {};
                }
                graphicsRefs[groupId][graphic.id as string] = feature;
            }

        }
        graphics.push(graphic);
    }
    dotNetFeatureSet.features = graphics;

    return dotNetFeatureSet;
}
