// override generated code in this file
import AttachmentsViewOptionsGenerated from './attachmentsViewOptions.gb';
import AttachmentsViewOptions from '@arcgis/core/widgets/FeatureTable/support/AttachmentsViewOptions';

export default class AttachmentsViewOptionsWrapper extends AttachmentsViewOptionsGenerated {

    constructor(component: AttachmentsViewOptions) {
        super(component);
    }
    
}

export async function buildJsAttachmentsViewOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsViewOptionsGenerated } = await import('./attachmentsViewOptions.gb');
    return await buildJsAttachmentsViewOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsViewOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsViewOptionsGenerated } = await import('./attachmentsViewOptions.gb');
    return await buildDotNetAttachmentsViewOptionsGenerated(jsObject, layerId, viewId);
}
