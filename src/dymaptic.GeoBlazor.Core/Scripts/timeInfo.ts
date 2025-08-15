
export async function buildJsTimeInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildJsTimeInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTimeInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildDotNetTimeInfoGenerated(jsObject, viewId);
}
