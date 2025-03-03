
export async function buildJsConfigWorkers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigWorkersGenerated } = await import('./configWorkers.gb');
    return await buildJsConfigWorkersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfigWorkers(jsObject: any): Promise<any> {
    let { buildDotNetConfigWorkersGenerated } = await import('./configWorkers.gb');
    return await buildDotNetConfigWorkersGenerated(jsObject);
}
