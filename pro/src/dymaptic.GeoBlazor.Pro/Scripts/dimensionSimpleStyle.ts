
export async function buildJsDimensionSimpleStyle(dotNetObject: any): Promise<any> {
    let { buildJsDimensionSimpleStyleGenerated } = await import('./dimensionSimpleStyle.gb');
    return await buildJsDimensionSimpleStyleGenerated(dotNetObject);
}     

export async function buildDotNetDimensionSimpleStyle(jsObject: any): Promise<any> {
    let { buildDotNetDimensionSimpleStyleGenerated } = await import('./dimensionSimpleStyle.gb');
    return await buildDotNetDimensionSimpleStyleGenerated(jsObject);
}
