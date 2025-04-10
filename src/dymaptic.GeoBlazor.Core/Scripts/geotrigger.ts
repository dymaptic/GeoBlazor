
export async function buildJsGeotrigger(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeotriggerGenerated } = await import('./geotrigger.gb');
    return await buildJsGeotriggerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeotrigger(jsObject: any): Promise<any> {
    let { buildDotNetGeotriggerGenerated } = await import('./geotrigger.gb');
    return await buildDotNetGeotriggerGenerated(jsObject);
}
