
export async function buildJsTimeInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildJsTimeInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeInfo(jsObject: any): Promise<any> {
    let { buildDotNetTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildDotNetTimeInfoGenerated(jsObject);
}
