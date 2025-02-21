// override generated code in this file
import SimpleLineSymbol from '@arcgis/core/symbols/SimpleLineSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetLineSymbolMarker, buildJsLineSymbolMarker} from "./lineSymbolMarker";

export function buildJsSimpleLineSymbol(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.marker)) {
        properties.marker = buildJsLineSymbolMarker(dotNetObject.marker) as any;
    }

    if (hasValue(dotNetObject.cap)) {
        properties.cap = dotNetObject.cap;
    }
    if (hasValue(dotNetObject.join)) {
        properties.join = dotNetObject.join;
    }
    if (hasValue(dotNetObject.miterLimit)) {
        properties.miterLimit = dotNetObject.miterLimit;
    }
    if (hasValue(dotNetObject.style)) {
        properties.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.width)) {
        properties.width = dotNetObject.width;
    }

    let jsSimpleLineSymbol = new SimpleLineSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsSimpleLineSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleLineSymbol;

    return jsSimpleLineSymbol;
}

export function buildJsOutline(dotNetObject: any): any {
    return buildJsSimpleLineSymbol(dotNetObject);
}

export function buildDotNetSimpleLineSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSimpleLineSymbol: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetSimpleLineSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.marker)) {
        dotNetSimpleLineSymbol.marker = buildDotNetLineSymbolMarker(jsObject.marker);
    }
    if (hasValue(jsObject.cap)) {
        dotNetSimpleLineSymbol.cap = jsObject.cap;
    }
    if (hasValue(jsObject.join)) {
        dotNetSimpleLineSymbol.join = jsObject.join;
    }
    if (hasValue(jsObject.miterLimit)) {
        dotNetSimpleLineSymbol.miterLimit = jsObject.miterLimit;
    }
    if (hasValue(jsObject.style)) {
        dotNetSimpleLineSymbol.style = jsObject.style;
    }
    if (hasValue(jsObject.type)) {
        dotNetSimpleLineSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.width)) {
        dotNetSimpleLineSymbol.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSimpleLineSymbol.id = k;
                break;
            }
        }
    }

    return dotNetSimpleLineSymbol;
}
