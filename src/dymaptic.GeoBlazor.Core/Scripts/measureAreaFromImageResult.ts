export async function buildJsMeasureAreaFromImageResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMeasureAreaFromImageResultGenerated} = await import('./measureAreaFromImageResult.gb');
    return await buildJsMeasureAreaFromImageResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMeasureAreaFromImageResult(jsObject: any): Promise<any> {
    let {buildDotNetMeasureAreaFromImageResultGenerated} = await import('./measureAreaFromImageResult.gb');
    return await buildDotNetMeasureAreaFromImageResultGenerated(jsObject);
}
