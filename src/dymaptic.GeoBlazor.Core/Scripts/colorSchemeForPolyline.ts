
export async function buildJsColorSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForPolylineGenerated } = await import('./colorSchemeForPolyline.gb');
    return await buildJsColorSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSchemeForPolyline(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForPolylineGenerated } = await import('./colorSchemeForPolyline.gb');
    return await buildDotNetColorSchemeForPolylineGenerated(jsObject);
}
