// override generated code in this file
import BatchAttributeFormViewModelGenerated from './batchAttributeFormViewModel.gb';
import BatchAttributeFormViewModel from '@arcgis/core/widgets/BatchAttributeForm/BatchAttributeFormViewModel';

export default class BatchAttributeFormViewModelWrapper extends BatchAttributeFormViewModelGenerated {

    constructor(component: BatchAttributeFormViewModel) {
        super(component);
    }
    
}

export async function buildJsBatchAttributeFormViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBatchAttributeFormViewModelGenerated } = await import('./batchAttributeFormViewModel.gb');
    return await buildJsBatchAttributeFormViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBatchAttributeFormViewModel(jsObject: any): Promise<any> {
    let { buildDotNetBatchAttributeFormViewModelGenerated } = await import('./batchAttributeFormViewModel.gb');
    return await buildDotNetBatchAttributeFormViewModelGenerated(jsObject);
}
