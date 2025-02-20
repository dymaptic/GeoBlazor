export async function buildJsCatalogLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCatalogLayerViewGenerated} = await import('./catalogLayerView.gb');
    return await buildJsCatalogLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCatalogLayerView(jsObject: any): Promise<any> {
    let {buildDotNetCatalogLayerViewGenerated} = await import('./catalogLayerView.gb');
    return await buildDotNetCatalogLayerViewGenerated(jsObject);
}
