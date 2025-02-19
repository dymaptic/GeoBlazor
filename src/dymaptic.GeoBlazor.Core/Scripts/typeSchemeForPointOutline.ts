
export async function buildJsTypeSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeSchemeForPointOutlineGenerated } = await import('./typeSchemeForPointOutline.gb');
    return await buildJsTypeSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeSchemeForPointOutline(jsObject: any): Promise<any> {
    let { buildDotNetTypeSchemeForPointOutlineGenerated } = await import('./typeSchemeForPointOutline.gb');
    return await buildDotNetTypeSchemeForPointOutlineGenerated(jsObject);
}
