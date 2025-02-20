export async function buildJsPredominanceSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceSchemeForPolygonGenerated} = await import('./predominanceSchemeForPolygon.gb');
    return await buildJsPredominanceSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceSchemeForPolygon(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceSchemeForPolygonGenerated} = await import('./predominanceSchemeForPolygon.gb');
    return await buildDotNetPredominanceSchemeForPolygonGenerated(jsObject);
}
