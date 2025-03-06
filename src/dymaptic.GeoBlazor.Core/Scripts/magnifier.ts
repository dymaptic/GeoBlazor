
export async function buildJsMagnifier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMagnifierGenerated } = await import('./magnifier.gb');
    return await buildJsMagnifierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMagnifier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMagnifierGenerated } = await import('./magnifier.gb');
    return await buildDotNetMagnifierGenerated(jsObject, layerId, viewId);
}
