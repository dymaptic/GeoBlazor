
export async function buildJsConfiguration(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigurationGenerated } = await import('./configuration.gb');
    return await buildJsConfigurationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfiguration(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetConfigurationGenerated } = await import('./configuration.gb');
    return await buildDotNetConfigurationGenerated(jsObject, viewId);
}
