export async function buildJsLocationSchemeForPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationSchemeForPolygonGenerated} = await import('./locationSchemeForPolygon.gb');
    return await buildJsLocationSchemeForPolygonGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationSchemeForPolygon(jsObject: any): Promise<any> {
    let {buildDotNetLocationSchemeForPolygonGenerated} = await import('./locationSchemeForPolygon.gb');
    return await buildDotNetLocationSchemeForPolygonGenerated(jsObject);
}
