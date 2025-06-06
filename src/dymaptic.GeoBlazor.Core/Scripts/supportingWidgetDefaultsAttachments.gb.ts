// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetSupportingWidgetDefaultsAttachments } from './supportingWidgetDefaultsAttachments';

export async function buildJsSupportingWidgetDefaultsAttachmentsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSupportingWidgetDefaultsAttachments: any = {};
    if (hasValue(dotNetObject.capabilities)) {
        let { buildJsAttachmentsCapabilities } = await import('./attachmentsCapabilities');
        jsSupportingWidgetDefaultsAttachments.capabilities = await buildJsAttachmentsCapabilities(dotNetObject.capabilities, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.displayType)) {
        jsSupportingWidgetDefaultsAttachments.displayType = dotNetObject.displayType;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSupportingWidgetDefaultsAttachments);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSupportingWidgetDefaultsAttachments;
    
    return jsSupportingWidgetDefaultsAttachments;
}


export async function buildDotNetSupportingWidgetDefaultsAttachmentsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSupportingWidgetDefaultsAttachments: any = {};
    
    if (hasValue(jsObject.capabilities)) {
        let { buildDotNetAttachmentsCapabilities } = await import('./attachmentsCapabilities');
        dotNetSupportingWidgetDefaultsAttachments.capabilities = await buildDotNetAttachmentsCapabilities(jsObject.capabilities);
    }
    
    if (hasValue(jsObject.displayType)) {
        dotNetSupportingWidgetDefaultsAttachments.displayType = jsObject.displayType;
    }
    

    return dotNetSupportingWidgetDefaultsAttachments;
}

