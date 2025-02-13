import {buildDotNetGeometry} from "./geometry";
import {buildDotNetSpatialReference} from "./spatialReference";
import {buildDotNetGraphic} from "./graphic";
import {copyValuesIfExists, dotNetRefs, hasValue} from "./arcGisJsInterop";
import {buildDotNetExtent} from "./extent";

export async function buildDotNetDirectionsFeatureSet(jsFs: any, viewId: string | null): Promise<any> {
    let dotNetFeatureSet: any = {
        features: [],
        displayFieldName: jsFs.displayFieldName,
        exceededTransferLimit: jsFs.exceededTransferLimit,
        fields: jsFs.fields,
        geometryType: jsFs.geometryType,
        queryGeometry: buildDotNetGeometry(jsFs.queryGeometry),
        spatialReference: buildDotNetSpatialReference(jsFs.spatialReference)
    };
    let graphics: any[] = [];
    for (let i = 0; i < jsFs.features.length; i++) {
        let feature = jsFs.features[i];
        let graphic = buildDotNetGraphic(feature, null, null);
        if (viewId !== undefined && viewId !== null) {
            graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
        }
        graphics.push(graphic);
    }
    dotNetFeatureSet.features = graphics;
    if (hasValue(jsFs.extent)) {
        dotNetFeatureSet.extent = buildDotNetExtent(jsFs.extent);
    }
    if (hasValue(jsFs.mergedGeometry)) {
        dotNetFeatureSet.mergedGeometry = buildDotNetGeometry(jsFs.mergedGeometry);
    }

    copyValuesIfExists(jsFs, dotNetFeatureSet, 'routeId', 'routeName', 'strings',
        'totalDriveTime', 'totalLength', 'totalTime');

    return dotNetFeatureSet;
}