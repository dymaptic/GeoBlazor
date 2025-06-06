
export async function buildJsITablesMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsITablesMixinGenerated } = await import('./iTablesMixin.gb');
    return await buildJsITablesMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetITablesMixin(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetITablesMixinGenerated } = await import('./iTablesMixin.gb');
    return await buildDotNetITablesMixinGenerated(jsObject, layerId, viewId);
}
