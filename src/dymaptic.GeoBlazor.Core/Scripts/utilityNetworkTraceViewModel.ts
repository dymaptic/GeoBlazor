// override generated code in this file
import UtilityNetworkTraceViewModelGenerated from './utilityNetworkTraceViewModel.gb';
import UtilityNetworkTraceViewModel from '@arcgis/core/widgets/UtilityNetworkTrace/UtilityNetworkTraceViewModel';

export default class UtilityNetworkTraceViewModelWrapper extends UtilityNetworkTraceViewModelGenerated {

    constructor(component: UtilityNetworkTraceViewModel) {
        super(component);
    }
    
}

export async function buildJsUtilityNetworkTraceViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkTraceViewModelGenerated } = await import('./utilityNetworkTraceViewModel.gb');
    return await buildJsUtilityNetworkTraceViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkTraceViewModel(jsObject: any): Promise<any> {
    let { buildDotNetUtilityNetworkTraceViewModelGenerated } = await import('./utilityNetworkTraceViewModel.gb');
    return await buildDotNetUtilityNetworkTraceViewModelGenerated(jsObject);
}
