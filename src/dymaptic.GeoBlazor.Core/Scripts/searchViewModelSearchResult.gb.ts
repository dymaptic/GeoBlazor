// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetSearchViewModelSearchResult } from './searchViewModelSearchResult';

export async function buildJsSearchViewModelSearchResultGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSearchViewModelSearchResult: any = {};
    if (hasValue(dotNetObject.extent)) {
        let { buildJsExtent } = await import('./extent');
        jsSearchViewModelSearchResult.extent = buildJsExtent(dotNetObject.extent) as any;
    }
    if (hasValue(dotNetObject.feature)) {
        let { buildJsGraphic } = await import('./graphic');
        jsSearchViewModelSearchResult.feature = buildJsGraphic(dotNetObject.feature) as any;
    }

    if (hasValue(dotNetObject.name)) {
        jsSearchViewModelSearchResult.name = dotNetObject.name;
    }
    
    jsObjectRefs[dotNetObject.id] = jsSearchViewModelSearchResult;
    arcGisObjectRefs[dotNetObject.id] = jsSearchViewModelSearchResult;
    
    return jsSearchViewModelSearchResult;
}


export async function buildDotNetSearchViewModelSearchResultGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSearchViewModelSearchResult: any = {};
    
    if (hasValue(jsObject.extent)) {
        let { buildDotNetExtent } = await import('./extent');
        dotNetSearchViewModelSearchResult.extent = buildDotNetExtent(jsObject.extent);
    }
    
    if (hasValue(jsObject.feature)) {
        let { buildDotNetGraphic } = await import('./graphic');
        dotNetSearchViewModelSearchResult.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
    }
    
    if (hasValue(jsObject.name)) {
        dotNetSearchViewModelSearchResult.name = jsObject.name;
    }
    

    return dotNetSearchViewModelSearchResult;
}

