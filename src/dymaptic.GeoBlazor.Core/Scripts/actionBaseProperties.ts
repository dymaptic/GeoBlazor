
export async function buildJsActionBaseProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsActionBasePropertiesGenerated } = await import('./actionBaseProperties.gb');
    return await buildJsActionBasePropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetActionBaseProperties(jsObject: any): Promise<any> {
    let { buildDotNetActionBasePropertiesGenerated } = await import('./actionBaseProperties.gb');
    return await buildDotNetActionBasePropertiesGenerated(jsObject);
}
