
export async function buildJsTimeInterval(dotNetObject: any): Promise<any> {
    let { buildJsTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildJsTimeIntervalGenerated(dotNetObject);
}     

export async function buildDotNetTimeInterval(jsObject: any): Promise<any> {
    let { buildDotNetTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildDotNetTimeIntervalGenerated(jsObject);
}
