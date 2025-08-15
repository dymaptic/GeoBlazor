// override generated code in this file

import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetFieldInfo, buildJsFieldInfo} from "./fieldInfo";

export function buildJsFieldsPopupContent(dotNetObject: any, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetObject.fieldInfos)) {
        properties.fieldInfos = dotNetObject.fieldInfos.map(i => buildJsFieldInfo(i)) as any;
    }

    if (hasValue(dotNetObject.description)) {
        properties.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsFieldsContent = new FieldsContent(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsFieldsContent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldsContent;

    return jsFieldsContent;
}

export function buildDotNetFieldsPopupContent(jsObject: any, viewId: string | null): any {
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
