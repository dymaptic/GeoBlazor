// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetClassedSizeSliderViewModelBreaks } from './classedSizeSliderViewModelBreaks';

export async function buildJsClassedSizeSliderViewModelBreaksGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsClassedSizeSliderViewModelBreaks: any = {};

    if (hasValue(dotNetObject.max)) {
        jsClassedSizeSliderViewModelBreaks.max = dotNetObject.max;
    }
    if (hasValue(dotNetObject.min)) {
        jsClassedSizeSliderViewModelBreaks.min = dotNetObject.min;
    }
    if (hasValue(dotNetObject.size)) {
        jsClassedSizeSliderViewModelBreaks.size = dotNetObject.size;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsClassedSizeSliderViewModelBreaks);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsClassedSizeSliderViewModelBreaks;
    
    return jsClassedSizeSliderViewModelBreaks;
}


export async function buildDotNetClassedSizeSliderViewModelBreaksGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetClassedSizeSliderViewModelBreaks: any = {};
    
    if (hasValue(jsObject.max)) {
        dotNetClassedSizeSliderViewModelBreaks.max = jsObject.max;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetClassedSizeSliderViewModelBreaks.min = jsObject.min;
    }
    
    if (hasValue(jsObject.size)) {
        dotNetClassedSizeSliderViewModelBreaks.size = jsObject.size;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetClassedSizeSliderViewModelBreaks.id = geoBlazorId;
    }

    return dotNetClassedSizeSliderViewModelBreaks;
}

