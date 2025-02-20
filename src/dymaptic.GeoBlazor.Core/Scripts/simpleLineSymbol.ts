// override generated code in this file
import SimpleLineSymbol from '@arcgis/core/symbols/SimpleLineSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetLineSymbolMarker, buildJsLineSymbolMarker} from "./lineSymbolMarker";

export function buildJsSimpleLineSymbol(dotNetObject: any): any {
    let jsSimpleLineSymbol = new SimpleLineSymbol();
    if (hasValue(dotNetObject.color)) {
        jsSimpleLineSymbol.color = buildJsMapColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.marker)) {
        jsSimpleLineSymbol.marker = buildJsLineSymbolMarker(dotNetObject.marker) as any;
    }

    if (hasValue(dotNetObject.cap)) {
        jsSimpleLineSymbol.cap = dotNetObject.cap;
    }
    if (hasValue(dotNetObject.join)) {
        jsSimpleLineSymbol.join = dotNetObject.join;
    }
    if (hasValue(dotNetObject.miterLimit)) {
        jsSimpleLineSymbol.miterLimit = dotNetObject.miterLimit;
    }
    if (hasValue(dotNetObject.style)) {
        jsSimpleLineSymbol.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.width)) {
        jsSimpleLineSymbol.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(simpleLineSymbolWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleLineSymbol;

    let dnInstantiatedObject = buildDotNetSimpleLineSymbol(jsSimpleLineSymbol);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SimpleLineSymbol', e);
    }

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
        // @ts-ignore
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
