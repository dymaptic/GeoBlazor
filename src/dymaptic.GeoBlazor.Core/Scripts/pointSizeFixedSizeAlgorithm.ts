
export async function buildJsPointSizeFixedSizeAlgorithm(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointSizeFixedSizeAlgorithmGenerated } = await import('./pointSizeFixedSizeAlgorithm.gb');
    return await buildJsPointSizeFixedSizeAlgorithmGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointSizeFixedSizeAlgorithm(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointSizeFixedSizeAlgorithmGenerated } = await import('./pointSizeFixedSizeAlgorithm.gb');
    return await buildDotNetPointSizeFixedSizeAlgorithmGenerated(jsObject, viewId);
}
