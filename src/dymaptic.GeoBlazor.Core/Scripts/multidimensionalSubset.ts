export async function buildJsMultidimensionalSubset(dotNetObject: any): Promise<any> {
    let {buildJsMultidimensionalSubsetGenerated} = await import('./multidimensionalSubset.gb');
    return await buildJsMultidimensionalSubsetGenerated(dotNetObject);
}

export async function buildDotNetMultidimensionalSubset(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetMultidimensionalSubsetGenerated} = await import('./multidimensionalSubset.gb');
    return await buildDotNetMultidimensionalSubsetGenerated(jsObject, viewId);
}
