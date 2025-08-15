
export async function buildJsIImageryTileMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return await buildJsIImageryTileMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIImageryTileMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return await buildDotNetIImageryTileMixinGenerated(jsObject, viewId);
}
