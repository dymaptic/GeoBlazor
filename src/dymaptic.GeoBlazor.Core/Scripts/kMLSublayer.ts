
export async function buildJsKMLSublayer(dotNetObject: any): Promise<any> {
    let { buildJsKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildJsKMLSublayerGenerated(dotNetObject);
}     

export async function buildDotNetKMLSublayer(jsObject: any): Promise<any> {
    let { buildDotNetKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildDotNetKMLSublayerGenerated(jsObject);
}
