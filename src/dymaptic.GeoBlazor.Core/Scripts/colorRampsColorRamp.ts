
export async function buildJsColorRampsColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorRampsColorRampGenerated } = await import('./colorRampsColorRamp.gb');
    return await buildJsColorRampsColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorRampsColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetColorRampsColorRampGenerated } = await import('./colorRampsColorRamp.gb');
    return await buildDotNetColorRampsColorRampGenerated(jsObject);
}
