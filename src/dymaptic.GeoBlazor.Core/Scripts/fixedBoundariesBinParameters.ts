
export async function buildJsFixedBoundariesBinParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFixedBoundariesBinParametersGenerated } = await import('./fixedBoundariesBinParameters.gb');
    return await buildJsFixedBoundariesBinParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFixedBoundariesBinParameters(jsObject: any): Promise<any> {
    let { buildDotNetFixedBoundariesBinParametersGenerated } = await import('./fixedBoundariesBinParameters.gb');
    return await buildDotNetFixedBoundariesBinParametersGenerated(jsObject);
}
