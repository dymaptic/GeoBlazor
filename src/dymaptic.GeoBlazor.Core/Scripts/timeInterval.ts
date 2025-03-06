
export async function buildJsTimeInterval(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildJsTimeIntervalGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeInterval(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildDotNetTimeIntervalGenerated(jsObject, layerId, viewId);
}
