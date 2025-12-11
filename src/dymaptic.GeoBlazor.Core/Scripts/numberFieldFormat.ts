
export async function buildJsNumberFieldFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNumberFieldFormatGenerated } = await import('./numberFieldFormat.gb');
    return await buildJsNumberFieldFormatGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNumberFieldFormat(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetNumberFieldFormatGenerated } = await import('./numberFieldFormat.gb');
    return await buildDotNetNumberFieldFormatGenerated(jsObject, viewId);
}
