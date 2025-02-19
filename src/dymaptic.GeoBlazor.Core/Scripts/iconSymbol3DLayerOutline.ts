
export async function buildJsIconSymbol3DLayerOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIconSymbol3DLayerOutlineGenerated } = await import('./iconSymbol3DLayerOutline.gb');
    return await buildJsIconSymbol3DLayerOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIconSymbol3DLayerOutline(jsObject: any): Promise<any> {
    let { buildDotNetIconSymbol3DLayerOutlineGenerated } = await import('./iconSymbol3DLayerOutline.gb');
    return await buildDotNetIconSymbol3DLayerOutlineGenerated(jsObject);
}
