export async function buildJsGfxUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGfxUtilsGenerated} = await import('./gfxUtils.gb');
    return await buildJsGfxUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGfxUtils(jsObject: any): Promise<any> {
    let {buildDotNetGfxUtilsGenerated} = await import('./gfxUtils.gb');
    return await buildDotNetGfxUtilsGenerated(jsObject);
}
