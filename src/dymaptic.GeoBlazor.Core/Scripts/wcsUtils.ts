// override generated code in this file
import WcsUtilsGenerated from './wcsUtils.gb';
import wcsUtils = __esri.wcsUtils;

export default class WcsUtilsWrapper extends WcsUtilsGenerated {

    constructor(component: wcsUtils) {
        super(component);
    }
    
}

export async function buildJsWcsUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWcsUtilsGenerated } = await import('./wcsUtils.gb');
    return await buildJsWcsUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWcsUtils(jsObject: any): Promise<any> {
    let { buildDotNetWcsUtilsGenerated } = await import('./wcsUtils.gb');
    return await buildDotNetWcsUtilsGenerated(jsObject);
}
