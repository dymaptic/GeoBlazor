// override generated code in this file
import SimpleMarkerSymbol from '@arcgis/core/symbols/SimpleMarkerSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs, lookupGeoBlazorId} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetSimpleLineSymbol, buildJsOutline} from "./simpleLineSymbol";


export function buildJsSimpleMarkerSymbol(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.angle)) {
        properties.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.outline)) {
        properties.outline = buildJsOutline(dotNetObject.outline);
    }
    if (hasValue(dotNetObject.path)) {
        properties.path = dotNetObject.path;
    }
    if (hasValue(dotNetObject.size)) {
        properties.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.style)) {
        properties.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.xoffset)) {
        properties.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        properties.yoffset = dotNetObject.yoffset;
    }

    let jsSimpleMarkerSymbol = new SimpleMarkerSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsSimpleMarkerSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleMarkerSymbol;

    return jsSimpleMarkerSymbol;
}

export function buildDotNetSimpleMarkerSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSimpleMarkerSymbol: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetSimpleMarkerSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.angle)) {
        dotNetSimpleMarkerSymbol.angle = jsObject.angle;
    }
    if (hasValue(jsObject.outline)) {
        dotNetSimpleMarkerSymbol.outline = buildDotNetSimpleLineSymbol(jsObject.outline);
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

    let geoblazorId = lookupGeoBlazorId(jsObject);
    
    if (hasValue(geoblazorId)) {
        dotNetSimpleMarkerSymbol.id = geoblazorId;
    }

    return dotNetSimpleMarkerSymbol;
}
