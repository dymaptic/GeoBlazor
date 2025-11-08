export async function buildJsWFSLayerInfo(dotNetObject: any): Promise<any> {
    let {buildJsWFSLayerInfoGenerated} = await import('./wFSLayerInfo.gb');
    return await buildJsWFSLayerInfoGenerated(dotNetObject);
}

export async function buildDotNetWFSLayerInfo(jsObject: any): Promise<any> {
    let {buildDotNetWFSLayerInfoGenerated} = await import('./wFSLayerInfo.gb');
    return await buildDotNetWFSLayerInfoGenerated(jsObject);
}
