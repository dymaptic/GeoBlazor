
export async function buildJsSizeSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSchemeForPolylineGenerated } = await import('./sizeSchemeForPolyline.gb');
    return await buildJsSizeSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSchemeForPolyline(jsObject: any): Promise<any> {
    let { buildDotNetSizeSchemeForPolylineGenerated } = await import('./sizeSchemeForPolyline.gb');
    return await buildDotNetSizeSchemeForPolylineGenerated(jsObject);
}
