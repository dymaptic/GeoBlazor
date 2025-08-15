
export async function buildJsTableDefinition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableDefinitionGenerated } = await import('./tableDefinition.gb');
    return await buildJsTableDefinitionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableDefinition(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTableDefinitionGenerated } = await import('./tableDefinition.gb');
    return await buildDotNetTableDefinitionGenerated(jsObject, viewId);
}
