
export async function buildJsViewPadding(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPaddingGenerated } = await import('./viewPadding.gb');
    return await buildJsViewPaddingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPadding(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetViewPaddingGenerated } = await import('./viewPadding.gb');
    return await buildDotNetViewPaddingGenerated(jsObject, layerId, viewId);
}
