
export async function buildJsCIMGradientFill(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGradientFillGenerated } = await import('./cIMGradientFill.gb');
    return await buildJsCIMGradientFillGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGradientFill(jsObject: any): Promise<any> {
    let { buildDotNetCIMGradientFillGenerated } = await import('./cIMGradientFill.gb');
    return await buildDotNetCIMGradientFillGenerated(jsObject);
}
