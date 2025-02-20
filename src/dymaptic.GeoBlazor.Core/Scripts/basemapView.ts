export async function buildJsBasemapView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapViewGenerated} = await import('./basemapView.gb');
    return await buildJsBasemapViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemapView(jsObject: any): Promise<any> {
    let {buildDotNetBasemapViewGenerated} = await import('./basemapView.gb');
    return await buildDotNetBasemapViewGenerated(jsObject);
}
