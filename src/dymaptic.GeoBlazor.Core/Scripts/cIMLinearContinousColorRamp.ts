
export async function buildJsCIMLinearContinousColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMLinearContinousColorRampGenerated } = await import('./cIMLinearContinousColorRamp.gb');
    return await buildJsCIMLinearContinousColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMLinearContinousColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetCIMLinearContinousColorRampGenerated } = await import('./cIMLinearContinousColorRamp.gb');
    return await buildDotNetCIMLinearContinousColorRampGenerated(jsObject);
}
