
export async function buildJsDotDensitySchemeOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensitySchemeOutlineGenerated } = await import('./dotDensitySchemeOutline.gb');
    return await buildJsDotDensitySchemeOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensitySchemeOutline(jsObject: any): Promise<any> {
    let { buildDotNetDotDensitySchemeOutlineGenerated } = await import('./dotDensitySchemeOutline.gb');
    return await buildDotNetDotDensitySchemeOutlineGenerated(jsObject);
}
