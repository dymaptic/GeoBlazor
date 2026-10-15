
export async function buildJsSizeSchemeForPolygonBackgroundOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSchemeForPolygonBackgroundOutlineGenerated } = await import('./sizeSchemeForPolygonBackgroundOutline.gb');
    return await buildJsSizeSchemeForPolygonBackgroundOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSchemeForPolygonBackgroundOutline(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSizeSchemeForPolygonBackgroundOutlineGenerated } = await import('./sizeSchemeForPolygonBackgroundOutline.gb');
    return await buildDotNetSizeSchemeForPolygonBackgroundOutlineGenerated(jsObject, viewId);
}
