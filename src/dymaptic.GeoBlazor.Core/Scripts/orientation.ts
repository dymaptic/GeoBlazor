
export async function buildJsOrientation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrientationGenerated } = await import('./orientation.gb');
    return await buildJsOrientationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrientation(jsObject: any): Promise<any> {
    let { buildDotNetOrientationGenerated } = await import('./orientation.gb');
    return await buildDotNetOrientationGenerated(jsObject);
}
