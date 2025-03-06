
export async function buildJsServiceDefinitionServiceCapabilitiesSearchCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesSearchCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesSearchCapabilitiesGenerated(jsObject, layerId, viewId);
}
