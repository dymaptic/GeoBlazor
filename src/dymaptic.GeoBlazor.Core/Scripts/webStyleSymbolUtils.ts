// override generated code in this file
import WebStyleSymbolUtilsGenerated from './webStyleSymbolUtils.gb';
import webStyleSymbolUtils = __esri.webStyleSymbolUtils;

export default class WebStyleSymbolUtilsWrapper extends WebStyleSymbolUtilsGenerated {

    constructor(component: webStyleSymbolUtils) {
        super(component);
    }

}

export async function buildJsWebStyleSymbolUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebStyleSymbolUtilsGenerated} = await import('./webStyleSymbolUtils.gb');
    return await buildJsWebStyleSymbolUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebStyleSymbolUtils(jsObject: any): Promise<any> {
    let {buildDotNetWebStyleSymbolUtilsGenerated} = await import('./webStyleSymbolUtils.gb');
    return await buildDotNetWebStyleSymbolUtilsGenerated(jsObject);
}
