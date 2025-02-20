export async function buildJsColorSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSchemeForPointGenerated} = await import('./colorSchemeForPoint.gb');
    return await buildJsColorSchemeForPointGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSchemeForPoint(jsObject: any): Promise<any> {
    let {buildDotNetColorSchemeForPointGenerated} = await import('./colorSchemeForPoint.gb');
    return await buildDotNetColorSchemeForPointGenerated(jsObject);
}
