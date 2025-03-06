
export async function buildJsArealUnit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArealUnitGenerated } = await import('./arealUnit.gb');
    return await buildJsArealUnitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArealUnit(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetArealUnitGenerated } = await import('./arealUnit.gb');
    return await buildDotNetArealUnitGenerated(jsObject, layerId, viewId);
}
