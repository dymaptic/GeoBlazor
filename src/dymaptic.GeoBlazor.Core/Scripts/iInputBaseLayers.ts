
export async function buildJsIInputBaseLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIInputBaseLayersGenerated } = await import('./iInputBaseLayers.gb');
    return await buildJsIInputBaseLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIInputBaseLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIInputBaseLayersGenerated } = await import('./iInputBaseLayers.gb');
    return await buildDotNetIInputBaseLayersGenerated(jsObject, viewId);
}
