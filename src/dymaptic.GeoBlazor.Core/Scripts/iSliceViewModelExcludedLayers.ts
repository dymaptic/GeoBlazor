
export async function buildJsISliceViewModelExcludedLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISliceViewModelExcludedLayersGenerated } = await import('./iSliceViewModelExcludedLayers.gb');
    return await buildJsISliceViewModelExcludedLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISliceViewModelExcludedLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISliceViewModelExcludedLayersGenerated } = await import('./iSliceViewModelExcludedLayers.gb');
    return await buildDotNetISliceViewModelExcludedLayersGenerated(jsObject, viewId);
}
