// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import RelatedRecordsInfo from '@arcgis/core/popup/RelatedRecordsInfo';
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetRelatedRecordsInfo } from './relatedRecordsInfo';

export async function buildJsRelatedRecordsInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.orderByFields) && dotNetObject.orderByFields.length > 0) {
        let { buildJsRelatedRecordsInfoFieldOrder } = await import('./relatedRecordsInfoFieldOrder');
        properties.orderByFields = dotNetObject.orderByFields.map(i => buildJsRelatedRecordsInfoFieldOrder(i)) as any;
    }

    if (hasValue(dotNetObject.showRelatedRecords)) {
        properties.showRelatedRecords = dotNetObject.showRelatedRecords;
    }
    let jsRelatedRecordsInfo = new RelatedRecordsInfo(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsRelatedRecordsInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelatedRecordsInfo;
    
    return jsRelatedRecordsInfo;
}


export async function buildDotNetRelatedRecordsInfoGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRelatedRecordsInfo: any = {};
    
    if (hasValue(jsObject.orderByFields)) {
        let { buildDotNetRelatedRecordsInfoFieldOrder } = await import('./relatedRecordsInfoFieldOrder');
        dotNetRelatedRecordsInfo.orderByFields = jsObject.orderByFields.map(i => buildDotNetRelatedRecordsInfoFieldOrder(i));
    }
    
    if (hasValue(jsObject.showRelatedRecords)) {
        dotNetRelatedRecordsInfo.showRelatedRecords = jsObject.showRelatedRecords;
    }
    

    return dotNetRelatedRecordsInfo;
}

