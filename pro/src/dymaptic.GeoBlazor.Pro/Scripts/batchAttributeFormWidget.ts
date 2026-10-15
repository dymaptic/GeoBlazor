// override generated code in this file
import BatchAttributeFormWidgetGenerated from './batchAttributeFormWidget.gb';
import BatchAttributeForm from '@arcgis/core/widgets/BatchAttributeForm';

export default class BatchAttributeFormWidgetWrapper extends BatchAttributeFormWidgetGenerated {

    constructor(widget: BatchAttributeForm) {
        super(widget);
    }
    
}

export async function buildJsBatchAttributeFormWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBatchAttributeFormWidgetGenerated } = await import('./batchAttributeFormWidget.gb');
    return await buildJsBatchAttributeFormWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBatchAttributeFormWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBatchAttributeFormWidgetGenerated } = await import('./batchAttributeFormWidget.gb');
    return await buildDotNetBatchAttributeFormWidgetGenerated(jsObject, layerId, viewId);
}
