export async function buildJsTypeSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeSchemeForPolygonGenerated} = await import('./typeSchemeForPolygon.gb');
    return await buildJsTypeSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeSchemeForPolygon(jsObject: any): Promise<any> {
    let {buildDotNetTypeSchemeForPolygonGenerated} = await import('./typeSchemeForPolygon.gb');
    return await buildDotNetTypeSchemeForPolygonGenerated(jsObject);
}
