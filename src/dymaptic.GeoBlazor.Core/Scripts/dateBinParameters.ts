
export async function buildJsDateBinParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateBinParametersGenerated } = await import('./dateBinParameters.gb');
    return await buildJsDateBinParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateBinParameters(jsObject: any): Promise<any> {
    let { buildDotNetDateBinParametersGenerated } = await import('./dateBinParameters.gb');
    return await buildDotNetDateBinParametersGenerated(jsObject);
}
