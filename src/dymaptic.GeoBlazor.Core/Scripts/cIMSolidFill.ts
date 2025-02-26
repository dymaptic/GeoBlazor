
export async function buildJsCIMSolidFill(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSolidFillGenerated } = await import('./cIMSolidFill.gb');
    return await buildJsCIMSolidFillGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSolidFill(jsObject: any): Promise<any> {
    let { buildDotNetCIMSolidFillGenerated } = await import('./cIMSolidFill.gb');
    return await buildDotNetCIMSolidFillGenerated(jsObject);
}
