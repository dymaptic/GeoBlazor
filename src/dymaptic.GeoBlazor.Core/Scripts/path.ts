
export async function buildJsPath(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPathGenerated } = await import('./path.gb');
    return await buildJsPathGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPath(jsObject: any): Promise<any> {
    let { buildDotNetPathGenerated } = await import('./path.gb');
    return await buildDotNetPathGenerated(jsObject);
}
