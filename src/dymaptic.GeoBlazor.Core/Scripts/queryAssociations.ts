// override generated code in this file
import QueryAssociationsGenerated from './queryAssociations.gb';
import queryAssociations = __esri.queryAssociations;

export default class QueryAssociationsWrapper extends QueryAssociationsGenerated {

    constructor(component: queryAssociations) {
        super(component);
    }

}

export async function buildJsQueryAssociations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsQueryAssociationsGenerated} = await import('./queryAssociations.gb');
    return await buildJsQueryAssociationsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetQueryAssociations(jsObject: any): Promise<any> {
    let {buildDotNetQueryAssociationsGenerated} = await import('./queryAssociations.gb');
    return await buildDotNetQueryAssociationsGenerated(jsObject);
}
