export async function buildJsPieChartRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPieChartRendererResultGenerated} = await import('./pieChartRendererResult.gb');
    return await buildJsPieChartRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPieChartRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetPieChartRendererResultGenerated} = await import('./pieChartRendererResult.gb');
    return await buildDotNetPieChartRendererResultGenerated(jsObject);
}
