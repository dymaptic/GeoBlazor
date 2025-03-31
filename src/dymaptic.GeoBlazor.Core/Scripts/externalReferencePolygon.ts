
export async function buildJsExternalReferencePolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalReferencePolygonGenerated } = await import('./externalReferencePolygon.gb');
    return await buildJsExternalReferencePolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExternalReferencePolygon(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetExternalReferencePolygonGenerated } = await import('./externalReferencePolygon.gb');
    return await buildDotNetExternalReferencePolygonGenerated(jsObject, layerId, viewId);
}
