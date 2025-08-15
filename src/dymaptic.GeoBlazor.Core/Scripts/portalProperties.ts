
export async function buildJsPortalProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalPropertiesGenerated } = await import('./portalProperties.gb');
    return await buildJsPortalPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPortalProperties(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPortalPropertiesGenerated } = await import('./portalProperties.gb');
    return await buildDotNetPortalPropertiesGenerated(jsObject, viewId);
}
