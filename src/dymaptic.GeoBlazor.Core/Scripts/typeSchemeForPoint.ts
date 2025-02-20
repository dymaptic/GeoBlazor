export async function buildJsTypeSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeSchemeForPointGenerated} = await import('./typeSchemeForPoint.gb');
    return await buildJsTypeSchemeForPointGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeSchemeForPoint(jsObject: any): Promise<any> {
    let {buildDotNetTypeSchemeForPointGenerated} = await import('./typeSchemeForPoint.gb');
    return await buildDotNetTypeSchemeForPointGenerated(jsObject);
}
