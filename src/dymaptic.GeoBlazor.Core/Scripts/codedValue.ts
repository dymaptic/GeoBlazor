
export async function buildJsCodedValue(dotNetObject: any): Promise<any> {
    let { buildJsCodedValueGenerated } = await import('./codedValue.gb');
    return await buildJsCodedValueGenerated(dotNetObject);
}     

export async function buildDotNetCodedValue(jsObject: any): Promise<any> {
    let { buildDotNetCodedValueGenerated } = await import('./codedValue.gb');
    return await buildDotNetCodedValueGenerated(jsObject);
}
