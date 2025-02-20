// override generated code in this file

import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetFieldInfo, buildJsFieldInfo} from "./fieldInfo";

export function buildJsFieldsPopupContent(dotNetObject: any): any {
    let jsFieldsContent = new FieldsContent();
    if (hasValue(dotNetObject.fieldInfos)) {
        jsFieldsContent.fieldInfos = dotNetObject.fieldInfos.map(i => buildJsFieldInfo(i)) as any;
    }

    if (hasValue(dotNetObject.description)) {
        jsFieldsContent.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.title)) {
        jsFieldsContent.title = dotNetObject.title;
    }

        let jsObjectRef = DotNet.createJSObjectReference(jsFieldsContent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldsContent;

    let dnInstantiatedObject = buildDotNetFieldsPopupContent(jsFieldsContent);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FieldsPopupContent', e);
    }

    return jsFieldsContent;
}

export function buildDotNetFieldsPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFieldsPopupContent: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.fieldInfos)) {
        dotNetFieldsPopupContent.fieldInfos = jsObject.fieldInfos.map(i => buildDotNetFieldInfo(i));
    }
    if (hasValue(jsObject.description)) {
        dotNetFieldsPopupContent.description = jsObject.description;
    }
    if (hasValue(jsObject.title)) {
        dotNetFieldsPopupContent.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetFieldsPopupContent.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFieldsPopupContent.id = k;
                break;
            }
        }
    }

    return dotNetFieldsPopupContent;
}
