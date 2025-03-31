// override generated code in this file


import Font from "@arcgis/core/symbols/Font";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsMapFont(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.decoration)) {
        properties.decoration = dotNetObject.decoration;
    }
    if (hasValue(dotNetObject.family)) {
        properties.family = dotNetObject.family;
    }
    if (hasValue(dotNetObject.size)) {
        properties.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.style)) {
        properties.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.weight)) {
        properties.weight = dotNetObject.weight;
    }

    let jsFont = new Font(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsFont);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFont;

    return jsFont;
}

export function buildDotNetMapFont(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapFont: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.decoration)) {
        dotNetMapFont.decoration = jsObject.decoration;
    }
    if (hasValue(jsObject.family)) {
        dotNetMapFont.family = jsObject.family;
    }
    if (hasValue(jsObject.size)) {
        dotNetMapFont.size = jsObject.size;
    }
    if (hasValue(jsObject.style)) {
        dotNetMapFont.style = jsObject.style;
    }
    if (hasValue(jsObject.weight)) {
        dotNetMapFont.weight = jsObject.weight;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMapFont.id = k;
                break;
            }
        }
    }

    return dotNetMapFont;
}
