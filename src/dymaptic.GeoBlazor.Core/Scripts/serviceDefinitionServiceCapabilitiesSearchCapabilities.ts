
export async function buildJsServiceDefinitionServiceCapabilitiesSearchCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(jsObject, viewId);
}
