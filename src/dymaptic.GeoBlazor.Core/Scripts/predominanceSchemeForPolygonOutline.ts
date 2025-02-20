export async function buildJsPredominanceSchemeForPolygonOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceSchemeForPolygonOutlineGenerated} = await import('./predominanceSchemeForPolygonOutline.gb');
    return await buildJsPredominanceSchemeForPolygonOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceSchemeForPolygonOutline(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceSchemeForPolygonOutlineGenerated} = await import('./predominanceSchemeForPolygonOutline.gb');
    return await buildDotNetPredominanceSchemeForPolygonOutlineGenerated(jsObject);
}
