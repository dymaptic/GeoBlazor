
export async function buildJsGraphQueryStreaming(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphQueryStreamingGenerated } = await import('./graphQueryStreaming.gb');
    return await buildJsGraphQueryStreamingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphQueryStreaming(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGraphQueryStreamingGenerated } = await import('./graphQueryStreaming.gb');
    return await buildDotNetGraphQueryStreamingGenerated(jsObject, layerId, viewId);
}
