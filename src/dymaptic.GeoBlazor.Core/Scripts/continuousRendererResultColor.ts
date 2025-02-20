export async function buildJsContinuousRendererResultColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsContinuousRendererResultColorGenerated} = await import('./continuousRendererResultColor.gb');
    return await buildJsContinuousRendererResultColorGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetContinuousRendererResultColor(jsObject: any): Promise<any> {
    let {buildDotNetContinuousRendererResultColorGenerated} = await import('./continuousRendererResultColor.gb');
    return await buildDotNetContinuousRendererResultColorGenerated(jsObject);
}
