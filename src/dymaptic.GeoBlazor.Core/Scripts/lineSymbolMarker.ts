// override generated code in this file
import LineSymbolMarker from '@arcgis/core/symbols/LineSymbolMarker';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';

export function buildJsLineSymbolMarker(dotNetObject: any, viewId: string | null): any {
    let jsLineSymbolMarker = new LineSymbolMarker();
    if (hasValue(dotNetObject.color)) {
        jsLineSymbolMarker.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.placement)) {
        jsLineSymbolMarker.placement = dotNetObject.placement;
    }
    if (hasValue(dotNetObject.style)) {
        jsLineSymbolMarker.style = dotNetObject.style;
    }

    let jsObjectRef = DotNet.createJSObjectReference(jsLineSymbolMarker);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLineSymbolMarker;

    return jsLineSymbolMarker;
}

export function buildDotNetLineSymbolMarker(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLineSymbolMarker: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetLineSymbolMarker.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.placement)) {
        dotNetLineSymbolMarker.placement = jsObject.placement;
    }
    if (hasValue(jsObject.style)) {
        dotNetLineSymbolMarker.style = jsObject.style;
    }
    if (hasValue(jsObject.type)) {
        dotNetLineSymbolMarker.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLineSymbolMarker.id = k;
                break;
            }
        }
    }

    return dotNetLineSymbolMarker;
}
