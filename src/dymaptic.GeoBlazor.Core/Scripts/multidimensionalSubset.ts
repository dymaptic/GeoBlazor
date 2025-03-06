export async function buildJsMultidimensionalSubset(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMultidimensionalSubsetGenerated} = await import('./multidimensionalSubset.gb');
    return await buildJsMultidimensionalSubsetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMultidimensionalSubset(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMultidimensionalSubsetGenerated} = await import('./multidimensionalSubset.gb');
    return await buildDotNetMultidimensionalSubsetGenerated(jsObject, layerId, viewId);
}
