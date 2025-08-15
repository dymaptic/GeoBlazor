
export async function buildJsServiceDefinitionServiceCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGenerated(jsObject, viewId);
}
