// override generated code in this file
import {buildDotNetAttachmentsPopupContent, buildJsAttachmentsPopupContent} from "./attachmentsPopupContent";
import {buildDotNetExpressionPopupContent, buildJsExpressionPopupContent} from "./expressionPopupContent";
import {buildDotNetFieldsPopupContent, buildJsFieldsPopupContent} from "./fieldsPopupContent";
import {buildDotNetMediaPopupContent, buildJsMediaPopupContent} from "./mediaPopupContent";
import {buildJsRelationshipPopupContent} from "./relationshipPopupContent";
import {buildDotNetTextPopupContent, buildJsTextPopupContent} from "./textPopupContent";
import {buildJsCustomPopupContent, buildDotNetCustomPopupContent} from "./customPopupContent";
import {sanitize} from "./arcGisJsInterop";


export function buildJsPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    switch (dotNetObject?.type) {
        case 'attachments':
            return buildJsAttachmentsPopupContent(dotNetObject);
        case 'expression':
            return buildJsExpressionPopupContent(dotNetObject);
        case 'fields':
            return buildJsFieldsPopupContent(dotNetObject);
        case 'media':
            return buildJsMediaPopupContent(dotNetObject);
        case 'relationship':
            return buildJsRelationshipPopupContent(dotNetObject);
        case 'text':
            return buildJsTextPopupContent(dotNetObject);
        case 'custom':
            return buildJsCustomPopupContent(dotNetObject, layerId, viewId);
        default:
            return sanitize(dotNetObject);
    }
}

export function buildDotNetPopupContent(jsObject: any, viewId: string | null): any {
    switch (jsObject?.type) {
        case 'attachments':
            return buildDotNetAttachmentsPopupContent(jsObject);
        case 'expression':
            return buildDotNetExpressionPopupContent(jsObject);
        case 'fields':
            return buildDotNetFieldsPopupContent(jsObject);
        case 'media':
            return buildDotNetMediaPopupContent(jsObject);
        case 'text':
            return buildDotNetTextPopupContent(jsObject);
        case 'custom':
            return buildDotNetCustomPopupContent(jsObject);
        default:
            return jsObject;
    }
}
