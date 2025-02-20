export async function buildJsContinuousRendererResultSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsContinuousRendererResultSizeGenerated} = await import('./continuousRendererResultSize.gb');
    return await buildJsContinuousRendererResultSizeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetContinuousRendererResultSize(jsObject: any): Promise<any> {
    let {buildDotNetContinuousRendererResultSizeGenerated} = await import('./continuousRendererResultSize.gb');
    return await buildDotNetContinuousRendererResultSizeGenerated(jsObject);
}
