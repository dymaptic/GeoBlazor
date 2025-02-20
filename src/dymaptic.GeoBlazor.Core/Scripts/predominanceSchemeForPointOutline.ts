export async function buildJsPredominanceSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceSchemeForPointOutlineGenerated} = await import('./predominanceSchemeForPointOutline.gb');
    return await buildJsPredominanceSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceSchemeForPointOutline(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceSchemeForPointOutlineGenerated} = await import('./predominanceSchemeForPointOutline.gb');
    return await buildDotNetPredominanceSchemeForPointOutlineGenerated(jsObject);
}
