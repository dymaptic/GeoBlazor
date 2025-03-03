
export async function buildJsColorAndIntensity(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorAndIntensityGenerated } = await import('./colorAndIntensity.gb');
    return await buildJsColorAndIntensityGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorAndIntensity(jsObject: any): Promise<any> {
    let { buildDotNetColorAndIntensityGenerated } = await import('./colorAndIntensity.gb');
    return await buildDotNetColorAndIntensityGenerated(jsObject);
}
