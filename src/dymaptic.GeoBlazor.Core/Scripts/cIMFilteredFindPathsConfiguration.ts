
export async function buildJsCIMFilteredFindPathsConfiguration(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFilteredFindPathsConfigurationGenerated } = await import('./cIMFilteredFindPathsConfiguration.gb');
    return await buildJsCIMFilteredFindPathsConfigurationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFilteredFindPathsConfiguration(jsObject: any): Promise<any> {
    let { buildDotNetCIMFilteredFindPathsConfigurationGenerated } = await import('./cIMFilteredFindPathsConfiguration.gb');
    return await buildDotNetCIMFilteredFindPathsConfigurationGenerated(jsObject);
}
