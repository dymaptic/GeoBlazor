export async function buildJsSizeSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeSchemeForPointGenerated} = await import('./sizeSchemeForPoint.gb');
    return await buildJsSizeSchemeForPointGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeSchemeForPoint(jsObject: any): Promise<any> {
    let {buildDotNetSizeSchemeForPointGenerated} = await import('./sizeSchemeForPoint.gb');
    return await buildDotNetSizeSchemeForPointGenerated(jsObject);
}
