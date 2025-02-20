// override generated code in this file
import VersionManagementServiceGenerated from './versionManagementService.gb';
import VersionManagementService from '@arcgis/core/versionManagement/VersionManagementService';

export default class VersionManagementServiceWrapper extends VersionManagementServiceGenerated {

    constructor(component: VersionManagementService) {
        super(component);
    }

}

export async function buildJsVersionManagementService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVersionManagementServiceGenerated} = await import('./versionManagementService.gb');
    return await buildJsVersionManagementServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVersionManagementService(jsObject: any): Promise<any> {
    let {buildDotNetVersionManagementServiceGenerated} = await import('./versionManagementService.gb');
    return await buildDotNetVersionManagementServiceGenerated(jsObject);
}
