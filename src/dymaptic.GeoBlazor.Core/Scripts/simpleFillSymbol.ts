// override generated code in this file
import SimpleFillSymbol from '@arcgis/core/symbols/SimpleFillSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetSimpleLineSymbol, buildJsOutline} from "./simpleLineSymbol";

export function buildJsSimpleFillSymbol(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.outline)) {
        properties.outline = buildJsOutline(dotNetObject.outline);
    }
    if (hasValue(dotNetObject.style)) {
        properties.style = dotNetObject.style;
    }

    let jsSimpleFillSymbol = new SimpleFillSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsSimpleFillSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleFillSymbol;

    return jsSimpleFillSymbol;
}

export function buildDotNetSimpleFillSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSimpleFillSymbol: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetSimpleFillSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.outline)) {
        dotNetSimpleFillSymbol.outline = buildDotNetSimpleLineSymbol(jsObject.outline);
    }
    if (hasValue(jsObject.style)) {
        dotNetSimpleFillSymbol.style = jsObject.style;
    }
    if (hasValue(jsObject.type)) {
        dotNetSimpleFillSymbol.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSimpleFillSymbol.id = k;
                break;
            }
        }
    }

    return dotNetSimpleFillSymbol;
}
