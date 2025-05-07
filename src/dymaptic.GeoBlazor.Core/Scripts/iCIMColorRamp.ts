
export async function buildJsICIMColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICIMColorRampGenerated } = await import('./iCIMColorRamp.gb');
    return await buildJsICIMColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICIMColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetICIMColorRampGenerated } = await import('./iCIMColorRamp.gb');
    return await buildDotNetICIMColorRampGenerated(jsObject);
}
