export async function buildJsSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSchemesGenerated} = await import('./schemes.gb');
    return await buildJsSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSchemes(jsObject: any): Promise<any> {
    let {buildDotNetSchemesGenerated} = await import('./schemes.gb');
    return await buildDotNetSchemesGenerated(jsObject);
}
