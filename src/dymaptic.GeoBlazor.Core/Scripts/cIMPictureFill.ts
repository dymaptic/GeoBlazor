
export async function buildJsCIMPictureFill(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPictureFillGenerated } = await import('./cIMPictureFill.gb');
    return await buildJsCIMPictureFillGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPictureFill(jsObject: any): Promise<any> {
    let { buildDotNetCIMPictureFillGenerated } = await import('./cIMPictureFill.gb');
    return await buildDotNetCIMPictureFillGenerated(jsObject);
}
