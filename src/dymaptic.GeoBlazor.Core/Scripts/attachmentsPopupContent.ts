// override generated code in this file
import AttachmentsContent from "@arcgis/core/popup/content/AttachmentsContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsAttachmentsPopupContent(dotNetObject: any): any {
    let jsAttachmentsContent = new AttachmentsContent();

    if (hasValue(dotNetObject.description)) {
        jsAttachmentsContent.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.displayType)) {
        jsAttachmentsContent.displayType = dotNetObject.displayType;
    }
    if (hasValue(dotNetObject.title)) {
        jsAttachmentsContent.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(attachmentsPopupContentWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsAttachmentsContent;

    let dnInstantiatedObject = buildDotNetAttachmentsPopupContent(jsAttachmentsContent);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for AttachmentsPopupContent', e);
    }

    return jsAttachmentsContent;
}

export function buildDotNetAttachmentsPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetAttachmentsPopupContent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };

    if (hasValue(jsObject.description)) {
        dotNetAttachmentsPopupContent.description = jsObject.description;
    }
    if (hasValue(jsObject.displayType)) {
        dotNetAttachmentsPopupContent.displayType = jsObject.displayType;
    }
    if (hasValue(jsObject.title)) {
        dotNetAttachmentsPopupContent.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetAttachmentsPopupContent.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetAttachmentsPopupContent.id = k;
                break;
            }
        }
    }

    return dotNetAttachmentsPopupContent;
}
