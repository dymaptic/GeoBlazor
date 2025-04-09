
export async function buildJsProjectOperatorExecuteOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProjectOperatorExecuteOptionsGenerated } = await import('./projectOperatorExecuteOptions.gb');
    return await buildJsProjectOperatorExecuteOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProjectOperatorExecuteOptions(jsObject: any): Promise<any> {
    let { buildDotNetProjectOperatorExecuteOptionsGenerated } = await import('./projectOperatorExecuteOptions.gb');
    return await buildDotNetProjectOperatorExecuteOptionsGenerated(jsObject);
}
