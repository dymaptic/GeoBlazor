
export async function buildJsIMeshUtilsSource(dotNetObject: any): Promise<any> {
    let { buildJsIMeshUtilsSourceGenerated } = await import('./iMeshUtilsSource.gb');
    return await buildJsIMeshUtilsSourceGenerated(dotNetObject);
}     

export async function buildDotNetIMeshUtilsSource(jsObject: any): Promise<any> {
    let { buildDotNetIMeshUtilsSourceGenerated } = await import('./iMeshUtilsSource.gb');
    return await buildDotNetIMeshUtilsSourceGenerated(jsObject);
}
