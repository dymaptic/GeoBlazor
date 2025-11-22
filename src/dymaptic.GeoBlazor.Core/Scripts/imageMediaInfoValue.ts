// override generated code in this file

import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';

export function buildJsImageMediaInfoValue(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.linkURL)) {
        properties.linkURL = dotNetObject.linkURL;
    }
    if (hasValue(dotNetObject.sourceURL)) {
        properties.sourceURL = dotNetObject.sourceURL;
    }

    let jsImageMediaInfoValue = new ImageMediaInfoValue(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsImageMediaInfoValue);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsImageMediaInfoValue;

    return jsImageMediaInfoValue;
}

export function buildDotNetImageMediaInfoValue(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetImageMediaInfoValue: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.linkURL)) {
        dotNetImageMediaInfoValue.linkURL = jsObject.linkURL;
    }
    if (hasValue(jsObject.sourceURL)) {
        dotNetImageMediaInfoValue.sourceURL = jsObject.sourceURL;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetImageMediaInfoValue.id = k;
                break;
            }
        }
    }

    return dotNetImageMediaInfoValue;
}
