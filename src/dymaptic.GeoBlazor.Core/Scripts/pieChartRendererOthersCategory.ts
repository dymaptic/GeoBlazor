export async function buildJsPieChartRendererOthersCategory(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPieChartRendererOthersCategoryGenerated} = await import('./pieChartRendererOthersCategory.gb');
    return await buildJsPieChartRendererOthersCategoryGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPieChartRendererOthersCategory(jsObject: any): Promise<any> {
    let {buildDotNetPieChartRendererOthersCategoryGenerated} = await import('./pieChartRendererOthersCategory.gb');
    return await buildDotNetPieChartRendererOthersCategoryGenerated(jsObject);
}
