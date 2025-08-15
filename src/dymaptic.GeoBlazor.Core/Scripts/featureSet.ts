// override generated code in this file

import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import {buildDotNetGraphic, buildJsGraphic} from "./graphic";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {dotNetRefs, graphicsRefs, hasValue} from "./arcGisJsInterop";
import {buildDotNetField, buildJsField} from "./field";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";

export function buildJsFeatureSet(dotNetFs: any, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetFs.displayFieldName)) {
        properties.displayFieldName = dotNetFs.displayFieldName;
    }
    if (hasValue(dotNetFs.exceededTransferLimit)) {
        properties.exceededTransferLimit = dotNetFs.exceededTransferLimit;
    }
    if (hasValue(dotNetFs.geometryType)) {
        properties.geometryType = dotNetFs.geometryType;
    }
    if (hasValue(dotNetFs.features) && dotNetFs.features.length > 0) {
        properties.features  = dotNetFs.features.map(f => buildJsGraphic(f, viewId));
    }
    if (hasValue(dotNetFs.fields)) {
        properties.fields = dotNetFs.fields.map(f => buildJsField(f, viewId));
    }    
    if (hasValue(dotNetFs.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetFs.spatialReference, viewId);
    }
    
    if (hasValue(dotNetFs.queryGeometry)) {
        properties.queryGeometry = buildJsGeometry(dotNetFs.queryGeometry, viewId);
    }
    
    let jsFeatureSet = new FeatureSet(properties);
    return jsFeatureSet;
}

export async function buildDotNetFeatureSet(jsFs: any, layerId: string | null, viewId: string | null): Promise<any> {
    let dotNetFeatureSet: any = {
        features: [],
        displayFieldName: jsFs.displayFieldName,
        exceededTransferLimit: jsFs.exceededTransferLimit,
        fields: jsFs.fields?.map(buildDotNetField),
        geometryType: jsFs.geometryType,
        queryGeometry: buildDotNetGeometry(jsFs.queryGeometry, viewId),
        spatialReference: buildDotNetSpatialReference(jsFs.spatialReference, viewId)
    };
    let graphics: any[] = [];
    for (let i = 0; i < jsFs.features.length; i++) {
        let feature = jsFs.features[i];
        let graphic = buildDotNetGraphic(feature, layerId, viewId);
        graphics.push(graphic);
    }
    dotNetFeatureSet.features = graphics;

    return dotNetFeatureSet;
}
