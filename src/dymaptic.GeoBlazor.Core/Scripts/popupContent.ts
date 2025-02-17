// override generated code in this file
import {buildDotNetAttachmentsPopupContent, buildJsAttachmentsPopupContent} from "./attachmentsPopupContent";
import {buildDotNetExpressionPopupContent, buildJsExpressionPopupContent} from "./expressionPopupContent";
import {buildDotNetFieldsPopupContent, buildJsFieldsPopupContent} from "./fieldsPopupContent";
import {buildDotNetMediaPopupContent, buildJsMediaPopupContent} from "./mediaPopupContent";
import {buildJsRelationshipPopupContent} from "./relationshipPopupContent";
import {buildDotNetTextPopupContent, buildJsTextPopupContent} from "./textPopupContent";


export function buildJsPopupContent(dotNetObject: any): any {
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
        default:
            throw new Error('Unknown popup content type');
    }
}

export function buildDotNetPopupContent(jsObject: any): any {
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
        default:
            throw new Error('Unknown popup content type');
    }
}