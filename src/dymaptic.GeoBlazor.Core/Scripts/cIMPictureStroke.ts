
export async function buildJsCIMPictureStroke(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPictureStrokeGenerated } = await import('./cIMPictureStroke.gb');
    return await buildJsCIMPictureStrokeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPictureStroke(jsObject: any): Promise<any> {
    let { buildDotNetCIMPictureStrokeGenerated } = await import('./cIMPictureStroke.gb');
    return await buildDotNetCIMPictureStrokeGenerated(jsObject);
}
