
export async function buildJsVoxelDynamicSection(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildJsVoxelDynamicSectionGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVoxelDynamicSection(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildDotNetVoxelDynamicSectionGenerated(jsObject, viewId);
}
