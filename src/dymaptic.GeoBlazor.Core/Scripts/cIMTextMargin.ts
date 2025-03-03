
export async function buildJsCIMTextMargin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMTextMarginGenerated } = await import('./cIMTextMargin.gb');
    return await buildJsCIMTextMarginGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMTextMargin(jsObject: any): Promise<any> {
    let { buildDotNetCIMTextMarginGenerated } = await import('./cIMTextMargin.gb');
    return await buildDotNetCIMTextMarginGenerated(jsObject);
}
