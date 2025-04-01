
export async function buildJsElevationProfileLineView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileLineViewGenerated } = await import('./elevationProfileLineView.gb');
    return await buildJsElevationProfileLineViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileLineView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetElevationProfileLineViewGenerated } = await import('./elevationProfileLineView.gb');
    return await buildDotNetElevationProfileLineViewGenerated(jsObject, layerId, viewId);
}
