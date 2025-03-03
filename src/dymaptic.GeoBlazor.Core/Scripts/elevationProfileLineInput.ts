
export async function buildJsElevationProfileLineInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileLineInputGenerated } = await import('./elevationProfileLineInput.gb');
    return await buildJsElevationProfileLineInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileLineInput(jsObject: any): Promise<any> {
    let { buildDotNetElevationProfileLineInputGenerated } = await import('./elevationProfileLineInput.gb');
    return await buildDotNetElevationProfileLineInputGenerated(jsObject);
}
