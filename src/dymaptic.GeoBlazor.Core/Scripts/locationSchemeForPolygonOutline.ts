export async function buildJsLocationSchemeForPolygonOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocationSchemeForPolygonOutlineGenerated } = await import('./locationSchemeForPolygonOutline.gb');
    return await buildJsLocationSchemeForPolygonOutlineGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLocationSchemeForPolygonOutline(jsObject: any): Promise<any> {
    let { buildDotNetLocationSchemeForPolygonOutlineGenerated } = await import('./locationSchemeForPolygonOutline.gb');
    return await buildDotNetLocationSchemeForPolygonOutlineGenerated(jsObject);
}
