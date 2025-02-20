// override generated code in this file
import Field from '@arcgis/core/layers/support/Field';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsField(dotNetObject: any): any {
    let jsField = new Field();

    if (hasValue(dotNetObject.alias)) {
        jsField.alias = dotNetObject.alias;
    }
    if (hasValue(dotNetObject.defaultValue)) {
        jsField.defaultValue = dotNetObject.defaultValue;
    }
    if (hasValue(dotNetObject.description)) {
        jsField.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.domain)) {
        jsField.domain = dotNetObject.domain;
    }
    if (hasValue(dotNetObject.editable)) {
        jsField.editable = dotNetObject.editable;
    }
    if (hasValue(dotNetObject.length)) {
        jsField.length = dotNetObject.length;
    }
    if (hasValue(dotNetObject.name)) {
        jsField.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.nullable)) {
        jsField.nullable = dotNetObject.nullable;
    }
    if (hasValue(dotNetObject.valueType)) {
        jsField.valueType = dotNetObject.valueType;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(fieldWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsField;

    let dnInstantiatedObject = buildDotNetField(jsField);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for Field', e);
    }

    return jsField;
}

export function buildDotNetField(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetField: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.alias)) {
        dotNetField.alias = jsObject.alias;
    }
    if (hasValue(jsObject.defaultValue)) {
        dotNetField.defaultValue = jsObject.defaultValue;
    }
    if (hasValue(jsObject.description)) {
        dotNetField.description = jsObject.description;
    }
    if (hasValue(jsObject.domain)) {
        dotNetField.domain = jsObject.domain;
    }
    if (hasValue(jsObject.editable)) {
        dotNetField.editable = jsObject.editable;
    }
    if (hasValue(jsObject.length)) {
        dotNetField.length = jsObject.length;
    }
    if (hasValue(jsObject.name)) {
        dotNetField.name = jsObject.name;
    }
    if (hasValue(jsObject.nullable)) {
        dotNetField.nullable = jsObject.nullable;
    }
    if (hasValue(jsObject.type)) {
        dotNetField.type = jsObject.type;
    }
    if (hasValue(jsObject.valueType)) {
        dotNetField.valueType = jsObject.valueType;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetField.id = k;
                break;
            }
        }
    }

    return dotNetField;
}
