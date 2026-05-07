
export async function buildJsLOD(dotNetObject: any): Promise<any> {
    let { buildJsLODGenerated } = await import('./lOD.gb');
    return await buildJsLODGenerated(dotNetObject);
}     

export async function buildDotNetLOD(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLODGenerated } = await import('./lOD.gb');
    return await buildDotNetLODGenerated(jsObject, viewId);
}
