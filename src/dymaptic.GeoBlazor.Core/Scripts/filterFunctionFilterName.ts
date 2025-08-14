
export async function buildJsFilterFunctionFilterName(dotNetObject: any): Promise<any> {
    let { buildJsFilterFunctionFilterNameGenerated } = await import('./filterFunctionFilterName.gb');
    return await buildJsFilterFunctionFilterNameGenerated(dotNetObject);
}     

export async function buildDotNetFilterFunctionFilterName(jsObject: any): Promise<any> {
    let { buildDotNetFilterFunctionFilterNameGenerated } = await import('./filterFunctionFilterName.gb');
    return await buildDotNetFilterFunctionFilterNameGenerated(jsObject);
}
