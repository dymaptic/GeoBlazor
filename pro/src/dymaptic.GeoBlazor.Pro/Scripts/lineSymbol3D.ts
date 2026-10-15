
export async function buildJsLineSymbol3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineSymbol3DGenerated } = await import('./lineSymbol3D.gb');
    return await buildJsLineSymbol3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineSymbol3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLineSymbol3DGenerated } = await import('./lineSymbol3D.gb');
    return await buildDotNetLineSymbol3DGenerated(jsObject, layerId, viewId);
}
