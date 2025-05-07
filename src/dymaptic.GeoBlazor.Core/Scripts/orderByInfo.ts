
export async function buildJsOrderByInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrderByInfoGenerated } = await import('./orderByInfo.gb');
    return await buildJsOrderByInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrderByInfo(jsObject: any): Promise<any> {
    let { buildDotNetOrderByInfoGenerated } = await import('./orderByInfo.gb');
    return await buildDotNetOrderByInfoGenerated(jsObject);
}
