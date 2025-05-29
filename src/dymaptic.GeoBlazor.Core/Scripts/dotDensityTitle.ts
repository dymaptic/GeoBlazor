
export async function buildJsDotDensityTitle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityTitleGenerated } = await import('./dotDensityTitle.gb');
    return await buildJsDotDensityTitleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityTitle(jsObject: any): Promise<any> {
    let { buildDotNetDotDensityTitleGenerated } = await import('./dotDensityTitle.gb');
    return await buildDotNetDotDensityTitleGenerated(jsObject);
}
