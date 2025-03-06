
export async function buildJsEdgeSourceJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEdgeSourceJSONGenerated } = await import('./edgeSourceJSON.gb');
    return await buildJsEdgeSourceJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEdgeSourceJSON(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEdgeSourceJSONGenerated } = await import('./edgeSourceJSON.gb');
    return await buildDotNetEdgeSourceJSONGenerated(jsObject, layerId, viewId);
}
