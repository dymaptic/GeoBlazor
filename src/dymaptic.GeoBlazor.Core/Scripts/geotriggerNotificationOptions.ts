
export async function buildJsGeotriggerNotificationOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeotriggerNotificationOptionsGenerated } = await import('./geotriggerNotificationOptions.gb');
    return await buildJsGeotriggerNotificationOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeotriggerNotificationOptions(jsObject: any): Promise<any> {
    let { buildDotNetGeotriggerNotificationOptionsGenerated } = await import('./geotriggerNotificationOptions.gb');
    return await buildDotNetGeotriggerNotificationOptionsGenerated(jsObject);
}
