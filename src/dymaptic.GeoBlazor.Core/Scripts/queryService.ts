// override generated code in this file
import QueryServiceGenerated from './queryService.gb';
import query = __esri.query;

export default class QueryServiceWrapper extends QueryServiceGenerated {

    constructor(component: query) {
        super(component);
    }
    
}

export async function buildJsQueryService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsQueryServiceGenerated } = await import('./queryService.gb');
    return await buildJsQueryServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetQueryService(jsObject: any): Promise<any> {
    let { buildDotNetQueryServiceGenerated } = await import('./queryService.gb');
    return await buildDotNetQueryServiceGenerated(jsObject);
}
