
export function buildJsITimeUtilsDocument(dotNetObject: any): any {
    let { buildJsITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return buildJsITimeUtilsDocumentGenerated(dotNetObject);
}     

export function buildDotNetITimeUtilsDocument(jsObject: any): any {
    let { buildDotNetITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return buildDotNetITimeUtilsDocumentGenerated(jsObject);
}
