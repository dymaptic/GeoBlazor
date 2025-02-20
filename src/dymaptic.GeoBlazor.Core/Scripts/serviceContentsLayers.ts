export async function buildJsServiceContentsLayers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsServiceContentsLayersGenerated} = await import('./serviceContentsLayers.gb');
    return await buildJsServiceContentsLayersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetServiceContentsLayers(jsObject: any): Promise<any> {
    let {buildDotNetServiceContentsLayersGenerated} = await import('./serviceContentsLayers.gb');
    return await buildDotNetServiceContentsLayersGenerated(jsObject);
}
