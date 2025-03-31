
export async function buildJsSymbol3DVerticalOffset(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbol3DVerticalOffsetGenerated } = await import('./symbol3DVerticalOffset.gb');
    return await buildJsSymbol3DVerticalOffsetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbol3DVerticalOffset(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSymbol3DVerticalOffsetGenerated } = await import('./symbol3DVerticalOffset.gb');
    return await buildDotNetSymbol3DVerticalOffsetGenerated(jsObject, layerId, viewId);
}
