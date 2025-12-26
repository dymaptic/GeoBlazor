
export async function buildJsDateTimeFieldFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateTimeFieldFormatGenerated } = await import('./dateTimeFieldFormat.gb');
    return await buildJsDateTimeFieldFormatGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateTimeFieldFormat(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDateTimeFieldFormatGenerated } = await import('./dateTimeFieldFormat.gb');
    return await buildDotNetDateTimeFieldFormatGenerated(jsObject, viewId);
}
