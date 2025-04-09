
export async function buildJsProjectOperatorExecuteManyOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProjectOperatorExecuteManyOptionsGenerated } = await import('./projectOperatorExecuteManyOptions.gb');
    return await buildJsProjectOperatorExecuteManyOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProjectOperatorExecuteManyOptions(jsObject: any): Promise<any> {
    let { buildDotNetProjectOperatorExecuteManyOptionsGenerated } = await import('./projectOperatorExecuteManyOptions.gb');
    return await buildDotNetProjectOperatorExecuteManyOptionsGenerated(jsObject);
}
