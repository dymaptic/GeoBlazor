// override generated code in this file


export async function buildJsLayerFromPortalItemParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerFromPortalItemParamsGenerated} = await import('./layerFromPortalItemParams.gb');
    return await buildJsLayerFromPortalItemParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerFromPortalItemParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLayerFromPortalItemParamsGenerated} = await import('./layerFromPortalItemParams.gb');
    return await buildDotNetLayerFromPortalItemParamsGenerated(jsObject, layerId, viewId);
}
