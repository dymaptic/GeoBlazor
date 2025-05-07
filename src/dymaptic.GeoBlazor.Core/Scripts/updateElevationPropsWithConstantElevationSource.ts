
export async function buildJsUpdateElevationPropsWithConstantElevationSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUpdateElevationPropsWithConstantElevationSourceGenerated } = await import('./updateElevationPropsWithConstantElevationSource.gb');
    return await buildJsUpdateElevationPropsWithConstantElevationSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUpdateElevationPropsWithConstantElevationSource(jsObject: any): Promise<any> {
    let { buildDotNetUpdateElevationPropsWithConstantElevationSourceGenerated } = await import('./updateElevationPropsWithConstantElevationSource.gb');
    return await buildDotNetUpdateElevationPropsWithConstantElevationSourceGenerated(jsObject);
}
