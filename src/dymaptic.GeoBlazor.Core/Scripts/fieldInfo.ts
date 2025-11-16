// override generated code in this file
import FieldInfo from '@arcgis/core/popup/FieldInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetFieldInfoFormat, buildJsFieldInfoFormat} from './fieldInfoFormat';

export function buildJsFieldInfo(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.format)) {
        properties.format = buildJsFieldInfoFormat(dotNetObject.format) as any;
    }

    if (hasValue(dotNetObject.fieldName)) {
        properties.fieldName = dotNetObject.fieldName;
    }
    if (hasValue(dotNetObject.isEditable)) {
        properties.isEditable = dotNetObject.isEditable;
    }
    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.statisticType)) {
        properties.statisticType = dotNetObject.statisticType;
    }
    if (hasValue(dotNetObject.stringFieldOption)) {
        properties.stringFieldOption = dotNetObject.stringFieldOption;
    }
    if (hasValue(dotNetObject.tooltip)) {
        properties.tooltip = dotNetObject.tooltip;
    }

    let jsFieldInfo = new FieldInfo(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsFieldInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldInfo;

    return jsFieldInfo;
}

export function buildDotNetFieldInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFieldInfo: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.format)) {
        dotNetFieldInfo.format = buildDotNetFieldInfoFormat(jsObject.format);
    }
    if (hasValue(jsObject.fieldName)) {
        dotNetFieldInfo.fieldName = jsObject.fieldName;
    }
    if (hasValue(jsObject.isEditable)) {
        dotNetFieldInfo.isEditable = jsObject.isEditable;
    }
    if (hasValue(jsObject.label)) {
        dotNetFieldInfo.label = jsObject.label;
    }
    if (hasValue(jsObject.statisticType)) {
        dotNetFieldInfo.statisticType = jsObject.statisticType;
    }
    if (hasValue(jsObject.stringFieldOption)) {
        dotNetFieldInfo.stringFieldOption = jsObject.stringFieldOption;
    }
    if (hasValue(jsObject.tooltip)) {
        dotNetFieldInfo.tooltip = jsObject.tooltip;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFieldInfo.id = k;
                break;
            }
        }
    }

    return dotNetFieldInfo;
}
