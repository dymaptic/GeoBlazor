// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import OpacityStop from '@arcgis/core/renderers/visualVariables/support/OpacityStop';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetOpacityStop } from './opacityStop';

export async function buildJsOpacityStopGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.opacity)) {
        properties.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.value)) {
        properties.value = dotNetObject.value;
    }
    let jsOpacityStop = new OpacityStop(properties);
    
    jsObjectRefs[dotNetObject.id] = jsOpacityStop;
    arcGisObjectRefs[dotNetObject.id] = jsOpacityStop;
    
    return jsOpacityStop;
}


export async function buildDotNetOpacityStopGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetOpacityStop: any = {};
    
    if (hasValue(jsObject.label)) {
        dotNetOpacityStop.label = jsObject.label;
    }
    
    if (hasValue(jsObject.opacity)) {
        dotNetOpacityStop.opacity = jsObject.opacity;
    }
    
    if (hasValue(jsObject.value)) {
        dotNetOpacityStop.value = jsObject.value;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetOpacityStop.id = geoBlazorId;
    }

    return dotNetOpacityStop;
}

