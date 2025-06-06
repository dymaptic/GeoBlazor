// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import BuildingFilter from '@arcgis/core/layers/support/BuildingFilter';
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetBuildingFilter } from './buildingFilter';

export async function buildJsBuildingFilterGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.filterBlocks) && dotNetObject.filterBlocks.length > 0) {
        let { buildJsBuildingFilterBlock } = await import('./buildingFilterBlock');
        properties.filterBlocks = await Promise.all(dotNetObject.filterBlocks.map(async i => await buildJsBuildingFilterBlock(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.description)) {
        properties.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    let jsBuildingFilter = new BuildingFilter(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsBuildingFilter);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBuildingFilter;
    
    return jsBuildingFilter;
}


export async function buildDotNetBuildingFilterGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBuildingFilter: any = {};
    
    if (hasValue(jsObject.filterBlocks)) {
        let { buildDotNetBuildingFilterBlock } = await import('./buildingFilterBlock');
        dotNetBuildingFilter.filterBlocks = await Promise.all(jsObject.filterBlocks.map(async i => await buildDotNetBuildingFilterBlock(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.id)) {
        dotNetBuildingFilter.buildingFilterId = jsObject.id;
    }
    
    if (hasValue(jsObject.description)) {
        dotNetBuildingFilter.description = jsObject.description;
    }
    
    if (hasValue(jsObject.name)) {
        dotNetBuildingFilter.name = jsObject.name;
    }
    

    return dotNetBuildingFilter;
}

