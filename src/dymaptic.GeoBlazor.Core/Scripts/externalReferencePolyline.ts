
export async function buildJsExternalReferencePolyline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalReferencePolylineGenerated } = await import('./externalReferencePolyline.gb');
    return await buildJsExternalReferencePolylineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExternalReferencePolyline(jsObject: any): Promise<any> {
    let { buildDotNetExternalReferencePolylineGenerated } = await import('./externalReferencePolyline.gb');
    return await buildDotNetExternalReferencePolylineGenerated(jsObject);
}
