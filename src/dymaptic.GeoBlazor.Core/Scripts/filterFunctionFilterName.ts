
export async function buildJsFilterFunctionFilterName(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFilterFunctionFilterNameGenerated } = await import('./filterFunctionFilterName.gb');
    return await buildJsFilterFunctionFilterNameGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFilterFunctionFilterName(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFilterFunctionFilterNameGenerated } = await import('./filterFunctionFilterName.gb');
    return await buildDotNetFilterFunctionFilterNameGenerated(jsObject, viewId);
}
