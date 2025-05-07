
export async function buildJsLayerDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerDefinitionGenerated } = await import('./layerDefinition.gb');
    return await buildJsLayerDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerDefinition(jsObject: any): Promise<any> {
    let { buildDotNetLayerDefinitionGenerated } = await import('./layerDefinition.gb');
    return await buildDotNetLayerDefinitionGenerated(jsObject);
}
