
export async function buildJsIMeshUtilsSource(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIMeshUtilsSourceGenerated } = await import('./iMeshUtilsSource.gb');
    return await buildJsIMeshUtilsSourceGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIMeshUtilsSource(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIMeshUtilsSourceGenerated } = await import('./iMeshUtilsSource.gb');
    return await buildDotNetIMeshUtilsSourceGenerated(jsObject, viewId);
}
