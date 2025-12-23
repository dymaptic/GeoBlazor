// override generated code in this file

import FieldInfoFormat from "@arcgis/core/popup/support/FieldInfoFormat";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';

export function buildJsFieldInfoFormat(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.dateFormat)) {
        properties.dateFormat = dotNetObject.dateFormat;
    }
    if (hasValue(dotNetObject.digitSeparator)) {
        properties.digitSeparator = dotNetObject.digitSeparator;
    }
    if (hasValue(dotNetObject.places)) {
        properties.places = dotNetObject.places;
    }

    let jsFieldInfoFormat = new FieldInfoFormat(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsFieldInfoFormat);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFieldInfoFormat;

    return jsFieldInfoFormat;
}

export function buildDotNetFieldInfoFormat(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFieldInfoFormat: any = {
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
