
export async function buildJsOrientation(dotNetObject: any): Promise<any> {
    let { buildJsOrientationGenerated } = await import('./orientation.gb');
    return await buildJsOrientationGenerated(dotNetObject);
}     

export async function buildDotNetOrientation(jsObject: any): Promise<any> {
    let { buildDotNetOrientationGenerated } = await import('./orientation.gb');
    return await buildDotNetOrientationGenerated(jsObject);
}
