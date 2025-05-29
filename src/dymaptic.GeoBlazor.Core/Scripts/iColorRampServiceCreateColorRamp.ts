
export async function buildJsIColorRampServiceCreateColorRamp(dotNetObject: any): Promise<any> {
    let { buildJsIColorRampServiceCreateColorRampGenerated } = await import('./iColorRampServiceCreateColorRamp.gb');
    return await buildJsIColorRampServiceCreateColorRampGenerated(dotNetObject);
}     

export async function buildDotNetIColorRampServiceCreateColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetIColorRampServiceCreateColorRampGenerated } = await import('./iColorRampServiceCreateColorRamp.gb');
    return await buildDotNetIColorRampServiceCreateColorRampGenerated(jsObject);
}
