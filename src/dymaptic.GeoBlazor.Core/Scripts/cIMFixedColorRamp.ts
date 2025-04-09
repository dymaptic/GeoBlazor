
export async function buildJsCIMFixedColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMFixedColorRampGenerated } = await import('./cIMFixedColorRamp.gb');
    return await buildJsCIMFixedColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMFixedColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetCIMFixedColorRampGenerated } = await import('./cIMFixedColorRamp.gb');
    return await buildDotNetCIMFixedColorRampGenerated(jsObject);
}
