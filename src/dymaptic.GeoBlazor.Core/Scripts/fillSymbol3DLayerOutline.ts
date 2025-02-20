export async function buildJsFillSymbol3DLayerOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFillSymbol3DLayerOutlineGenerated} = await import('./fillSymbol3DLayerOutline.gb');
    return await buildJsFillSymbol3DLayerOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFillSymbol3DLayerOutline(jsObject: any): Promise<any> {
    let {buildDotNetFillSymbol3DLayerOutlineGenerated} = await import('./fillSymbol3DLayerOutline.gb');
    return await buildDotNetFillSymbol3DLayerOutlineGenerated(jsObject);
}
