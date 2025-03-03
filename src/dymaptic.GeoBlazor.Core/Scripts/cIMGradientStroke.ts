
export async function buildJsCIMGradientStroke(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGradientStrokeGenerated } = await import('./cIMGradientStroke.gb');
    return await buildJsCIMGradientStrokeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGradientStroke(jsObject: any): Promise<any> {
    let { buildDotNetCIMGradientStrokeGenerated } = await import('./cIMGradientStroke.gb');
    return await buildDotNetCIMGradientStrokeGenerated(jsObject);
}
