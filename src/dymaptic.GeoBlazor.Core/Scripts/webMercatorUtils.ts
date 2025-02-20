// override generated code in this file
import WebMercatorUtilsGenerated from './webMercatorUtils.gb';
import webMercatorUtils = __esri.webMercatorUtils;

export default class WebMercatorUtilsWrapper extends WebMercatorUtilsGenerated {

    constructor(component: webMercatorUtils) {
        super(component);
    }

}

export async function buildJsWebMercatorUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebMercatorUtilsGenerated} = await import('./webMercatorUtils.gb');
    return await buildJsWebMercatorUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebMercatorUtils(jsObject: any): Promise<any> {
    let {buildDotNetWebMercatorUtilsGenerated} = await import('./webMercatorUtils.gb');
    return await buildDotNetWebMercatorUtilsGenerated(jsObject);
}
