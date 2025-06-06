// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetDirectionsViewModelTimeAttribute } from './directionsViewModelTimeAttribute';

export async function buildJsDirectionsViewModelTimeAttributeGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsDirectionsViewModelTimeAttribute: any = {};

    if (hasValue(dotNetObject.name)) {
        jsDirectionsViewModelTimeAttribute.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.units)) {
        jsDirectionsViewModelTimeAttribute.units = dotNetObject.units;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsDirectionsViewModelTimeAttribute);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsDirectionsViewModelTimeAttribute;
    
    return jsDirectionsViewModelTimeAttribute;
}


export async function buildDotNetDirectionsViewModelTimeAttributeGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetDirectionsViewModelTimeAttribute: any = {};
    
    if (hasValue(jsObject.name)) {
        dotNetDirectionsViewModelTimeAttribute.name = jsObject.name;
    }
    
    if (hasValue(jsObject.units)) {
        dotNetDirectionsViewModelTimeAttribute.units = jsObject.units;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetDirectionsViewModelTimeAttribute.id = geoBlazorId;
    }

    return dotNetDirectionsViewModelTimeAttribute;
}

