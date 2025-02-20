export async function buildJsPieChartSchemeOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPieChartSchemeOutlineGenerated} = await import('./pieChartSchemeOutline.gb');
    return await buildJsPieChartSchemeOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPieChartSchemeOutline(jsObject: any): Promise<any> {
    let {buildDotNetPieChartSchemeOutlineGenerated} = await import('./pieChartSchemeOutline.gb');
    return await buildDotNetPieChartSchemeOutlineGenerated(jsObject);
}
