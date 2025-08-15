
export async function buildJsPointCloudLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudLayerSaveAsOptionsGenerated } = await import('./pointCloudLayerSaveAsOptions.gb');
    return await buildJsPointCloudLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudLayerSaveAsOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudLayerSaveAsOptionsGenerated } = await import('./pointCloudLayerSaveAsOptions.gb');
    return await buildDotNetPointCloudLayerSaveAsOptionsGenerated(jsObject, viewId);
}
