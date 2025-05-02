
export async function buildJsWebLinkChartApplyLayoutOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebLinkChartApplyLayoutOptionsGenerated } = await import('./webLinkChartApplyLayoutOptions.gb');
    return await buildJsWebLinkChartApplyLayoutOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebLinkChartApplyLayoutOptions(jsObject: any): Promise<any> {
    let { buildDotNetWebLinkChartApplyLayoutOptionsGenerated } = await import('./webLinkChartApplyLayoutOptions.gb');
    return await buildDotNetWebLinkChartApplyLayoutOptionsGenerated(jsObject);
}
