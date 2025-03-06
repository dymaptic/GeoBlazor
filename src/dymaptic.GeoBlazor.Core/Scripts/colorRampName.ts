
export async function buildJsColorRampName(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorRampNameGenerated } = await import('./colorRampName.gb');
    return await buildJsColorRampNameGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorRampName(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColorRampNameGenerated } = await import('./colorRampName.gb');
    return await buildDotNetColorRampNameGenerated(jsObject, layerId, viewId);
}
