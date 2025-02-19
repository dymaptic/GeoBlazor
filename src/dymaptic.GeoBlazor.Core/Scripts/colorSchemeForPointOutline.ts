
export async function buildJsColorSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForPointOutlineGenerated } = await import('./colorSchemeForPointOutline.gb');
    return await buildJsColorSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSchemeForPointOutline(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForPointOutlineGenerated } = await import('./colorSchemeForPointOutline.gb');
    return await buildDotNetColorSchemeForPointOutlineGenerated(jsObject);
}
