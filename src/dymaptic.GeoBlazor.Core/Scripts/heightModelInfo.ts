
export async function buildJsHeightModelInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeightModelInfoGenerated } = await import('./heightModelInfo.gb');
    return await buildJsHeightModelInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeightModelInfo(jsObject: any): Promise<any> {
    let { buildDotNetHeightModelInfoGenerated } = await import('./heightModelInfo.gb');
    return await buildDotNetHeightModelInfoGenerated(jsObject);
}
