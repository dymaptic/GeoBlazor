
export async function buildJsPointSizeSplatAlgorithm(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointSizeSplatAlgorithmGenerated } = await import('./pointSizeSplatAlgorithm.gb');
    return await buildJsPointSizeSplatAlgorithmGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointSizeSplatAlgorithm(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointSizeSplatAlgorithmGenerated } = await import('./pointSizeSplatAlgorithm.gb');
    return await buildDotNetPointSizeSplatAlgorithmGenerated(jsObject, viewId);
}
