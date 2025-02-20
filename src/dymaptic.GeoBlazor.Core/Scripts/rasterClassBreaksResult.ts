export async function buildJsRasterClassBreaksResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterClassBreaksResultGenerated} = await import('./rasterClassBreaksResult.gb');
    return await buildJsRasterClassBreaksResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterClassBreaksResult(jsObject: any): Promise<any> {
    let {buildDotNetRasterClassBreaksResultGenerated} = await import('./rasterClassBreaksResult.gb');
    return await buildDotNetRasterClassBreaksResultGenerated(jsObject);
}
