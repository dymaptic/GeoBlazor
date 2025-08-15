// override generated code in this file


import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from "./mapColor";

export function buildJsPictureMarkerSymbol(dotNetObject: any, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.angle)) {
        properties.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.height)) {
        properties.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.url)) {
        properties.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.width)) {
        properties.width = dotNetObject.width;
    }
    if (hasValue(dotNetObject.xoffset)) {
        properties.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        properties.yoffset = dotNetObject.yoffset;
    }

    let jsPictureMarkerSymbol = new PictureMarkerSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsPictureMarkerSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPictureMarkerSymbol;

    return jsPictureMarkerSymbol;
}

export function buildDotNetPictureMarkerSymbol(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPictureMarkerSymbol: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetPictureMarkerSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.angle)) {
        dotNetPictureMarkerSymbol.angle = jsObject.angle;
    }
    if (hasValue(jsObject.height)) {
        dotNetPictureMarkerSymbol.height = jsObject.height;
    }
    if (hasValue(jsObject.type)) {
        dotNetPictureMarkerSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.url)) {
        dotNetPictureMarkerSymbol.url = jsObject.url;
    }
    if (hasValue(jsObject.width)) {
        dotNetPictureMarkerSymbol.width = jsObject.width;
    }
    if (hasValue(jsObject.xoffset)) {
        dotNetPictureMarkerSymbol.xoffset = jsObject.xoffset;
    }
    if (hasValue(jsObject.yoffset)) {
        dotNetPictureMarkerSymbol.yoffset = jsObject.yoffset;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPictureMarkerSymbol.id = k;
                break;
            }
        }
    }

    return dotNetPictureMarkerSymbol;
}
