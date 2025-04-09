
export async function buildJsOrientedImageryLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrientedImageryLayerSaveAsOptionsGenerated } = await import('./orientedImageryLayerSaveAsOptions.gb');
    return await buildJsOrientedImageryLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrientedImageryLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetOrientedImageryLayerSaveAsOptionsGenerated } = await import('./orientedImageryLayerSaveAsOptions.gb');
    return await buildDotNetOrientedImageryLayerSaveAsOptionsGenerated(jsObject);
}
