
export async function buildJsBinParametersBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinParametersBaseGenerated } = await import('./binParametersBase.gb');
    return await buildJsBinParametersBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBinParametersBase(jsObject: any): Promise<any> {
    let { buildDotNetBinParametersBaseGenerated } = await import('./binParametersBase.gb');
    return await buildDotNetBinParametersBaseGenerated(jsObject);
}
