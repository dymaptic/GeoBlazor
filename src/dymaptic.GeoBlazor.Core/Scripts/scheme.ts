export async function buildJsScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSchemeGenerated } = await import('./scheme.gb');
    return await buildJsSchemeGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetScheme(jsObject: any): Promise<any> {
    let { buildDotNetSchemeGenerated } = await import('./scheme.gb');
    return await buildDotNetSchemeGenerated(jsObject);
}
