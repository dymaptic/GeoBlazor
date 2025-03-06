// override generated code in this file


export async function buildJsRasterSliceValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterSliceValueGenerated} = await import('./rasterSliceValue.gb');
    return await buildJsRasterSliceValueGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterSliceValue(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetRasterSliceValueGenerated} = await import('./rasterSliceValue.gb');
    return await buildDotNetRasterSliceValueGenerated(jsObject, layerId, viewId);
}
