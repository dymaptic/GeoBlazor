import versionAdaptersUtils = __esri.versionAdaptersUtils;
import VersionAdaptersUtilsGenerated from './versionAdaptersUtils.gb';

export default class VersionAdaptersUtilsWrapper extends VersionAdaptersUtilsGenerated {

    constructor(component: versionAdaptersUtils) {
        super(component);
    }
    
}

export async function buildJsVersionAdaptersUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionAdaptersUtilsGenerated } = await import('./versionAdaptersUtils.gb');
    return await buildJsVersionAdaptersUtilsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVersionAdaptersUtils(jsObject: any): Promise<any> {
    let { buildDotNetVersionAdaptersUtilsGenerated } = await import('./versionAdaptersUtils.gb');
    return await buildDotNetVersionAdaptersUtilsGenerated(jsObject);
}
