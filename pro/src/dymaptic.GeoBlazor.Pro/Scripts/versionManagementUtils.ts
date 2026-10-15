// override generated code in this file
import VersionManagementUtilsGenerated from './versionManagementUtils.gb';
import versionManagementUtils = __esri.versionManagementUtils;

export default class VersionManagementUtilsWrapper extends VersionManagementUtilsGenerated {

    constructor(component: versionManagementUtils) {
        super(component);
    }
    
}

export async function buildJsVersionManagementUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionManagementUtilsGenerated } = await import('./versionManagementUtils.gb');
    return await buildJsVersionManagementUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionManagementUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVersionManagementUtilsGenerated } = await import('./versionManagementUtils.gb');
    return await buildDotNetVersionManagementUtilsGenerated(jsObject, layerId, viewId);
}
