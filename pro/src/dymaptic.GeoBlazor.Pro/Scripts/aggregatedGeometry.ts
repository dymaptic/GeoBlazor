
export async function buildJsAggregatedGeometry(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAggregatedGeometryGenerated } = await import('./aggregatedGeometry.gb');
    return await buildJsAggregatedGeometryGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAggregatedGeometry(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAggregatedGeometryGenerated } = await import('./aggregatedGeometry.gb');
    return await buildDotNetAggregatedGeometryGenerated(jsObject, viewId);
}
