// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetJoinTableDataSource } from './joinTableDataSource';

export async function buildJsJoinTableDataSourceGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsJoinTableDataSource: any = {};
    if (hasValue(dotNetObject.leftTableSource)) {
        let { buildJsDynamicLayer } = await import('./dynamicLayer');
        jsJoinTableDataSource.leftTableSource = await buildJsDynamicLayer(dotNetObject.leftTableSource, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.rightTableSource)) {
        let { buildJsDynamicLayer } = await import('./dynamicLayer');
        jsJoinTableDataSource.rightTableSource = await buildJsDynamicLayer(dotNetObject.rightTableSource, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.joinType)) {
        jsJoinTableDataSource.joinType = dotNetObject.joinType;
    }
    if (hasValue(dotNetObject.leftTableKey)) {
        jsJoinTableDataSource.leftTableKey = dotNetObject.leftTableKey;
    }
    if (hasValue(dotNetObject.rightTableKey)) {
        jsJoinTableDataSource.rightTableKey = dotNetObject.rightTableKey;
    }
    
    jsObjectRefs[dotNetObject.id] = jsJoinTableDataSource;
    arcGisObjectRefs[dotNetObject.id] = jsJoinTableDataSource;
    
    return jsJoinTableDataSource;
}


export async function buildDotNetJoinTableDataSourceGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetJoinTableDataSource: any = {};
    
    if (hasValue(jsObject.leftTableSource)) {
        let { buildDotNetDynamicLayer } = await import('./dynamicLayer');
        dotNetJoinTableDataSource.leftTableSource = await buildDotNetDynamicLayer(jsObject.leftTableSource);
    }
    
    if (hasValue(jsObject.rightTableSource)) {
        let { buildDotNetDynamicLayer } = await import('./dynamicLayer');
        dotNetJoinTableDataSource.rightTableSource = await buildDotNetDynamicLayer(jsObject.rightTableSource);
    }
    
    if (hasValue(jsObject.joinType)) {
        dotNetJoinTableDataSource.joinType = removeCircularReferences(jsObject.joinType);
    }
    
    if (hasValue(jsObject.leftTableKey)) {
        dotNetJoinTableDataSource.leftTableKey = jsObject.leftTableKey;
    }
    
    if (hasValue(jsObject.rightTableKey)) {
        dotNetJoinTableDataSource.rightTableKey = jsObject.rightTableKey;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetJoinTableDataSource.type = jsObject.type;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetJoinTableDataSource.id = geoBlazorId;
    }

    return dotNetJoinTableDataSource;
}

