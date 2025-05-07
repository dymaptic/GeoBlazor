// override generated code in this file
import WebMapGenerated from './webMap.gb';
import WebMap from '@arcgis/core/WebMap';

export default class WebMapWrapper extends WebMapGenerated {

    constructor(component: WebMap) {
        super(component);
    }
    
}

export async function buildJsWebMap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapGenerated } = await import('./webMap.gb');
    return await buildJsWebMapGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebMap(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWebMapGenerated } = await import('./webMap.gb');
    return await buildDotNetWebMapGenerated(jsObject, layerId, viewId);
}
