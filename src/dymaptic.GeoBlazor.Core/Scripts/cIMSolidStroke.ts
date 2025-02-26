
export async function buildJsCIMSolidStroke(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSolidStrokeGenerated } = await import('./cIMSolidStroke.gb');
    return await buildJsCIMSolidStrokeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSolidStroke(jsObject: any): Promise<any> {
    let { buildDotNetCIMSolidStrokeGenerated } = await import('./cIMSolidStroke.gb');
    return await buildDotNetCIMSolidStrokeGenerated(jsObject);
}
