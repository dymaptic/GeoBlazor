
export async function buildJsTimeInterval(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildJsTimeIntervalGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTimeInterval(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildDotNetTimeIntervalGenerated(jsObject, viewId);
}
