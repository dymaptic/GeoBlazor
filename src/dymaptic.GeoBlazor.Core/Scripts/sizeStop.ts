
export async function buildJsSizeStop(dotNetObject: any): Promise<any> {
    let { buildJsSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildJsSizeStopGenerated(dotNetObject);
}     

export async function buildDotNetSizeStop(jsObject: any): Promise<any> {
    let { buildDotNetSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildDotNetSizeStopGenerated(jsObject);
}
