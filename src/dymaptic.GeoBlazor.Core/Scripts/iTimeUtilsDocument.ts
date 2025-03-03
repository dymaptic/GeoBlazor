
export async function buildJsITimeUtilsDocument(dotNetObject: any): Promise<any> {
    let { buildJsITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return await buildJsITimeUtilsDocumentGenerated(dotNetObject);
}     

export async function buildDotNetITimeUtilsDocument(jsObject: any): Promise<any> {
    let { buildDotNetITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return await buildDotNetITimeUtilsDocumentGenerated(jsObject);
}
