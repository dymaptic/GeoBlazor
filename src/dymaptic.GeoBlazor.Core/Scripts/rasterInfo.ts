// override generated code in this file

export async function buildJsRasterInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterInfoGenerated} = await import('./rasterInfo.gb');
    return await buildJsRasterInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterInfo(jsObject: any): Promise<any> {
    let {buildDotNetRasterInfoGenerated} = await import('./rasterInfo.gb');
    return await buildDotNetRasterInfoGenerated(jsObject);
}
