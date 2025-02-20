export async function buildJsLocationSchemeForPolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationSchemeForPolylineGenerated} = await import('./locationSchemeForPolyline.gb');
    return await buildJsLocationSchemeForPolylineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationSchemeForPolyline(jsObject: any): Promise<any> {
    let {buildDotNetLocationSchemeForPolylineGenerated} = await import('./locationSchemeForPolyline.gb');
    return await buildDotNetLocationSchemeForPolylineGenerated(jsObject);
}
