
export async function buildJsIFieldConfigurationFieldFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFieldConfigurationFieldFormatGenerated } = await import('./iFieldConfigurationFieldFormat.gb');
    return await buildJsIFieldConfigurationFieldFormatGenerated(dotNetObject);
}     

export async function buildDotNetIFieldConfigurationFieldFormat(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFieldConfigurationFieldFormatGenerated } = await import('./iFieldConfigurationFieldFormat.gb');
    return await buildDotNetIFieldConfigurationFieldFormatGenerated(jsObject);
}
