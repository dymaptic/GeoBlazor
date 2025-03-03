
export async function buildJsPrimitiveOverride(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrimitiveOverrideGenerated } = await import('./primitiveOverride.gb');
    return await buildJsPrimitiveOverrideGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrimitiveOverride(jsObject: any): Promise<any> {
    let { buildDotNetPrimitiveOverrideGenerated } = await import('./primitiveOverride.gb');
    return await buildDotNetPrimitiveOverrideGenerated(jsObject);
}
