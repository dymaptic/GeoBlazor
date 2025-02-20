export async function buildJsKMLLayerViewMapImage(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKMLLayerViewMapImageGenerated} = await import('./kMLLayerViewMapImage.gb');
    return await buildJsKMLLayerViewMapImageGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKMLLayerViewMapImage(jsObject: any): Promise<any> {
    let {buildDotNetKMLLayerViewMapImageGenerated} = await import('./kMLLayerViewMapImage.gb');
    return await buildDotNetKMLLayerViewMapImageGenerated(jsObject);
}
