
export async function buildJsBin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinGenerated } = await import('./bin.gb');
    return await buildJsBinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBin(jsObject: any): Promise<any> {
    let { buildDotNetBinGenerated } = await import('./bin.gb');
    return await buildDotNetBinGenerated(jsObject);
}
