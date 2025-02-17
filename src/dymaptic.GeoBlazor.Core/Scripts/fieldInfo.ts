// override generated code in this file
import FieldInfo from '@arcgis/core/popup/FieldInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetFieldInfoFormat, buildJsFieldInfoFormat } from './fieldInfoFormat';

export function buildJsFieldInfo(dotNetObject: any): any {
    let jsFieldInfo = new FieldInfo();
    if (hasValue(dotNetObject.format)) {
        jsFieldInfo.format = buildJsFieldInfoFormat(dotNetObject.format) as any;
    }

    if (hasValue(dotNetObject.fieldName)) {
        jsFieldInfo.fieldName = dotNetObject.fieldName;
    }
    if (hasValue(dotNetObject.isEditable)) {
        jsFieldInfo.isEditable = dotNetObject.isEditable;
    }
    if (hasValue(dotNetObject.label)) {
        jsFieldInfo.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.statisticType)) {
        jsFieldInfo.statisticType = dotNetObject.statisticType;
    }
    if (hasValue(dotNetObject.stringFieldOption)) {
        jsFieldInfo.stringFieldOption = dotNetObject.stringFieldOption;
    }
    if (hasValue(dotNetObject.tooltip)) {
        jsFieldInfo.tooltip = dotNetObject.tooltip;
    }
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(fieldInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldInfo;

    let dnInstantiatedObject = buildDotNetFieldInfo(jsFieldInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FieldInfo', e);
    }

    return jsFieldInfo;
}
export function buildDotNetFieldInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFieldInfo: any = {
        // @ts-ignore
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
