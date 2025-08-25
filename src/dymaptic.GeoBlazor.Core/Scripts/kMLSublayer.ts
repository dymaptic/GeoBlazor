
export async function buildJsKMLSublayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildJsKMLSublayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetKMLSublayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildDotNetKMLSublayerGenerated(jsObject, viewId);
}
