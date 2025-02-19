// override generated code in this file
import GeoprocessingServiceGenerated from './geoprocessingService.gb';
import geoprocessor = __esri.geoprocessor;

export default class GeoprocessingServiceWrapper extends GeoprocessingServiceGenerated {

    constructor(component: geoprocessor) {
        super(component);
    }
    
}

export async function buildJsGeoprocessingService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoprocessingServiceGenerated } = await import('./geoprocessingService.gb');
    return await buildJsGeoprocessingServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoprocessingService(jsObject: any): Promise<any> {
    let { buildDotNetGeoprocessingServiceGenerated } = await import('./geoprocessingService.gb');
    return await buildDotNetGeoprocessingServiceGenerated(jsObject);
}
