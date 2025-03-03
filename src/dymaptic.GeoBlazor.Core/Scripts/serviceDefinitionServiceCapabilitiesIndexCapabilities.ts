
export async function buildJsServiceDefinitionServiceCapabilitiesIndexCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(jsObject);
}
