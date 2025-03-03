
export async function buildJsCIMScaleDependentSizeVariation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMScaleDependentSizeVariationGenerated } = await import('./cIMScaleDependentSizeVariation.gb');
    return await buildJsCIMScaleDependentSizeVariationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMScaleDependentSizeVariation(jsObject: any): Promise<any> {
    let { buildDotNetCIMScaleDependentSizeVariationGenerated } = await import('./cIMScaleDependentSizeVariation.gb');
    return await buildDotNetCIMScaleDependentSizeVariationGenerated(jsObject);
}
