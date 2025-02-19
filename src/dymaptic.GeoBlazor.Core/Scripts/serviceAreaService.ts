// override generated code in this file
import ServiceAreaServiceGenerated from './serviceAreaService.gb';
import serviceArea = __esri.serviceArea;

export default class ServiceAreaServiceWrapper extends ServiceAreaServiceGenerated {

    constructor(component: serviceArea) {
        super(component);
    }
    
}

export async function buildJsServiceAreaService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceAreaServiceGenerated } = await import('./serviceAreaService.gb');
    return await buildJsServiceAreaServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceAreaService(jsObject: any): Promise<any> {
    let { buildDotNetServiceAreaServiceGenerated } = await import('./serviceAreaService.gb');
    return await buildDotNetServiceAreaServiceGenerated(jsObject);
}
