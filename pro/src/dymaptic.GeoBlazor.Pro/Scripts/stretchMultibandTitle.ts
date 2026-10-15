
export async function buildJsStretchMultibandTitle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStretchMultibandTitleGenerated } = await import('./stretchMultibandTitle.gb');
    return await buildJsStretchMultibandTitleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStretchMultibandTitle(jsObject: any): Promise<any> {
    let { buildDotNetStretchMultibandTitleGenerated } = await import('./stretchMultibandTitle.gb');
    return await buildDotNetStretchMultibandTitleGenerated(jsObject);
}
