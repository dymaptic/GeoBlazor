import versionManagementUtils = __esri.versionManagementUtils;
import VersionManagementUtilsGenerated from './versionManagementUtils.gb';

export default class VersionManagementUtilsWrapper extends VersionManagementUtilsGenerated {

    constructor(component: versionManagementUtils) {
        super(component);
    }

}

export async function buildJsVersionManagementUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVersionManagementUtilsGenerated} = await import('./versionManagementUtils.gb');
    return await buildJsVersionManagementUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVersionManagementUtils(jsObject: any): Promise<any> {
    let {buildDotNetVersionManagementUtilsGenerated} = await import('./versionManagementUtils.gb');
    return await buildDotNetVersionManagementUtilsGenerated(jsObject);
}
