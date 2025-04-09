
export async function buildJsCIMMultipartColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMultipartColorRampGenerated } = await import('./cIMMultipartColorRamp.gb');
    return await buildJsCIMMultipartColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMultipartColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetCIMMultipartColorRampGenerated } = await import('./cIMMultipartColorRamp.gb');
    return await buildDotNetCIMMultipartColorRampGenerated(jsObject);
}
