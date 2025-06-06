// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetBuildingExplorerVisibleElements } from './buildingExplorerVisibleElements';

export async function buildJsBuildingExplorerVisibleElementsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsBuildingExplorerVisibleElements: any = {};

    if (hasValue(dotNetObject.disciplines)) {
        jsBuildingExplorerVisibleElements.disciplines = dotNetObject.disciplines;
    }
    if (hasValue(dotNetObject.levels)) {
        jsBuildingExplorerVisibleElements.levels = dotNetObject.levels;
    }
    if (hasValue(dotNetObject.phases)) {
        jsBuildingExplorerVisibleElements.phases = dotNetObject.phases;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsBuildingExplorerVisibleElements);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBuildingExplorerVisibleElements;
    
    return jsBuildingExplorerVisibleElements;
}


export async function buildDotNetBuildingExplorerVisibleElementsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBuildingExplorerVisibleElements: any = {};
    
    if (hasValue(jsObject.disciplines)) {
        dotNetBuildingExplorerVisibleElements.disciplines = jsObject.disciplines;
    }
    
    if (hasValue(jsObject.levels)) {
        dotNetBuildingExplorerVisibleElements.levels = jsObject.levels;
    }
    
    if (hasValue(jsObject.phases)) {
        dotNetBuildingExplorerVisibleElements.phases = jsObject.phases;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBuildingExplorerVisibleElements.id = geoBlazorId;
    }

    return dotNetBuildingExplorerVisibleElements;
}

