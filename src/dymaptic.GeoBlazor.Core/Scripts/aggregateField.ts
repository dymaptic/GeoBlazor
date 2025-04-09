
export async function buildJsAggregateField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAggregateFieldGenerated } = await import('./aggregateField.gb');
    return await buildJsAggregateFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAggregateField(jsObject: any): Promise<any> {
    let { buildDotNetAggregateFieldGenerated } = await import('./aggregateField.gb');
    return await buildDotNetAggregateFieldGenerated(jsObject);
}
