
export async function buildJsJunctionSourceJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsJunctionSourceJSONGenerated } = await import('./junctionSourceJSON.gb');
    return await buildJsJunctionSourceJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetJunctionSourceJSON(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetJunctionSourceJSONGenerated } = await import('./junctionSourceJSON.gb');
    return await buildDotNetJunctionSourceJSONGenerated(jsObject, layerId, viewId);
}
