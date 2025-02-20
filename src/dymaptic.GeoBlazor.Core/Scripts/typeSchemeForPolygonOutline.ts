export async function buildJsTypeSchemeForPolygonOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeSchemeForPolygonOutlineGenerated} = await import('./typeSchemeForPolygonOutline.gb');
    return await buildJsTypeSchemeForPolygonOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeSchemeForPolygonOutline(jsObject: any): Promise<any> {
    let {buildDotNetTypeSchemeForPolygonOutlineGenerated} = await import('./typeSchemeForPolygonOutline.gb');
    return await buildDotNetTypeSchemeForPolygonOutlineGenerated(jsObject);
}
