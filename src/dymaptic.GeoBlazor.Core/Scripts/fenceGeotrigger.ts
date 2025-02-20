export async function buildJsFenceGeotrigger(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFenceGeotriggerGenerated} = await import('./fenceGeotrigger.gb');
    return await buildJsFenceGeotriggerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFenceGeotrigger(jsObject: any): Promise<any> {
    let {buildDotNetFenceGeotriggerGenerated} = await import('./fenceGeotrigger.gb');
    return await buildDotNetFenceGeotriggerGenerated(jsObject);
}
