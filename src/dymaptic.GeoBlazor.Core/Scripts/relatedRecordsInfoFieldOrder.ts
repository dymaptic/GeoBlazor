// override generated code in this file
import RelatedRecordsInfoFieldOrder from '@arcgis/core/popup/support/RelatedRecordsInfoFieldOrder';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';

export function buildJsRelatedRecordsInfoFieldOrder(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.field)) {
        properties.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.order)) {
        properties.order = dotNetObject.order;
    }

    let jsRelatedRecordsInfoFieldOrder = new RelatedRecordsInfoFieldOrder(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsRelatedRecordsInfoFieldOrder);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelatedRecordsInfoFieldOrder;

    return jsRelatedRecordsInfoFieldOrder;
}

export function buildDotNetRelatedRecordsInfoFieldOrder(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelatedRecordsInfoFieldOrder: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.field)) {
        dotNetRelatedRecordsInfoFieldOrder.field = jsObject.field;
    }
    if (hasValue(jsObject.order)) {
        dotNetRelatedRecordsInfoFieldOrder.order = jsObject.order;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRelatedRecordsInfoFieldOrder.id = k;
                break;
            }
        }
    }

    return dotNetRelatedRecordsInfoFieldOrder;
}
