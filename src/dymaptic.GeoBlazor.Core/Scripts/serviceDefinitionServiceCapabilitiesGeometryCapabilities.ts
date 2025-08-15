
export async function buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(jsObject, viewId);
}
