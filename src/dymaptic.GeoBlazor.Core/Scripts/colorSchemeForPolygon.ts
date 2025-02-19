
export async function buildJsColorSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForPolygonGenerated } = await import('./colorSchemeForPolygon.gb');
    return await buildJsColorSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSchemeForPolygon(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForPolygonGenerated } = await import('./colorSchemeForPolygon.gb');
    return await buildDotNetColorSchemeForPolygonGenerated(jsObject);
}
