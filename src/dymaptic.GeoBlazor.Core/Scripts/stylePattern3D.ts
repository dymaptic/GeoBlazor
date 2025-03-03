
export async function buildJsStylePattern3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStylePattern3DGenerated } = await import('./stylePattern3D.gb');
    return await buildJsStylePattern3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStylePattern3D(jsObject: any): Promise<any> {
    let { buildDotNetStylePattern3DGenerated } = await import('./stylePattern3D.gb');
    return await buildDotNetStylePattern3DGenerated(jsObject);
}
