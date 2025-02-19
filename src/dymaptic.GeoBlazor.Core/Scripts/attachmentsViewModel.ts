import AttachmentsViewModel from '@arcgis/core/widgets/Attachments/AttachmentsViewModel';
import AttachmentsViewModelGenerated from './attachmentsViewModel.gb';

export default class AttachmentsViewModelWrapper extends AttachmentsViewModelGenerated {

    constructor(component: AttachmentsViewModel) {
        super(component);
    }
    
}

export async function buildJsAttachmentsViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsViewModelGenerated } = await import('./attachmentsViewModel.gb');
    return await buildJsAttachmentsViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetAttachmentsViewModel(jsObject: any): Promise<any> {
    let { buildDotNetAttachmentsViewModelGenerated } = await import('./attachmentsViewModel.gb');
    return await buildDotNetAttachmentsViewModelGenerated(jsObject);
}
