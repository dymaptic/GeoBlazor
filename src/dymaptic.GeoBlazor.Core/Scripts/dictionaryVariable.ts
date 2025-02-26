
export async function buildJsDictionaryVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDictionaryVariableGenerated } = await import('./dictionaryVariable.gb');
    return await buildJsDictionaryVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDictionaryVariable(jsObject: any): Promise<any> {
    let { buildDotNetDictionaryVariableGenerated } = await import('./dictionaryVariable.gb');
    return await buildDotNetDictionaryVariableGenerated(jsObject);
}
