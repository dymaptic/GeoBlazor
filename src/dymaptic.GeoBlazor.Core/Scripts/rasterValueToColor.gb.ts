// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetRasterValueToColor } from './rasterValueToColor';

export async function buildJsRasterValueToColorGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsRasterValueToColor: any = {};

    if (hasValue(dotNetObject.color) && dotNetObject.color.length > 0) {
        jsRasterValueToColor.color = dotNetObject.color;
    }
    if (hasValue(dotNetObject.outputPixelType)) {
        jsRasterValueToColor.outputPixelType = dotNetObject.outputPixelType;
    }
    if (hasValue(dotNetObject.raster)) {
        jsRasterValueToColor.raster = dotNetObject.raster;
    }
    if (hasValue(dotNetObject.value)) {
        jsRasterValueToColor.value = dotNetObject.value;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsRasterValueToColor);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRasterValueToColor;
    
    return jsRasterValueToColor;
}


export async function buildDotNetRasterValueToColorGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRasterValueToColor: any = {};
    
    if (hasValue(jsObject.color)) {
        dotNetRasterValueToColor.color = jsObject.color;
    }
    
    if (hasValue(jsObject.outputPixelType)) {
        dotNetRasterValueToColor.outputPixelType = removeCircularReferences(jsObject.outputPixelType);
    }
    
    if (hasValue(jsObject.raster)) {
        dotNetRasterValueToColor.raster = removeCircularReferences(jsObject.raster);
    }
    
    if (hasValue(jsObject.value)) {
        dotNetRasterValueToColor.value = jsObject.value;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetRasterValueToColor.id = geoBlazorId;
    }

    return dotNetRasterValueToColor;
}

