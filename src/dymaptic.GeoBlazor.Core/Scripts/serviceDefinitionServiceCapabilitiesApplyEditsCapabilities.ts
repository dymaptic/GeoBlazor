
export async function buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesApplyEditsCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesApplyEditsCapabilitiesGenerated(jsObject);
}
