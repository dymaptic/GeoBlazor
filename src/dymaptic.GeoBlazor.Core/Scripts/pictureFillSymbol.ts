// override generated code in this file

import PictureFillSymbol from '@arcgis/core/symbols/PictureFillSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';


export function buildJsPictureFillSymbol(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.height)) {
        properties.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.outline)) {
        properties.outline = dotNetObject.outline;
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
    if (hasValue(dotNetObject.xscale)) {
        properties.xscale = dotNetObject.xscale;
    }
    if (hasValue(dotNetObject.yoffset)) {
        properties.yoffset = dotNetObject.yoffset;
    }
    if (hasValue(dotNetObject.yscale)) {
        properties.yscale = dotNetObject.yscale;
    }

    let jsPictureFillSymbol = new PictureFillSymbol(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsPictureFillSymbol);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPictureFillSymbol;

    return jsPictureFillSymbol;
}

export function buildDotNetPictureFillSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPictureFillSymbol: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetPictureFillSymbol.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.height)) {
        dotNetPictureFillSymbol.height = jsObject.height;
    }
    if (hasValue(jsObject.outline)) {
        dotNetPictureFillSymbol.outline = jsObject.outline;
    }
    if (hasValue(jsObject.type)) {
        dotNetPictureFillSymbol.type = jsObject.type;
    }
    if (hasValue(jsObject.url)) {
        dotNetPictureFillSymbol.url = jsObject.url;
    }
    if (hasValue(jsObject.width)) {
        dotNetPictureFillSymbol.width = jsObject.width;
    }
    if (hasValue(jsObject.xoffset)) {
        dotNetPictureFillSymbol.xoffset = jsObject.xoffset;
    }
    if (hasValue(jsObject.xscale)) {
        dotNetPictureFillSymbol.xscale = jsObject.xscale;
    }
    if (hasValue(jsObject.yoffset)) {
        dotNetPictureFillSymbol.yoffset = jsObject.yoffset;
    }
    if (hasValue(jsObject.yscale)) {
        dotNetPictureFillSymbol.yscale = jsObject.yscale;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPictureFillSymbol.id = k;
                break;
            }
        }
    }

    return dotNetPictureFillSymbol;
}
