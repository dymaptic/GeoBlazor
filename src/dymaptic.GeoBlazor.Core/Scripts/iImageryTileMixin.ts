
export async function buildJsIImageryTileMixin(dotNetObject: any): Promise<any> {
    let { buildJsIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return buildJsIImageryTileMixinGenerated(dotNetObject);
}     

export async function buildDotNetIImageryTileMixin(jsObject: any): Promise<any> {
    let { buildDotNetIImageryTileMixinGenerated } = await import('./iImageryTileMixin.gb');
    return await buildDotNetIImageryTileMixinGenerated(jsObject);
}
