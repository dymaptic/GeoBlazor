
export async function buildJsPrimitiveOverrideValueExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrimitiveOverrideValueExpressionInfoGenerated } = await import('./primitiveOverrideValueExpressionInfo.gb');
    return await buildJsPrimitiveOverrideValueExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrimitiveOverrideValueExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrimitiveOverrideValueExpressionInfoGenerated } = await import('./primitiveOverrideValueExpressionInfo.gb');
    return await buildDotNetPrimitiveOverrideValueExpressionInfoGenerated(jsObject, layerId, viewId);
}
