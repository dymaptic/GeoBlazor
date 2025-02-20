export async function buildJsColorSchemeForPolygonOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSchemeForPolygonOutlineGenerated} = await import('./colorSchemeForPolygonOutline.gb');
    return await buildJsColorSchemeForPolygonOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSchemeForPolygonOutline(jsObject: any): Promise<any> {
    let {buildDotNetColorSchemeForPolygonOutlineGenerated} = await import('./colorSchemeForPolygonOutline.gb');
    return await buildDotNetColorSchemeForPolygonOutlineGenerated(jsObject);
}
