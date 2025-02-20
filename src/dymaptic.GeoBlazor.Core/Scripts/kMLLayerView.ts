export async function buildJsKMLLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildJsKMLLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKMLLayerView(jsObject: any): Promise<any> {
    let {buildDotNetKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildDotNetKMLLayerViewGenerated(jsObject);
}
