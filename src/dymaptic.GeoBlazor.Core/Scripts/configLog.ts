
export async function buildJsConfigLog(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigLogGenerated } = await import('./configLog.gb');
    return await buildJsConfigLogGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfigLog(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConfigLogGenerated } = await import('./configLog.gb');
    return await buildDotNetConfigLogGenerated(jsObject, layerId, viewId);
}
