import devEnvironmentUtils = __esri.devEnvironmentUtils;
import DevEnvironmentUtilsGenerated from './devEnvironmentUtils.gb';

export default class DevEnvironmentUtilsWrapper extends DevEnvironmentUtilsGenerated {

    constructor(component: devEnvironmentUtils) {
        super(component);
    }
    
}

export async function buildJsDevEnvironmentUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDevEnvironmentUtilsGenerated } = await import('./devEnvironmentUtils.gb');
    return await buildJsDevEnvironmentUtilsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDevEnvironmentUtils(jsObject: any): Promise<any> {
    let { buildDotNetDevEnvironmentUtilsGenerated } = await import('./devEnvironmentUtils.gb');
    return await buildDotNetDevEnvironmentUtilsGenerated(jsObject);
}
