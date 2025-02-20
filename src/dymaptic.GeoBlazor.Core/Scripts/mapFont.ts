// override generated code in this file


import Font from "@arcgis/core/symbols/Font";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsMapFont(dotNetObject: any): any {
    let jsFont = new Font();

    if (hasValue(dotNetObject.decoration)) {
        jsFont.decoration = dotNetObject.decoration;
    }
    if (hasValue(dotNetObject.family)) {
        jsFont.family = dotNetObject.family;
    }
    if (hasValue(dotNetObject.size)) {
        jsFont.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.style)) {
        jsFont.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.weight)) {
        jsFont.weight = dotNetObject.weight;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(mapFontWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFont;

    let dnInstantiatedObject = buildDotNetMapFont(jsFont);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MapFont', e);
    }

    return jsFont;
}

export function buildDotNetMapFont(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapFont: any = {
        // @ts-ignore
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
