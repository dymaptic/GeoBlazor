
export async function buildJsLOD(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLODGenerated } = await import('./lOD.gb');
    return await buildJsLODGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLOD(jsObject: any): Promise<any> {
    let { buildDotNetLODGenerated } = await import('./lOD.gb');
    return await buildDotNetLODGenerated(jsObject);
}
