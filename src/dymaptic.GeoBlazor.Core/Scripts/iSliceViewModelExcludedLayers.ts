
export async function buildJsISliceViewModelExcludedLayers(dotNetObject: any): Promise<any> {
    let { buildJsISliceViewModelExcludedLayersGenerated } = await import('./iSliceViewModelExcludedLayers.gb');
    return await buildJsISliceViewModelExcludedLayersGenerated(dotNetObject);
}     

export async function buildDotNetISliceViewModelExcludedLayers(jsObject: any): Promise<any> {
    let { buildDotNetISliceViewModelExcludedLayersGenerated } = await import('./iSliceViewModelExcludedLayers.gb');
    return await buildDotNetISliceViewModelExcludedLayersGenerated(jsObject);
}
