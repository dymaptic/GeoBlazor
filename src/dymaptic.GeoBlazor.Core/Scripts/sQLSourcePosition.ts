
export async function buildJsSQLSourcePosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSQLSourcePositionGenerated } = await import('./sQLSourcePosition.gb');
    return await buildJsSQLSourcePositionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSQLSourcePosition(jsObject: any): Promise<any> {
    let { buildDotNetSQLSourcePositionGenerated } = await import('./sQLSourcePosition.gb');
    return await buildDotNetSQLSourcePositionGenerated(jsObject);
}
