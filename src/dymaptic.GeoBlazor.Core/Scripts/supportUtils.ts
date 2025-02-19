import supportUtils = __esri.supportUtils;
import SupportUtilsGenerated from './supportUtils.gb';

export default class SupportUtilsWrapper extends SupportUtilsGenerated {

    constructor(component: supportUtils) {
        super(component);
    }
    
}

export async function buildJsSupportUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportUtilsGenerated } = await import('./supportUtils.gb');
    return await buildJsSupportUtilsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSupportUtils(jsObject: any): Promise<any> {
    let { buildDotNetSupportUtilsGenerated } = await import('./supportUtils.gb');
    return await buildDotNetSupportUtilsGenerated(jsObject);
}
