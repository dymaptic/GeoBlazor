
export async function buildJsIInputBaseLayers(dotNetObject: any): Promise<any> {
    let { buildJsIInputBaseLayersGenerated } = await import('./iInputBaseLayers.gb');
    return await buildJsIInputBaseLayersGenerated(dotNetObject);
}     

export async function buildDotNetIInputBaseLayers(jsObject: any): Promise<any> {
    let { buildDotNetIInputBaseLayersGenerated } = await import('./iInputBaseLayers.gb');
    return await buildDotNetIInputBaseLayersGenerated(jsObject);
}
