
export async function buildJsCompressedTextureData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCompressedTextureDataGenerated } = await import('./compressedTextureData.gb');
    return await buildJsCompressedTextureDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCompressedTextureData(jsObject: any): Promise<any> {
    let { buildDotNetCompressedTextureDataGenerated } = await import('./compressedTextureData.gb');
    return await buildDotNetCompressedTextureDataGenerated(jsObject);
}
