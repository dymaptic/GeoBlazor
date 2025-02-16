// override generated code in this file
import FeatureSetGenerated from './featureSet.gb';
import FeatureSet from '@arcgis/core/rest/support/FeatureSet';
import {DotNetFeatureSet, DotNetGraphic} from "./definitions";
import {buildDotNetGeometry} from "./geometry";
import {buildDotNetSpatialReference} from "./spatialReference";
import {buildDotNetGraphic} from "./graphic";
import {dotNetRefs, graphicsRefs} from "./arcGisJsInterop";

export default class FeatureSetWrapper extends FeatureSetGenerated {

    constructor(component: FeatureSet) {
        super(component);
    }
    
}

export async function buildDotNetFeatureSet(jsFs: FeatureSet, layerId: string | null, viewId: string | null): Promise<DotNetFeatureSet> {
    let dotNetFeatureSet: DotNetFeatureSet = {
        features: [],
        displayFieldName: jsFs.displayFieldName,
        exceededTransferLimit: jsFs.exceededTransferLimit,
        fields: jsFs.fields,
        geometryType: jsFs.geometryType,
        queryGeometry: buildDotNetGeometry(jsFs.queryGeometry),
        spatialReference: buildDotNetSpatialReference(jsFs.spatialReference)
    };
    let graphics: DotNetGraphic[] = [];
    for (let i = 0; i < jsFs.features.length; i++) {
        let feature = jsFs.features[i];
        let graphic: DotNetGraphic = await buildDotNetGraphic(feature, layerId, viewId) as DotNetGraphic;
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