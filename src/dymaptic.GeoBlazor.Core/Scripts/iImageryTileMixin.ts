
export async function buildJsIImageryTileMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return await buildJsIImageryTileMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIImageryTileMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return await buildDotNetIImageryTileMixinGenerated(jsObject, viewId);
}
