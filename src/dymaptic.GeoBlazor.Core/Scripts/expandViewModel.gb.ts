// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import ExpandViewModel from '@arcgis/core/widgets/Expand/ExpandViewModel';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetExpandViewModel } from './expandViewModel';

export async function buildJsExpandViewModelGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(viewId)) {
        properties.view = arcGisObjectRefs[viewId!];
    }

    if (hasValue(dotNetObject.autoCollapse)) {
        properties.autoCollapse = dotNetObject.autoCollapse;
    }
    if (hasValue(dotNetObject.expanded)) {
        properties.expanded = dotNetObject.expanded;
    }
    if (hasValue(dotNetObject.group)) {
        properties.group = dotNetObject.group;
    }
    let jsExpandViewModel = new ExpandViewModel(properties);
    
    jsObjectRefs[dotNetObject.id] = jsExpandViewModel;
    arcGisObjectRefs[dotNetObject.id] = jsExpandViewModel;
    
    return jsExpandViewModel;
}


export async function buildDotNetExpandViewModelGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetExpandViewModel: any = {};
    
    if (hasValue(jsObject.autoCollapse)) {
        dotNetExpandViewModel.autoCollapse = jsObject.autoCollapse;
    }
    
    if (hasValue(jsObject.expanded)) {
        dotNetExpandViewModel.expanded = jsObject.expanded;
    }
    
    if (hasValue(jsObject.group)) {
        dotNetExpandViewModel.group = jsObject.group;
    }
    
    if (hasValue(jsObject.state)) {
        dotNetExpandViewModel.state = removeCircularReferences(jsObject.state);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetExpandViewModel.id = geoBlazorId;
    }

    return dotNetExpandViewModel;
}

