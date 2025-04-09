
export async function buildJsCIMFilteredFindPathsResultPaths(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFilteredFindPathsResultPathsGenerated } = await import('./cIMFilteredFindPathsResultPaths.gb');
    return await buildJsCIMFilteredFindPathsResultPathsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFilteredFindPathsResultPaths(jsObject: any): Promise<any> {
    let { buildDotNetCIMFilteredFindPathsResultPathsGenerated } = await import('./cIMFilteredFindPathsResultPaths.gb');
    return await buildDotNetCIMFilteredFindPathsResultPathsGenerated(jsObject);
}
