// override generated code in this file
import WfsUtilsGenerated from './wfsUtils.gb';
import wfsUtils = __esri.wfsUtils;

export default class WfsUtilsWrapper extends WfsUtilsGenerated {

    constructor(component: wfsUtils) {
        super(component);
    }
    
}

export async function buildJsWfsUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWfsUtilsGenerated } = await import('./wfsUtils.gb');
    return await buildJsWfsUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWfsUtils(jsObject: any): Promise<any> {
    let { buildDotNetWfsUtilsGenerated } = await import('./wfsUtils.gb');
    return await buildDotNetWfsUtilsGenerated(jsObject);
}
