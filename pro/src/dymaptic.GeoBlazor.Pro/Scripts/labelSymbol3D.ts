
export async function buildJsLabelSymbol3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLabelSymbol3DGenerated } = await import('./labelSymbol3D.gb');
    return await buildJsLabelSymbol3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLabelSymbol3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLabelSymbol3DGenerated } = await import('./labelSymbol3D.gb');
    return await buildDotNetLabelSymbol3DGenerated(jsObject, layerId, viewId);
}
