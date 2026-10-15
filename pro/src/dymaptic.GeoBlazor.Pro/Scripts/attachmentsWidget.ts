// override generated code in this file
import AttachmentsWidgetGenerated from './attachmentsWidget.gb';
import Attachments from '@arcgis/core/widgets/Attachments';

export default class AttachmentsWidgetWrapper extends AttachmentsWidgetGenerated {

    constructor(widget: Attachments) {
        super(widget);
    }
    
}

export async function buildJsAttachmentsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsWidgetGenerated } = await import('./attachmentsWidget.gb');
    return await buildJsAttachmentsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsWidgetGenerated } = await import('./attachmentsWidget.gb');
    return await buildDotNetAttachmentsWidgetGenerated(jsObject, layerId, viewId);
}
