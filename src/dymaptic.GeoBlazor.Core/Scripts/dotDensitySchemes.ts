export async function buildJsDotDensitySchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensitySchemesGenerated } = await import('./dotDensitySchemes.gb');
    return await buildJsDotDensitySchemesGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDotDensitySchemes(jsObject: any): Promise<any> {
    let { buildDotNetDotDensitySchemesGenerated } = await import('./dotDensitySchemes.gb');
    return await buildDotNetDotDensitySchemesGenerated(jsObject);
}
