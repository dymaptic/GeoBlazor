// override generated code in this file
import RequestServiceGenerated from './requestService.gb';
import request from '@arcgis/core/request';

export default class RequestServiceWrapper extends RequestServiceGenerated {

    constructor(component: request) {
        super(component);
    }
    
}

export async function buildJsRequestService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRequestServiceGenerated } = await import('./requestService.gb');
    return await buildJsRequestServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRequestService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRequestServiceGenerated } = await import('./requestService.gb');
    return await buildDotNetRequestServiceGenerated(jsObject, layerId, viewId);
}
