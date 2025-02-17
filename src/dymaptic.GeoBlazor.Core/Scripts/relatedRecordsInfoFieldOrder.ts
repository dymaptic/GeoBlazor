// override generated code in this file
import RelatedRecordsInfoFieldOrder from '@arcgis/core/popup/support/RelatedRecordsInfoFieldOrder';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsRelatedRecordsInfoFieldOrder(dotNetObject: any): any {
    let jsRelatedRecordsInfoFieldOrder = new RelatedRecordsInfoFieldOrder();

    if (hasValue(dotNetObject.field)) {
        jsRelatedRecordsInfoFieldOrder.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.order)) {
        jsRelatedRecordsInfoFieldOrder.order = dotNetObject.order;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(relatedRecordsInfoFieldOrderWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelatedRecordsInfoFieldOrder;

    let dnInstantiatedObject = buildDotNetRelatedRecordsInfoFieldOrder(jsRelatedRecordsInfoFieldOrder);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RelatedRecordsInfoFieldOrder', e);
    }

    return jsRelatedRecordsInfoFieldOrder;
}
export function buildDotNetRelatedRecordsInfoFieldOrder(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelatedRecordsInfoFieldOrder: any = {
        // @ts-ignore
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
