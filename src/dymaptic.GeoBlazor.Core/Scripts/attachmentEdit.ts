import { arcGisObjectRefs, buildJsGraphic, hasValue, jsObjectRefs, removeCircularReferences } from './geoBlazorCore';
import { buildDotNetGraphic } from './graphic';

export function buildJsAttachmentEdit(dotNetObject: any): any {
    if (!hasValue(dotNetObject)) {
            return null;
        }
    
        let jsAttachmentEdit: any = {};
        if (hasValue(dotNetObject.feature)) {
            jsAttachmentEdit.feature = buildJsGraphic(dotNetObject.feature) as any;
        }
    
        if (hasValue(dotNetObject.attachment)) {
            jsAttachmentEdit.attachment = dotNetObject.attachment;
        }
        
        jsObjectRefs[dotNetObject.id] = jsAttachmentEdit;
        arcGisObjectRefs[dotNetObject.id] = jsAttachmentEdit;
        
        return jsAttachmentEdit;
}     

export function buildDotNetAttachmentEdit(jsObject: any, layerId: string | null, viewId: string | null): any {
    if (!hasValue(jsObject)) {
            return null;
        }
        
        let dotNetAttachmentEdit: any = {};
        
        if (hasValue(jsObject.feature)) {
            dotNetAttachmentEdit.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
        }
        
        if (hasValue(jsObject.attachment)) {
            dotNetAttachmentEdit.attachment = removeCircularReferences(jsObject.attachment);
        }
    
        return dotNetAttachmentEdit;
}
