export async function buildJsDimensionSimpleStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDimensionSimpleStyleGenerated} = await import('./dimensionSimpleStyle.gb');
    return await buildJsDimensionSimpleStyleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDimensionSimpleStyle(jsObject: any): Promise<any> {
    let {buildDotNetDimensionSimpleStyleGenerated} = await import('./dimensionSimpleStyle.gb');
    return await buildDotNetDimensionSimpleStyleGenerated(jsObject);
}
