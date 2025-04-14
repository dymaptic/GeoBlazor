
export async function buildJsWidgets(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWidgetsGenerated } = await import('./widgets.gb');
    return await buildJsWidgetsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWidgets(jsObject: any): Promise<any> {
    let { buildDotNetWidgetsGenerated } = await import('./widgets.gb');
    return await buildDotNetWidgetsGenerated(jsObject);
}
