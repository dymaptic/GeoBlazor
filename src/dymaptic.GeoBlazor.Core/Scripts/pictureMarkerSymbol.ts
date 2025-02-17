// override generated code in this file


import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor } from "./mapColor";

export function buildJsPictureMarkerSymbol(dotNetObject: any): any {
    let jsPictureMarkerSymbol = new PictureMarkerSymbol();
    if (hasValue(dotNetObject.color)) {
        jsPictureMarkerSymbol.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.angle)) {
        jsPictureMarkerSymbol.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.height)) {
        jsPictureMarkerSymbol.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.url)) {
        jsPictureMarkerSymbol.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.width)) {
        jsPictureMarkerSymbol.width = dotNetObject.width;
    }
    if (hasValue(dotNetObject.xoffset)) {
        jsPictureMarkerSymbol.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        jsPictureMarkerSymbol.yoffset = dotNetObject.yoffset;
    }
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(pictureMarkerSymbolWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPictureMarkerSymbol;

    let dnInstantiatedObject = buildDotNetPictureMarkerSymbol(jsPictureMarkerSymbol);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PictureMarkerSymbol', e);
    }

    return jsPictureMarkerSymbol;
}     

export function buildDotNetPictureMarkerSymbol(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPictureMarkerSymbol: any = {
        // @ts-ignore
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
