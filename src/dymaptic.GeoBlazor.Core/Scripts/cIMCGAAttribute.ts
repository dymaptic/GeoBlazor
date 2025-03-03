
export async function buildJsCIMCGAAttribute(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMCGAAttributeGenerated } = await import('./cIMCGAAttribute.gb');
    return await buildJsCIMCGAAttributeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMCGAAttribute(jsObject: any): Promise<any> {
    let { buildDotNetCIMCGAAttributeGenerated } = await import('./cIMCGAAttribute.gb');
    return await buildDotNetCIMCGAAttributeGenerated(jsObject);
}
