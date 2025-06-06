// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetEditResultsObject } from './editResultsObject';

export async function buildJsEditResultsObjectGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsEditResultsObject: any = {};
    if (hasValue(dotNetObject.adds) && dotNetObject.adds.length > 0) {
        let { buildJsNamedObjectEditResults } = await import('./namedObjectEditResults');
        jsEditResultsObject.adds = await Promise.all(dotNetObject.adds.map(async i => await buildJsNamedObjectEditResults(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.deletes) && dotNetObject.deletes.length > 0) {
        let { buildJsNamedObjectEditResults } = await import('./namedObjectEditResults');
        jsEditResultsObject.deletes = await Promise.all(dotNetObject.deletes.map(async i => await buildJsNamedObjectEditResults(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.updates) && dotNetObject.updates.length > 0) {
        let { buildJsNamedObjectEditResults } = await import('./namedObjectEditResults');
        jsEditResultsObject.updates = await Promise.all(dotNetObject.updates.map(async i => await buildJsNamedObjectEditResults(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.typeName)) {
        jsEditResultsObject.typeName = dotNetObject.typeName;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsEditResultsObject);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsEditResultsObject;
    
    return jsEditResultsObject;
}


export async function buildDotNetEditResultsObjectGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetEditResultsObject: any = {};
    
    if (hasValue(jsObject.adds)) {
        let { buildDotNetNamedObjectEditResults } = await import('./namedObjectEditResults');
        dotNetEditResultsObject.adds = await Promise.all(jsObject.adds.map(async i => await buildDotNetNamedObjectEditResults(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.deletes)) {
        let { buildDotNetNamedObjectEditResults } = await import('./namedObjectEditResults');
        dotNetEditResultsObject.deletes = await Promise.all(jsObject.deletes.map(async i => await buildDotNetNamedObjectEditResults(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.updates)) {
        let { buildDotNetNamedObjectEditResults } = await import('./namedObjectEditResults');
        dotNetEditResultsObject.updates = await Promise.all(jsObject.updates.map(async i => await buildDotNetNamedObjectEditResults(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.typeName)) {
        dotNetEditResultsObject.typeName = jsObject.typeName;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetEditResultsObject.id = geoBlazorId;
    }

    return dotNetEditResultsObject;
}

