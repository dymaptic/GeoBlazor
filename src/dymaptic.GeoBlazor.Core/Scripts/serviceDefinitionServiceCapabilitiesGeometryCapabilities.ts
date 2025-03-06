
export async function buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated } = await import('./serviceDefinitionServiceCapabilitiesGeometryCapabilities.gb');
    return await buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(jsObject, layerId, viewId);
}
