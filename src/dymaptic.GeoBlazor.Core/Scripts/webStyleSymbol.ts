// override generated code in this file
import WebStyleSymbol from '@arcgis/core/symbols/WebStyleSymbol';
import {
    arcGisObjectRefs,
    hasValue,
    jsObjectRefs, lookupGeoBlazorId,
    removeCircularReferences
} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from "./mapColor";
import {buildDotNetPortal, buildJsPortal} from "./portal";


export function buildJsWebStyleSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.portal)) {
        properties.portal = buildJsPortal(dotNetObject.portal, layerId, viewId) as any;
    } else if (hasValue(dotNetObject.portalUrl)) {
        // If portalUrl is provided, we create a portal object with that URL
        properties.portal = buildJsPortal({
            url: dotNetObject.portalUrl
        }, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.styleName)) {
        properties.styleName = dotNetObject.styleName;
    }
    if (hasValue(dotNetObject.styleUrl)) {
        properties.styleUrl = dotNetObject.styleUrl;
    }

    let jsWebStyleSymbol = new WebStyleSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsWebStyleSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWebStyleSymbol;

    return jsWebStyleSymbol;
}

export function buildDotNetWebStyleSymbol(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWebStyleSymbol: any = {};

    if (hasValue(jsObject.color)) {
        dotNetWebStyleSymbol.color = buildDotNetMapColor(jsObject.color);
    }

    if (hasValue(jsObject.portal)) {
        dotNetWebStyleSymbol.portal = buildDotNetPortal(jsObject.portal, viewId);
    }

    if (hasValue(jsObject.name)) {
        dotNetWebStyleSymbol.name = jsObject.name;
    }

    if (hasValue(jsObject.styleName)) {
        dotNetWebStyleSymbol.styleName = jsObject.styleName;
    }

    if (hasValue(jsObject.styleUrl)) {
        dotNetWebStyleSymbol.styleUrl = jsObject.styleUrl;
    }

    if (hasValue(jsObject.type)) {
        dotNetWebStyleSymbol.type = removeCircularReferences(jsObject.type);
    }

    let geoblazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoblazorId)) {
        dotNetWebStyleSymbol.id = geoblazorId;
    }

    return dotNetWebStyleSymbol;
}
