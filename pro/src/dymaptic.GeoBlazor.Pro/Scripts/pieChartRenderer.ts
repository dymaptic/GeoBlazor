
export async function buildJsPieChartRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartRendererGenerated } = await import('./pieChartRenderer.gb');
    let jsObject = await buildJsPieChartRendererGenerated(dotNetObject, layerId, viewId);
    
    if (jsObject.attributes === null) {
        jsObject.attributes = [];
    }
    
    return jsObject;
}     

export async function buildDotNetPieChartRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPieChartRendererGenerated } = await import('./pieChartRenderer.gb');
    return await buildDotNetPieChartRendererGenerated(jsObject, viewId);
}
