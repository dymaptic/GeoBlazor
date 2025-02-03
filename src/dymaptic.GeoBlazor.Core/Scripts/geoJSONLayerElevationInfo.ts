// override generated code in this file
import GeoJSONLayerElevationInfoGenerated from './geoJSONLayerElevationInfo.gb';
import GeoJSONLayerElevationInfo = __esri.GeoJSONLayerElevationInfo;

export default class GeoJSONLayerElevationInfoWrapper extends GeoJSONLayerElevationInfoGenerated {

    constructor(component: GeoJSONLayerElevationInfo) {
        super(component);
    }
    
}              
export async function buildJsGeoJSONLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildJsGeoJSONLayerElevationInfoGenerated(dotNetObject);
}
export async function buildDotNetGeoJSONLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetGeoJSONLayerElevationInfoGenerated } = await import('./geoJSONLayerElevationInfo.gb');
    return await buildDotNetGeoJSONLayerElevationInfoGenerated(jsObject);
}
