
export async function buildJsLineStylePattern3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineStylePattern3DGenerated } = await import('./lineStylePattern3D.gb');
    return await buildJsLineStylePattern3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineStylePattern3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLineStylePattern3DGenerated } = await import('./lineStylePattern3D.gb');
    return await buildDotNetLineStylePattern3DGenerated(jsObject, layerId, viewId);
}
