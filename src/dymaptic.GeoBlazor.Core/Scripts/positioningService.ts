
export async function buildJsPositioningService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPositioningServiceGenerated } = await import('./positioningService.gb');
    return await buildJsPositioningServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPositioningService(jsObject: any): Promise<any> {
    let { buildDotNetPositioningServiceGenerated } = await import('./positioningService.gb');
    return await buildDotNetPositioningServiceGenerated(jsObject);
}
