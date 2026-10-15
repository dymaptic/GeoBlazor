import { buildJsAttachmentInfoGenerated } from './attachmentInfo.gb';
import { buildDotNetAttachmentInfoGenerated } from './attachmentInfo.gb';

export function buildDotNetAttachmentInfo(jsObject: any): any {
    return buildDotNetAttachmentInfoGenerated(jsObject);
}

export function buildJsAttachmentInfo(dotNetObject: any): any {
    return buildJsAttachmentInfoGenerated(dotNetObject);
}
