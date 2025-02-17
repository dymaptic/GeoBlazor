// override generated code in this file
import SimpleMarkerSymbol from '@arcgis/core/symbols/SimpleMarkerSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor } from './mapColor';


export function buildJsSimpleMarkerSymbol(dotNetObject: any): any {
    let jsSimpleMarkerSymbol = new SimpleMarkerSymbol();
    if (hasValue(dotNetObject.color)) {
        jsSimpleMarkerSymbol.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.angle)) {
        jsSimpleMarkerSymbol.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.outline)) {
        jsSimpleMarkerSymbol.outline = dotNetObject.outline;
    }
    if (hasValue(dotNetObject.path)) {
        jsSimpleMarkerSymbol.path = dotNetObject.path;
    }
    if (hasValue(dotNetObject.size)) {
        jsSimpleMarkerSymbol.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.style)) {
        jsSimpleMarkerSymbol.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.xoffset)) {
        jsSimpleMarkerSymbol.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        jsSimpleMarkerSymbol.yoffset = dotNetObject.yoffset;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(simpleMarkerSymbolWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleMarkerSymbol;

    let dnInstantiatedObject = buildDotNetSimpleMarkerSymbol(jsSimpleMarkerSymbol);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SimpleMarkerSymbol', e);
    }

    return jsSimpleMarkerSymbol;
}

export function buildDotNetSimpleMarkerSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSimpleMarkerSymbol: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetSimpleMarkerSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.angle)) {
        dotNetSimpleMarkerSymbol.angle = jsObject.angle;
    }
    if (hasValue(jsObject.outline)) {
        dotNetSimpleMarkerSymbol.outline = jsObject.outline;
    }
    if (hasValue(jsObject.path)) {
        dotNetSimpleMarkerSymbol.path = jsObject.path;
    }
    if (hasValue(jsObject.size)) {
        dotNetSimpleMarkerSymbol.size = jsObject.size;
    }
    if (hasValue(jsObject.style)) {
        dotNetSimpleMarkerSymbol.style = jsObject.style;
    }
    if (hasValue(jsObject.type)) {
        dotNetSimpleMarkerSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.xoffset)) {
        dotNetSimpleMarkerSymbol.xoffset = jsObject.xoffset;
    }
    if (hasValue(jsObject.yoffset)) {
        dotNetSimpleMarkerSymbol.yoffset = jsObject.yoffset;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSimpleMarkerSymbol.id = k;
                break;
            }
        }
    }

    return dotNetSimpleMarkerSymbol;
}
