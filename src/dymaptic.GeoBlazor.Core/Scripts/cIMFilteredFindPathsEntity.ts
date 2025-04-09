
export async function buildJsCIMFilteredFindPathsEntity(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFilteredFindPathsEntityGenerated } = await import('./cIMFilteredFindPathsEntity.gb');
    return await buildJsCIMFilteredFindPathsEntityGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFilteredFindPathsEntity(jsObject: any): Promise<any> {
    let { buildDotNetCIMFilteredFindPathsEntityGenerated } = await import('./cIMFilteredFindPathsEntity.gb');
    return await buildDotNetCIMFilteredFindPathsEntityGenerated(jsObject);
}
