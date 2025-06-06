// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetComboboxItem } from './comboboxItem';

export async function buildJsComboboxItemGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsComboboxItem: any = {};

    if (hasValue(dotNetObject.label)) {
        jsComboboxItem.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.value)) {
        jsComboboxItem.value = dotNetObject.value;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsComboboxItem);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsComboboxItem;
    
    return jsComboboxItem;
}


export async function buildDotNetComboboxItemGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetComboboxItem: any = {};
    
    if (hasValue(jsObject.label)) {
        dotNetComboboxItem.label = jsObject.label;
    }
    
    if (hasValue(jsObject.value)) {
        dotNetComboboxItem.value = jsObject.value;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetComboboxItem.id = geoBlazorId;
    }

    return dotNetComboboxItem;
}

