
export async function buildJsUnits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnitsGenerated } = await import('./units.gb');
    return await buildJsUnitsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnits(jsObject: any): Promise<any> {
    let { buildDotNetUnitsGenerated } = await import('./units.gb');
    return await buildDotNetUnitsGenerated(jsObject);
}
