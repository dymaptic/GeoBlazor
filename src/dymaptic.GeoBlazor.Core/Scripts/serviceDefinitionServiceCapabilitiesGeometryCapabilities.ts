
export async function buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(jsObject);
}
