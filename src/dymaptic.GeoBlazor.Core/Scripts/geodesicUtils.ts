// override generated code in this file
import GeodesicUtilsGenerated from './geodesicUtils.gb';
import geodesicUtils = __esri.geodesicUtils;

export default class GeodesicUtilsWrapper extends GeodesicUtilsGenerated {

    constructor(component: geodesicUtils) {
        super(component);
    }

}

export async function buildJsGeodesicUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeodesicUtilsGenerated} = await import('./geodesicUtils.gb');
    return await buildJsGeodesicUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeodesicUtils(jsObject: any): Promise<any> {
    let {buildDotNetGeodesicUtilsGenerated} = await import('./geodesicUtils.gb');
    return await buildDotNetGeodesicUtilsGenerated(jsObject);
}
