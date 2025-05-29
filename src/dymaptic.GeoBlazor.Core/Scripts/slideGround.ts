
export async function buildJsSlideGround(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSlideGroundGenerated } = await import('./slideGround.gb');
    return await buildJsSlideGroundGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSlideGround(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSlideGroundGenerated } = await import('./slideGround.gb');
    return await buildDotNetSlideGroundGenerated(jsObject, layerId, viewId);
}
