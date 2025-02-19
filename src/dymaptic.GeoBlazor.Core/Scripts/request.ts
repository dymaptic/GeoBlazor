// override generated code in this file
import RequestGenerated from './request.gb';
import request from '@arcgis/core/request';

export default class RequestWrapper extends RequestGenerated {

    constructor(component: request) {
        super(component);
    }
    
}

export async function buildJsRequest(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRequestGenerated } = await import('./request.gb');
    return await buildJsRequestGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRequest(jsObject: any): Promise<any> {
    let { buildDotNetRequestGenerated } = await import('./request.gb');
    return await buildDotNetRequestGenerated(jsObject);
}
