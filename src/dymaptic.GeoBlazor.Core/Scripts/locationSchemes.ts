export async function buildJsLocationSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationSchemesGenerated} = await import('./locationSchemes.gb');
    return await buildJsLocationSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationSchemes(jsObject: any): Promise<any> {
    let {buildDotNetLocationSchemesGenerated} = await import('./locationSchemes.gb');
    return await buildDotNetLocationSchemesGenerated(jsObject);
}
