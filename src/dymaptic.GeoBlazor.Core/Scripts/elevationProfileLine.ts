export async function buildJsElevationProfileLine(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsElevationProfileLineGenerated} = await import('./elevationProfileLine.gb');
    return await buildJsElevationProfileLineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetElevationProfileLine(jsObject: any): Promise<any> {
    let {buildDotNetElevationProfileLineGenerated} = await import('./elevationProfileLine.gb');
    return await buildDotNetElevationProfileLineGenerated(jsObject);
}
