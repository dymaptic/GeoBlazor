import {hasValue} from "./arcGisJsInterop";

export async function buildJsDynamicDataSource(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    switch (dotNetObject.type) {
        case 'join-table':
            let {buildJsJoinTableDataSource} = await import('./joinTableDataSource');
            return await buildJsJoinTableDataSource(dotNetObject);
        case 'query-table':
            let {buildJsQueryTableDataSource} = await import('./queryTableDataSource');
            return await buildJsQueryTableDataSource(dotNetObject);
        case 'raster':
            let {buildJsRasterDataSource} = await import('./rasterDataSource');
            return await buildJsRasterDataSource(dotNetObject);
        case 'table':
            let {buildJsTableDataSource} = await import('./tableDataSource');
            return await buildJsTableDataSource(dotNetObject);
        default:
            return null;
    }
}
export async function buildDotNetDynamicDataSource(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    switch (jsObject.type) {
        case 'join-table':
            let {buildDotNetJoinTableDataSource} = await import('./joinTableDataSource');
            return await buildDotNetJoinTableDataSource(jsObject, viewId);
        case 'query-table':
            let {buildDotNetQueryTableDataSource} = await import('./queryTableDataSource');
            return await buildDotNetQueryTableDataSource(jsObject, viewId);
        case 'raster':
            let {buildDotNetRasterDataSource} = await import('./rasterDataSource');
            return await buildDotNetRasterDataSource(jsObject);
        case 'table':
            let {buildDotNetTableDataSource} = await import('./tableDataSource');
            return await buildDotNetTableDataSource(jsObject, viewId);
        default:
            return null;
    }
}
