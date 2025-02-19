
export async function buildJsDotDensityScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensitySchemeGenerated } = await import('./dotDensityScheme.gb');
    return await buildJsDotDensitySchemeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityScheme(jsObject: any): Promise<any> {
    let { buildDotNetDotDensitySchemeGenerated } = await import('./dotDensityScheme.gb');
    return await buildDotNetDotDensitySchemeGenerated(jsObject);
}
