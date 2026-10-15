
export async function buildJsPointSymbol3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointSymbol3DGenerated } = await import('./pointSymbol3D.gb');
    return await buildJsPointSymbol3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointSymbol3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointSymbol3DGenerated } = await import('./pointSymbol3D.gb');
    return await buildDotNetPointSymbol3DGenerated(jsObject, layerId, viewId);
}
