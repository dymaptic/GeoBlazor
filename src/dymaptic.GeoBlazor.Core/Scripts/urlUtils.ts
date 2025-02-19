// override generated code in this file
import UrlUtilsGenerated from './urlUtils.gb';
import urlUtils = __esri.urlUtils;

export default class UrlUtilsWrapper extends UrlUtilsGenerated {

    constructor(component: urlUtils) {
        super(component);
    }
    
}

export async function buildJsUrlUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUrlUtilsGenerated } = await import('./urlUtils.gb');
    return await buildJsUrlUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUrlUtils(jsObject: any): Promise<any> {
    let { buildDotNetUrlUtilsGenerated } = await import('./urlUtils.gb');
    return await buildDotNetUrlUtilsGenerated(jsObject);
}
