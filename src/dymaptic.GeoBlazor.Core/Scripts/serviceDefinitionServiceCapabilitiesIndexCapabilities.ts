
export async function buildJsServiceDefinitionServiceCapabilitiesIndexCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesIndexCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesIndexCapabilitiesGenerated(jsObject, viewId);
}
