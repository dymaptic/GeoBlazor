
export async function buildJsWebDocument2DUpdateFromOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebDocument2DUpdateFromOptionsGenerated } = await import('./webDocument2DUpdateFromOptions.gb');
    return await buildJsWebDocument2DUpdateFromOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebDocument2DUpdateFromOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebDocument2DUpdateFromOptionsGenerated } = await import('./webDocument2DUpdateFromOptions.gb');
    return await buildDotNetWebDocument2DUpdateFromOptionsGenerated(jsObject, viewId);
}
