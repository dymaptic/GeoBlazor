// override generated code in this file

export async function buildJsLayerSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerSearchSourceGenerated} = await import('./layerSearchSource.gb');
    return await buildJsLayerSearchSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerSearchSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLayerSearchSourceGenerated} = await import('./layerSearchSource.gb');
    return await buildDotNetLayerSearchSourceGenerated(jsObject, layerId, viewId);
}
