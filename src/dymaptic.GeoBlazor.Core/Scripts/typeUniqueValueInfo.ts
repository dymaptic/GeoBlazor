export async function buildJsTypeUniqueValueInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeUniqueValueInfoGenerated} = await import('./typeUniqueValueInfo.gb');
    return await buildJsTypeUniqueValueInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeUniqueValueInfo(jsObject: any): Promise<any> {
    let {buildDotNetTypeUniqueValueInfoGenerated} = await import('./typeUniqueValueInfo.gb');
    return await buildDotNetTypeUniqueValueInfoGenerated(jsObject);
}
