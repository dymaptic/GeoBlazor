
export async function buildJsOrientation(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsOrientationGenerated } = await import('./orientation.gb');
    return await buildJsOrientationGenerated(dotNetObject, viewId);
}     

export async function buildDotNetOrientation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOrientationGenerated } = await import('./orientation.gb');
    return await buildDotNetOrientationGenerated(jsObject, viewId);
}
