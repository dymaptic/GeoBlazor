
export async function buildJsSQLSyntaxError(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSQLSyntaxErrorGenerated } = await import('./sQLSyntaxError.gb');
    return await buildJsSQLSyntaxErrorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSQLSyntaxError(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSQLSyntaxErrorGenerated } = await import('./sQLSyntaxError.gb');
    return await buildDotNetSQLSyntaxErrorGenerated(jsObject, viewId);
}
