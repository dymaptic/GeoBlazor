// override generated code in this file
import SimpleFillSymbol from '@arcgis/core/symbols/SimpleFillSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor } from './mapColor';
export function buildJsSimpleFillSymbol(dotNetObject: any): any {
    let jsSimpleFillSymbol = new SimpleFillSymbol();
    if (hasValue(dotNetObject.color)) {
        jsSimpleFillSymbol.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.outline)) {
        jsSimpleFillSymbol.outline = dotNetObject.outline;
    }
    if (hasValue(dotNetObject.style)) {
        jsSimpleFillSymbol.style = dotNetObject.style;
    }
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(simpleFillSymbolWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleFillSymbol;

    let dnInstantiatedObject = buildDotNetSimpleFillSymbol(jsSimpleFillSymbol);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SimpleFillSymbol', e);
    }

    return jsSimpleFillSymbol;
}
export function buildDotNetSimpleFillSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSimpleFillSymbol: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetSimpleFillSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.outline)) {
        dotNetSimpleFillSymbol.outline = jsObject.outline;
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
