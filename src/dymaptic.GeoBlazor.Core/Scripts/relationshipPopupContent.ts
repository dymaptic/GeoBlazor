// override generated code in this file


import RelationshipContent from "@arcgis/core/popup/content/RelationshipContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {
    buildDotNetRelatedRecordsInfoFieldOrder,
    buildJsRelatedRecordsInfoFieldOrder
} from "./relatedRecordsInfoFieldOrder";

export function buildJsRelationshipPopupContent(dotNetObject: any): any {
    let jsRelationshipContent = new RelationshipContent();
    if (hasValue(dotNetObject.orderByFields)) {
        jsRelationshipContent.orderByFields = dotNetObject.orderByFields.map(i => buildJsRelatedRecordsInfoFieldOrder(i)) as any;
    }

    if (hasValue(dotNetObject.description)) {
        jsRelationshipContent.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.displayCount)) {
        jsRelationshipContent.displayCount = dotNetObject.displayCount;
    }
    if (hasValue(dotNetObject.displayType)) {
        jsRelationshipContent.displayType = dotNetObject.displayType;
    }
    if (hasValue(dotNetObject.relationshipId)) {
        jsRelationshipContent.relationshipId = dotNetObject.relationshipId;
    }
    if (hasValue(dotNetObject.title)) {
        jsRelationshipContent.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(relationshipPopupContentWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelationshipContent;

    let dnInstantiatedObject = buildDotNetRelationshipPopupContent(jsRelationshipContent);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RelationshipPopupContent', e);
    }

    return jsRelationshipContent;
}

export function buildDotNetRelationshipPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelationshipPopupContent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.orderByFields)) {
        dotNetRelationshipPopupContent.orderByFields = jsObject.orderByFields.map(i => buildDotNetRelatedRecordsInfoFieldOrder(i));
    }
    dotNetRelationshipPopupContent.type = jsObject.type;
    if (hasValue(jsObject.description)) {
        dotNetRelationshipPopupContent.description = jsObject.description;
    }
    if (hasValue(jsObject.displayCount)) {
        dotNetRelationshipPopupContent.displayCount = jsObject.displayCount;
    }
    if (hasValue(jsObject.displayType)) {
        dotNetRelationshipPopupContent.displayType = jsObject.displayType;
    }
    if (hasValue(jsObject.relationshipId)) {
        dotNetRelationshipPopupContent.relationshipId = jsObject.relationshipId;
    }
    if (hasValue(jsObject.title)) {
        dotNetRelationshipPopupContent.title = jsObject.title;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRelationshipPopupContent.id = k;
                break;
            }
        }
    }

    return dotNetRelationshipPopupContent;
}
