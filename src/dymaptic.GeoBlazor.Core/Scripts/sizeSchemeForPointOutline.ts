
export async function buildJsSizeSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSchemeForPointOutlineGenerated } = await import('./sizeSchemeForPointOutline.gb');
    return await buildJsSizeSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSchemeForPointOutline(jsObject: any): Promise<any> {
    let { buildDotNetSizeSchemeForPointOutlineGenerated } = await import('./sizeSchemeForPointOutline.gb');
    return await buildDotNetSizeSchemeForPointOutlineGenerated(jsObject);
}
