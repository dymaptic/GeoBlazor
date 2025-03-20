
export async function buildJsVoxelDynamicSection(dotNetObject: any): Promise<any> {
    let { buildJsVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildJsVoxelDynamicSectionGenerated(dotNetObject);
}     

export async function buildDotNetVoxelDynamicSection(jsObject: any): Promise<any> {
    let { buildDotNetVoxelDynamicSectionGenerated } = await import('./voxelDynamicSection.gb');
    return await buildDotNetVoxelDynamicSectionGenerated(jsObject);
}
