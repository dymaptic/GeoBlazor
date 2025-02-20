export async function buildJsColorSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSchemesGenerated} = await import('./colorSchemes.gb');
    return await buildJsColorSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSchemes(jsObject: any): Promise<any> {
    let {buildDotNetColorSchemesGenerated} = await import('./colorSchemes.gb');
    return await buildDotNetColorSchemesGenerated(jsObject);
}
