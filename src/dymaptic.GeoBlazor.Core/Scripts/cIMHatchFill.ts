
export async function buildJsCIMHatchFill(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMHatchFillGenerated } = await import('./cIMHatchFill.gb');
    return await buildJsCIMHatchFillGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMHatchFill(jsObject: any): Promise<any> {
    let { buildDotNetCIMHatchFillGenerated } = await import('./cIMHatchFill.gb');
    return await buildDotNetCIMHatchFillGenerated(jsObject);
}
