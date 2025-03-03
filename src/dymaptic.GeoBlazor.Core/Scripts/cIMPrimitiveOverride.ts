
export async function buildJsCIMPrimitiveOverride(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPrimitiveOverrideGenerated } = await import('./cIMPrimitiveOverride.gb');
    return await buildJsCIMPrimitiveOverrideGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPrimitiveOverride(jsObject: any): Promise<any> {
    let { buildDotNetCIMPrimitiveOverrideGenerated } = await import('./cIMPrimitiveOverride.gb');
    return await buildDotNetCIMPrimitiveOverrideGenerated(jsObject);
}
