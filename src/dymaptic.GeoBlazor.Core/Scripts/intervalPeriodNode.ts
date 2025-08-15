
export async function buildJsIntervalPeriodNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntervalPeriodNodeGenerated } = await import('./intervalPeriodNode.gb');
    return await buildJsIntervalPeriodNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntervalPeriodNode(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIntervalPeriodNodeGenerated } = await import('./intervalPeriodNode.gb');
    return await buildDotNetIntervalPeriodNodeGenerated(jsObject, viewId);
}
