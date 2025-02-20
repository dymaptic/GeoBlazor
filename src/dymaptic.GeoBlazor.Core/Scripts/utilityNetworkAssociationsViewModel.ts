// override generated code in this file
import UtilityNetworkAssociationsViewModelGenerated from './utilityNetworkAssociationsViewModel.gb';
import UtilityNetworkAssociationsViewModel
    from '@arcgis/core/widgets/UtilityNetworkAssociations/UtilityNetworkAssociationsViewModel';

export default class UtilityNetworkAssociationsViewModelWrapper extends UtilityNetworkAssociationsViewModelGenerated {

    constructor(component: UtilityNetworkAssociationsViewModel) {
        super(component);
    }

}

export async function buildJsUtilityNetworkAssociationsViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilityNetworkAssociationsViewModelGenerated} = await import('./utilityNetworkAssociationsViewModel.gb');
    return await buildJsUtilityNetworkAssociationsViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilityNetworkAssociationsViewModel(jsObject: any): Promise<any> {
    let {buildDotNetUtilityNetworkAssociationsViewModelGenerated} = await import('./utilityNetworkAssociationsViewModel.gb');
    return await buildDotNetUtilityNetworkAssociationsViewModelGenerated(jsObject);
}
