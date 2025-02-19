
export async function buildJsCIMMarkerGraphic(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerGraphicGenerated } = await import('./cIMMarkerGraphic.gb');
    return await buildJsCIMMarkerGraphicGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerGraphic(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerGraphicGenerated } = await import('./cIMMarkerGraphic.gb');
    return await buildDotNetCIMMarkerGraphicGenerated(jsObject);
}
