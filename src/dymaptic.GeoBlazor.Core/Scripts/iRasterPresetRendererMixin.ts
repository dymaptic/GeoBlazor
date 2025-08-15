
export async function buildJsIRasterPresetRendererMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIRasterPresetRendererMixinGenerated } = await import('./iRasterPresetRendererMixin.gb');
    return await buildJsIRasterPresetRendererMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIRasterPresetRendererMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIRasterPresetRendererMixinGenerated } = await import('./iRasterPresetRendererMixin.gb');
    return await buildDotNetIRasterPresetRendererMixinGenerated(jsObject, viewId);
}
