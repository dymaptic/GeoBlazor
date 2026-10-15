// override generated code in this file
import VersionAdaptersUtilsGenerated from './versionAdaptersUtils.gb';
import versionAdaptersUtils = __esri.versionAdaptersUtils;

export default class VersionAdaptersUtilsWrapper extends VersionAdaptersUtilsGenerated {

    constructor(component: versionAdaptersUtils) {
        super(component);
    }
    
}

export async function buildJsVersionAdaptersUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionAdaptersUtilsGenerated } = await import('./versionAdaptersUtils.gb');
    return await buildJsVersionAdaptersUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionAdaptersUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionAdaptersUtilsGenerated } = await import('./versionAdaptersUtils.gb');
    return await buildDotNetVersionAdaptersUtilsGenerated(jsObject, layerId, viewId);
}
