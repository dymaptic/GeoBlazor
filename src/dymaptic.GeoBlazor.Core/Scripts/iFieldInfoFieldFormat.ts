
export async function buildJsIFieldInfoFieldFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFieldInfoFieldFormatGenerated } = await import('./iFieldInfoFieldFormat.gb');
    return await buildJsIFieldInfoFieldFormatGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFieldInfoFieldFormat(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFieldInfoFieldFormatGenerated } = await import('./iFieldInfoFieldFormat.gb');
    return await buildDotNetIFieldInfoFieldFormatGenerated(jsObject, viewId);
}
