import normalizeUtils = __esri.normalizeUtils;
import NormalizeUtilsGenerated from './normalizeUtils.gb';

export default class NormalizeUtilsWrapper extends NormalizeUtilsGenerated {

    constructor(component: normalizeUtils) {
        super(component);
    }
    
}

export async function buildJsNormalizeUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNormalizeUtilsGenerated } = await import('./normalizeUtils.gb');
    return await buildJsNormalizeUtilsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetNormalizeUtils(jsObject: any): Promise<any> {
    let { buildDotNetNormalizeUtilsGenerated } = await import('./normalizeUtils.gb');
    return await buildDotNetNormalizeUtilsGenerated(jsObject);
}
