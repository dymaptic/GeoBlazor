
export async function buildJsImageAngleResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageAngleResultGenerated } = await import('./imageAngleResult.gb');
    return await buildJsImageAngleResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageAngleResult(jsObject: any): Promise<any> {
    let { buildDotNetImageAngleResultGenerated } = await import('./imageAngleResult.gb');
    return await buildDotNetImageAngleResultGenerated(jsObject);
}
