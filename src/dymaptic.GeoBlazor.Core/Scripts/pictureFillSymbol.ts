// override generated code in this file

import PictureFillSymbol from '@arcgis/core/symbols/PictureFillSymbol';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';


export function buildJsPictureFillSymbol(dotNetObject: any): any {
    let jsPictureFillSymbol = new PictureFillSymbol();
    if (hasValue(dotNetObject.color)) {
        jsPictureFillSymbol.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.height)) {
        jsPictureFillSymbol.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.outline)) {
        jsPictureFillSymbol.outline = dotNetObject.outline;
    }
    if (hasValue(dotNetObject.url)) {
        jsPictureFillSymbol.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.width)) {
        jsPictureFillSymbol.width = dotNetObject.width;
    }
    if (hasValue(dotNetObject.xoffset)) {
        jsPictureFillSymbol.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.xscale)) {
        jsPictureFillSymbol.xscale = dotNetObject.xscale;
    }
    if (hasValue(dotNetObject.yoffset)) {
        jsPictureFillSymbol.yoffset = dotNetObject.yoffset;
    }
    if (hasValue(dotNetObject.yscale)) {
        jsPictureFillSymbol.yscale = dotNetObject.yscale;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(pictureFillSymbolWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPictureFillSymbol;

    let dnInstantiatedObject = buildDotNetPictureFillSymbol(jsPictureFillSymbol);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PictureFillSymbol', e);
    }

    return jsPictureFillSymbol;
}

export function buildDotNetPictureFillSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPictureFillSymbol: any = {
        // @ts-ignore
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
