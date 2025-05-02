
export async function buildJsIRasterPresetRendererMixin(dotNetObject: any): Promise<any> {
    let { buildJsIRasterPresetRendererMixinGenerated } = await import('./iRasterPresetRendererMixin.gb');
    return await buildJsIRasterPresetRendererMixinGenerated(dotNetObject);
}     

export async function buildDotNetIRasterPresetRendererMixin(jsObject: any): Promise<any> {
    let { buildDotNetIRasterPresetRendererMixinGenerated } = await import('./iRasterPresetRendererMixin.gb');
    return await buildDotNetIRasterPresetRendererMixinGenerated(jsObject);
}
