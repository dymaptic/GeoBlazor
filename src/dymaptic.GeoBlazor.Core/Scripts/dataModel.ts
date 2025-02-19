export async function buildJsDataModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDataModelGenerated } = await import('./dataModel.gb');
    return await buildJsDataModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDataModel(jsObject: any): Promise<any> {
    let { buildDotNetDataModelGenerated } = await import('./dataModel.gb');
    return await buildDotNetDataModelGenerated(jsObject);
}
