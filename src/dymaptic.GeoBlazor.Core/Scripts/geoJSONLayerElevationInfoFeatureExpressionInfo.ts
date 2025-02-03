// override generated code in this file
import GeoJSONLayerElevationInfoFeatureExpressionInfoGenerated from './geoJSONLayerElevationInfoFeatureExpressionInfo.gb';
import GeoJSONLayerElevationInfoFeatureExpressionInfo = __esri.GeoJSONLayerElevationInfoFeatureExpressionInfo;

export default class GeoJSONLayerElevationInfoFeatureExpressionInfoWrapper extends GeoJSONLayerElevationInfoFeatureExpressionInfoGenerated {

    constructor(component: GeoJSONLayerElevationInfoFeatureExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}
export async function buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./geoJSONLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
