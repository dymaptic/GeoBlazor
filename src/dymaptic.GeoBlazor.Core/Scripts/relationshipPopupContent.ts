// override generated code in this file


import RelationshipContent from "@arcgis/core/popup/content/RelationshipContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {
    buildDotNetRelatedRecordsInfoFieldOrder,
    buildJsRelatedRecordsInfoFieldOrder
} from "./relatedRecordsInfoFieldOrder";

export function buildJsRelationshipPopupContent(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.orderByFields)) {
        properties.orderByFields = dotNetObject.orderByFields.map(i => buildJsRelatedRecordsInfoFieldOrder(i)) as any;
    }
    if (hasValue(dotNetObject.description)) {
        properties.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.displayCount)) {
        properties.displayCount = dotNetObject.displayCount;
    }
    if (hasValue(dotNetObject.displayType)) {
        properties.displayType = dotNetObject.displayType;
    }
    if (hasValue(dotNetObject.relationshipId)) {
        properties.relationshipId = dotNetObject.relationshipId;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsRelationshipContent = new RelationshipContent(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsRelationshipContent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelationshipContent;

    return jsRelationshipContent;
}

export function buildDotNetRelationshipPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelationshipPopupContent: any = {
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
