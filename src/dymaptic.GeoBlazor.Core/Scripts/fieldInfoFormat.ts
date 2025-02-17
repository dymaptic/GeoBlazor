// override generated code in this file
           
import FieldInfoFormat from "@arcgis/core/popup/support/FieldInfoFormat";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsFieldInfoFormat(dotNetObject: any): any {
    let jsFieldInfoFormat = new FieldInfoFormat();

    if (hasValue(dotNetObject.dateFormat)) {
        jsFieldInfoFormat.dateFormat = dotNetObject.dateFormat;
    }
    if (hasValue(dotNetObject.digitSeparator)) {
        jsFieldInfoFormat.digitSeparator = dotNetObject.digitSeparator;
    }
    if (hasValue(dotNetObject.places)) {
        jsFieldInfoFormat.places = dotNetObject.places;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(fieldInfoFormatWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldInfoFormat;

    let dnInstantiatedObject = buildDotNetFieldInfoFormat(jsFieldInfoFormat);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FieldInfoFormat', e);
    }

    return jsFieldInfoFormat;
}
export function buildDotNetFieldInfoFormat(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFieldInfoFormat: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.dateFormat)) {
        dotNetFieldInfoFormat.dateFormat = jsObject.dateFormat;
    }
    if (hasValue(jsObject.digitSeparator)) {
        dotNetFieldInfoFormat.digitSeparator = jsObject.digitSeparator;
    }
    if (hasValue(jsObject.places)) {
        dotNetFieldInfoFormat.places = jsObject.places;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFieldInfoFormat.id = k;
                break;
            }
        }
    }

    return dotNetFieldInfoFormat;
}
