import VersionManagementViewModel from '@arcgis/core/widgets/VersionManagement/VersionManagementViewModel';
import VersionManagementViewModelGenerated from './versionManagementViewModel.gb';

export default class VersionManagementViewModelWrapper extends VersionManagementViewModelGenerated {

    constructor(component: VersionManagementViewModel) {
        super(component);
    }

}

export async function buildJsVersionManagementViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVersionManagementViewModelGenerated} = await import('./versionManagementViewModel.gb');
    return await buildJsVersionManagementViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVersionManagementViewModel(jsObject: any): Promise<any> {
    let {buildDotNetVersionManagementViewModelGenerated} = await import('./versionManagementViewModel.gb');
    return await buildDotNetVersionManagementViewModelGenerated(jsObject);
}
