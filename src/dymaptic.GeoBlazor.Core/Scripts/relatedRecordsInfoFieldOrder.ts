// override generated code in this file
import RelatedRecordsInfoFieldOrderGenerated from './relatedRecordsInfoFieldOrder.gb';
import RelatedRecordsInfoFieldOrder from '@arcgis/core/popup/support/RelatedRecordsInfoFieldOrder';

export default class RelatedRecordsInfoFieldOrderWrapper extends RelatedRecordsInfoFieldOrderGenerated {

    constructor(component: RelatedRecordsInfoFieldOrder) {
        super(component);
    }
    
}              
export async function buildJsRelatedRecordsInfoFieldOrder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelatedRecordsInfoFieldOrderGenerated } = await import('./relatedRecordsInfoFieldOrder.gb');
    return await buildJsRelatedRecordsInfoFieldOrderGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelatedRecordsInfoFieldOrder(jsObject: any): Promise<any> {
    let { buildDotNetRelatedRecordsInfoFieldOrderGenerated } = await import('./relatedRecordsInfoFieldOrder.gb');
    return await buildDotNetRelatedRecordsInfoFieldOrderGenerated(jsObject);
}
