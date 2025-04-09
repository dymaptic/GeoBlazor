
export async function buildJsDateBinTimeInterval(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateBinTimeIntervalGenerated } = await import('./dateBinTimeInterval.gb');
    return await buildJsDateBinTimeIntervalGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateBinTimeInterval(jsObject: any): Promise<any> {
    let { buildDotNetDateBinTimeIntervalGenerated } = await import('./dateBinTimeInterval.gb');
    return await buildDotNetDateBinTimeIntervalGenerated(jsObject);
}
