export async function buildJsSupportColorRampsColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSupportColorRampsColorRampGenerated} = await import('./supportColorRampsColorRamp.gb');
    return await buildJsSupportColorRampsColorRampGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSupportColorRampsColorRamp(jsObject: any): Promise<any> {
    let {buildDotNetSupportColorRampsColorRampGenerated} = await import('./supportColorRampsColorRamp.gb');
    return await buildDotNetSupportColorRampsColorRampGenerated(jsObject);
}
