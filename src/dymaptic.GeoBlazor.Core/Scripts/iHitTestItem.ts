
export async function buildJsIHitTestItem(dotNetObject: any): Promise<any> {
    let { buildJsIHitTestItemGenerated } = await import('./iHitTestItem.gb');
    return await buildJsIHitTestItemGenerated(dotNetObject);
}     

export async function buildDotNetIHitTestItem(jsObject: any): Promise<any> {
    let { buildDotNetIHitTestItemGenerated } = await import('./iHitTestItem.gb');
    return await buildDotNetIHitTestItemGenerated(jsObject);
}
