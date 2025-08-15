
export async function buildJsUpdateElevationPropsWithConstant(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUpdateElevationPropsWithConstantGenerated } = await import('./updateElevationPropsWithConstant.gb');
    return await buildJsUpdateElevationPropsWithConstantGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUpdateElevationPropsWithConstant(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUpdateElevationPropsWithConstantGenerated } = await import('./updateElevationPropsWithConstant.gb');
    return await buildDotNetUpdateElevationPropsWithConstantGenerated(jsObject, viewId);
}
