
export async function buildJsCIMFilteredFindPathsResultJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFilteredFindPathsResultJSONGenerated } = await import('./cIMFilteredFindPathsResultJSON.gb');
    return await buildJsCIMFilteredFindPathsResultJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFilteredFindPathsResultJSON(jsObject: any): Promise<any> {
    let { buildDotNetCIMFilteredFindPathsResultJSONGenerated } = await import('./cIMFilteredFindPathsResultJSON.gb');
    return await buildDotNetCIMFilteredFindPathsResultJSONGenerated(jsObject);
}
