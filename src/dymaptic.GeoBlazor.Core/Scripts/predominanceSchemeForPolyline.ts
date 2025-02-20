export async function buildJsPredominanceSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceSchemeForPolylineGenerated} = await import('./predominanceSchemeForPolyline.gb');
    return await buildJsPredominanceSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceSchemeForPolyline(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceSchemeForPolylineGenerated} = await import('./predominanceSchemeForPolyline.gb');
    return await buildDotNetPredominanceSchemeForPolylineGenerated(jsObject);
}
