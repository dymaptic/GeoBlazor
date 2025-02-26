
export async function buildJsSearchSource(dotNetObject: any): Promise<any> {
    let { buildJsSearchSourceGenerated } = await import('./searchSource.gb');
    return await buildJsSearchSourceGenerated(dotNetObject);
}     

export async function buildDotNetSearchSource(jsObject: any): Promise<any> {
    let { buildDotNetSearchSourceGenerated } = await import('./searchSource.gb');
    return await buildDotNetSearchSourceGenerated(jsObject);
}
