
export async function buildJsSQLSourceLocation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSQLSourceLocationGenerated } = await import('./sQLSourceLocation.gb');
    return await buildJsSQLSourceLocationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSQLSourceLocation(jsObject: any): Promise<any> {
    let { buildDotNetSQLSourceLocationGenerated } = await import('./sQLSourceLocation.gb');
    return await buildDotNetSQLSourceLocationGenerated(jsObject);
}
