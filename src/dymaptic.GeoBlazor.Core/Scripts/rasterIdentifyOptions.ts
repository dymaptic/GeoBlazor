// override generated code in this file


export async function buildJsRasterIdentifyOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterIdentifyOptionsGenerated} = await import('./rasterIdentifyOptions.gb');
    return await buildJsRasterIdentifyOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterIdentifyOptions(jsObject: any): Promise<any> {
    let {buildDotNetRasterIdentifyOptionsGenerated} = await import('./rasterIdentifyOptions.gb');
    return await buildDotNetRasterIdentifyOptionsGenerated(jsObject);
}
