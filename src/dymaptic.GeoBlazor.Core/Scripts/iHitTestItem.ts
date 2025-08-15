
export async function buildJsIHitTestItem(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIHitTestItemGenerated } = await import('./iHitTestItem.gb');
    return await buildJsIHitTestItemGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIHitTestItem(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIHitTestItemGenerated } = await import('./iHitTestItem.gb');
    return await buildDotNetIHitTestItemGenerated(jsObject, viewId);
}
