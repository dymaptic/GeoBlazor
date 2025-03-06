export async function buildJsBasemapGalleryItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapGalleryItemGenerated} = await import('./basemapGalleryItem.gb');
    return await buildJsBasemapGalleryItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemapGalleryItem(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapGalleryItemGenerated} = await import('./basemapGalleryItem.gb');
    return await buildDotNetBasemapGalleryItemGenerated(jsObject, layerId, viewId);
}
