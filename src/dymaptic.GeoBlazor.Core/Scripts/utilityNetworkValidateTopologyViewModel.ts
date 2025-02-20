// override generated code in this file
import UtilityNetworkValidateTopologyViewModelGenerated from './utilityNetworkValidateTopologyViewModel.gb';
import UtilityNetworkValidateTopologyViewModel
    from '@arcgis/core/widgets/UtilityNetworkValidateTopology/UtilityNetworkValidateTopologyViewModel';

export default class UtilityNetworkValidateTopologyViewModelWrapper extends UtilityNetworkValidateTopologyViewModelGenerated {

    constructor(component: UtilityNetworkValidateTopologyViewModel) {
        super(component);
    }

}

export async function buildJsUtilityNetworkValidateTopologyViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilityNetworkValidateTopologyViewModelGenerated} = await import('./utilityNetworkValidateTopologyViewModel.gb');
    return await buildJsUtilityNetworkValidateTopologyViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilityNetworkValidateTopologyViewModel(jsObject: any): Promise<any> {
    let {buildDotNetUtilityNetworkValidateTopologyViewModelGenerated} = await import('./utilityNetworkValidateTopologyViewModel.gb');
    return await buildDotNetUtilityNetworkValidateTopologyViewModelGenerated(jsObject);
}
