
export async function buildJsFieldConfiguration(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldConfigurationGenerated } = await import('./fieldConfiguration.gb');
    return await buildJsFieldConfigurationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldConfiguration(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFieldConfigurationGenerated } = await import('./fieldConfiguration.gb');
    return await buildDotNetFieldConfigurationGenerated(jsObject, viewId);
}
