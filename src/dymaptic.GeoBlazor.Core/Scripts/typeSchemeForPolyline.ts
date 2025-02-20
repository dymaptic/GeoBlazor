export async function buildJsTypeSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeSchemeForPolylineGenerated} = await import('./typeSchemeForPolyline.gb');
    return await buildJsTypeSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeSchemeForPolyline(jsObject: any): Promise<any> {
    let {buildDotNetTypeSchemeForPolylineGenerated} = await import('./typeSchemeForPolyline.gb');
    return await buildDotNetTypeSchemeForPolylineGenerated(jsObject);
}
