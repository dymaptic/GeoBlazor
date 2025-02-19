export async function buildJsSizeSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSchemeForPolygonGenerated } = await import('./sizeSchemeForPolygon.gb');
    return await buildJsSizeSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSizeSchemeForPolygon(jsObject: any): Promise<any> {
    let { buildDotNetSizeSchemeForPolygonGenerated } = await import('./sizeSchemeForPolygon.gb');
    return await buildDotNetSizeSchemeForPolygonGenerated(jsObject);
}
