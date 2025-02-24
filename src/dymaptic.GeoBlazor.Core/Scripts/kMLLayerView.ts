export async function buildJsKMLLayerView(dotNetObject: any): Promise<any> {
    let {buildJsKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildJsKMLLayerViewGenerated(dotNetObject);
}

export async function buildDotNetKMLLayerView(jsObject: any): Promise<any> {
    let {buildDotNetKMLLayerViewGenerated} = await import('./kMLLayerView.gb');
    return await buildDotNetKMLLayerViewGenerated(jsObject);
}
