
export async function buildJsInitialViewProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInitialViewPropertiesGenerated } = await import('./initialViewProperties.gb');
    return await buildJsInitialViewPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInitialViewProperties(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetInitialViewPropertiesGenerated } = await import('./initialViewProperties.gb');
    return await buildDotNetInitialViewPropertiesGenerated(jsObject, layerId, viewId);
}
