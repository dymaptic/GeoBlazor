
export async function buildJsBinParametersBase(dotNetObject: any): Promise<any> {
    let { buildJsBinParametersBaseGenerated } = await import('./binParametersBase.gb');
    return await buildJsBinParametersBaseGenerated(dotNetObject);
}     

export async function buildDotNetBinParametersBase(jsObject: any): Promise<any> {
    let { buildDotNetBinParametersBaseGenerated } = await import('./binParametersBase.gb');
    return await buildDotNetBinParametersBaseGenerated(jsObject);
}
