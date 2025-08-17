
export async function buildJsTimeInfo(dotNetObject: any): Promise<any> {
    let { buildJsTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildJsTimeInfoGenerated(dotNetObject);
}     

export async function buildDotNetTimeInfo(jsObject: any): Promise<any> {
    let { buildDotNetTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildDotNetTimeInfoGenerated(jsObject);
}
