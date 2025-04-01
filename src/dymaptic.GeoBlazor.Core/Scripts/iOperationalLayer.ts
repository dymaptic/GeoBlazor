
export async function buildJsIOperationalLayer(dotNetObject: any): Promise<any> {
    let { buildJsIOperationalLayerGenerated } = await import('./iOperationalLayer.gb');
    return await buildJsIOperationalLayerGenerated(dotNetObject);
}     

export async function buildDotNetIOperationalLayer(jsObject: any): Promise<any> {
    let { buildDotNetIOperationalLayerGenerated } = await import('./iOperationalLayer.gb');
    return await buildDotNetIOperationalLayerGenerated(jsObject);
}
