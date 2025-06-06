export async function buildJsKMLLayerViewMapImage(dotNetObject: any): Promise<any> {
    let {buildJsKMLLayerViewMapImageGenerated} = await import('./kMLLayerViewMapImage.gb');
    return await buildJsKMLLayerViewMapImageGenerated(dotNetObject);
}

export async function buildDotNetKMLLayerViewMapImage(jsObject: any): Promise<any> {
    let {buildDotNetKMLLayerViewMapImageGenerated} = await import('./kMLLayerViewMapImage.gb');
    return await buildDotNetKMLLayerViewMapImageGenerated(jsObject);
}
