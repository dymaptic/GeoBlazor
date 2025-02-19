export async function buildJsLocationSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocationSchemeForPointGenerated } = await import('./locationSchemeForPoint.gb');
    return await buildJsLocationSchemeForPointGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLocationSchemeForPoint(jsObject: any): Promise<any> {
    let { buildDotNetLocationSchemeForPointGenerated } = await import('./locationSchemeForPoint.gb');
    return await buildDotNetLocationSchemeForPointGenerated(jsObject);
}
