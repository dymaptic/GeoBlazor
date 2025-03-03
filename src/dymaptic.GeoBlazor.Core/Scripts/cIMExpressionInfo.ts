
export async function buildJsCIMExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMExpressionInfoGenerated } = await import('./cIMExpressionInfo.gb');
    return await buildJsCIMExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetCIMExpressionInfoGenerated } = await import('./cIMExpressionInfo.gb');
    return await buildDotNetCIMExpressionInfoGenerated(jsObject);
}
