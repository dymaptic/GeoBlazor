import {hasValue} from "./arcGisJsInterop";

export async function buildJsDynamicDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    switch (dotNetObject.type) {
        case 'join-table':
            let {buildJsJoinTableDataSource} = await import('./joinTableDataSource');
            return await buildJsJoinTableDataSource(dotNetObject, layerId, viewId);
        case 'query-table':
            let {buildJsQueryTableDataSource} = await import('./queryTableDataSource');
            return await buildJsQueryTableDataSource(dotNetObject, layerId, viewId);
        case 'raster':
            let {buildJsRasterDataSource} = await import('./rasterDataSource');
            return await buildJsRasterDataSource(dotNetObject, layerId, viewId);
        case 'table':
            let {buildJsTableDataSource} = await import('./tableDataSource');
            return await buildJsTableDataSource(dotNetObject, layerId, viewId);
        default:
            return null;
    }
}
export async function buildDotNetDynamicDataSource(jsObject: any): Promise<any> {
    let { buildDotNetDynamicDataSourceGenerated } = await import('./dynamicDataSource.gb');
    return await buildDotNetDynamicDataSourceGenerated(jsObject);
}
