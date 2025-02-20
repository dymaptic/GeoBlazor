export async function buildJsGeometryFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeometryFilterGenerated} = await import('./geometryFilter.gb');
    return await buildJsGeometryFilterGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeometryFilter(jsObject: any): Promise<any> {
    let {buildDotNetGeometryFilterGenerated} = await import('./geometryFilter.gb');
    return await buildDotNetGeometryFilterGenerated(jsObject);
}
