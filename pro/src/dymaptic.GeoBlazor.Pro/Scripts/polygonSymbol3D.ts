
export async function buildJsPolygonSymbol3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonSymbol3DGenerated } = await import('./polygonSymbol3D.gb');
    return await buildJsPolygonSymbol3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonSymbol3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPolygonSymbol3DGenerated } = await import('./polygonSymbol3D.gb');
    return await buildDotNetPolygonSymbol3DGenerated(jsObject, layerId, viewId);
}
