export async function buildJsSizeSchemeForPolygonBackground(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeSchemeForPolygonBackgroundGenerated} = await import('./sizeSchemeForPolygonBackground.gb');
    return await buildJsSizeSchemeForPolygonBackgroundGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeSchemeForPolygonBackground(jsObject: any): Promise<any> {
    let {buildDotNetSizeSchemeForPolygonBackgroundGenerated} = await import('./sizeSchemeForPolygonBackground.gb');
    return await buildDotNetSizeSchemeForPolygonBackgroundGenerated(jsObject);
}
