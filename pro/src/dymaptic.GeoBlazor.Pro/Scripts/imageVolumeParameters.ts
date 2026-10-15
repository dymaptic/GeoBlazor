
export async function buildJsImageVolumeParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageVolumeParametersGenerated } = await import('./imageVolumeParameters.gb');
    return await buildJsImageVolumeParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageVolumeParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageVolumeParametersGenerated } = await import('./imageVolumeParameters.gb');
    return await buildDotNetImageVolumeParametersGenerated(jsObject);
}
