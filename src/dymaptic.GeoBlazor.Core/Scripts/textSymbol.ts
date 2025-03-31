// override generated code in this file
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from "./mapColor";
import {buildDotNetMapFont, buildJsMapFont} from "./mapFont";

export function buildJsTextSymbol(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.backgroundColor)) {
        properties.backgroundColor = buildJsMapColor(dotNetObject.backgroundColor) as any;
    }
    if (hasValue(dotNetObject.borderLineColor)) {
        properties.borderLineColor = buildJsMapColor(dotNetObject.borderLineColor) as any;
    }
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.font)) {
        properties.font = buildJsMapFont(dotNetObject.font) as any;
    }
    if (hasValue(dotNetObject.haloColor)) {
        properties.haloColor = buildJsMapColor(dotNetObject.haloColor) as any;
    }

    if (hasValue(dotNetObject.angle)) {
        properties.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.borderLineSize)) {
        properties.borderLineSize = dotNetObject.borderLineSize;
    }
    if (hasValue(dotNetObject.haloSize)) {
        properties.haloSize = dotNetObject.haloSize;
    }
    if (hasValue(dotNetObject.horizontalAlignment)) {
        properties.horizontalAlignment = dotNetObject.horizontalAlignment;
    }
    if (hasValue(dotNetObject.kerning)) {
        properties.kerning = dotNetObject.kerning;
    }
    if (hasValue(dotNetObject.lineHeight)) {
        properties.lineHeight = dotNetObject.lineHeight;
    }
    if (hasValue(dotNetObject.lineWidth)) {
        properties.lineWidth = dotNetObject.lineWidth;
    }
    if (hasValue(dotNetObject.rotated)) {
        properties.rotated = dotNetObject.rotated;
    }
    if (hasValue(dotNetObject.text)) {
        properties.text = dotNetObject.text;
    }
    if (hasValue(dotNetObject.verticalAlignment)) {
        properties.verticalAlignment = dotNetObject.verticalAlignment;
    }
    if (hasValue(dotNetObject.xoffset)) {
        properties.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        properties.yoffset = dotNetObject.yoffset;
    }

    let jsTextSymbol = new TextSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsTextSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsTextSymbol;

    return jsTextSymbol;
}

export function buildDotNetTextSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTextSymbol: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.backgroundColor)) {
        dotNetTextSymbol.backgroundColor = buildDotNetMapColor(jsObject.backgroundColor);
    }
    if (hasValue(jsObject.borderLineColor)) {
        dotNetTextSymbol.borderLineColor = buildDotNetMapColor(jsObject.borderLineColor);
    }
    if (hasValue(jsObject.color)) {
        dotNetTextSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.font)) {
        dotNetTextSymbol.font = buildDotNetMapFont(jsObject.font);
    }
    if (hasValue(jsObject.haloColor)) {
        dotNetTextSymbol.haloColor = buildDotNetMapColor(jsObject.haloColor);
    }
    if (hasValue(jsObject.angle)) {
        dotNetTextSymbol.angle = jsObject.angle;
    }
    if (hasValue(jsObject.borderLineSize)) {
        dotNetTextSymbol.borderLineSize = jsObject.borderLineSize;
    }
    if (hasValue(jsObject.haloSize)) {
        dotNetTextSymbol.haloSize = jsObject.haloSize;
    }
    if (hasValue(jsObject.horizontalAlignment)) {
        dotNetTextSymbol.horizontalAlignment = jsObject.horizontalAlignment;
    }
    if (hasValue(jsObject.kerning)) {
        dotNetTextSymbol.kerning = jsObject.kerning;
    }
    if (hasValue(jsObject.lineHeight)) {
        dotNetTextSymbol.lineHeight = jsObject.lineHeight;
    }
    if (hasValue(jsObject.lineWidth)) {
        dotNetTextSymbol.lineWidth = jsObject.lineWidth;
    }
    if (hasValue(jsObject.rotated)) {
        dotNetTextSymbol.rotated = jsObject.rotated;
    }
    if (hasValue(jsObject.text)) {
        dotNetTextSymbol.text = jsObject.text;
    }
    if (hasValue(jsObject.type)) {
        dotNetTextSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.verticalAlignment)) {
        dotNetTextSymbol.verticalAlignment = jsObject.verticalAlignment;
    }
    if (hasValue(jsObject.xoffset)) {
        dotNetTextSymbol.xoffset = jsObject.xoffset;
    }
    if (hasValue(jsObject.yoffset)) {
        dotNetTextSymbol.yoffset = jsObject.yoffset;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTextSymbol.id = k;
                break;
            }
        }
    }

    return dotNetTextSymbol;
}
