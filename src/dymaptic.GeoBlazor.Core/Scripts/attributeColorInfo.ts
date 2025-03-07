
export async function buildJsAttributeColorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeColorInfoGenerated } = await import('./attributeColorInfo.gb');
    return await buildJsAttributeColorInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeColorInfo(jsObject: any): Promise<any> {
    let { buildDotNetAttributeColorInfoGenerated } = await import('./attributeColorInfo.gb');
    return await buildDotNetAttributeColorInfoGenerated(jsObject);
}
