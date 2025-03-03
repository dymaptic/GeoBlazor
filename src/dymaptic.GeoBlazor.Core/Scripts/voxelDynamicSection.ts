
export async function buildJsVoxelDynamicSection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildJsVoxelDynamicSectionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelDynamicSection(jsObject: any): Promise<any> {
    let { buildDotNetVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildDotNetVoxelDynamicSectionGenerated(jsObject);
}
