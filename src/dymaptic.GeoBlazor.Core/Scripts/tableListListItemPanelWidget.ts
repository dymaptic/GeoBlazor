
export async function buildJsTableListListItemPanelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListListItemPanelWidgetGenerated } = await import('./tableListListItemPanelWidget.gb');
    return await buildJsTableListListItemPanelWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableListListItemPanelWidget(jsObject: any): Promise<any> {
    let { buildDotNetTableListListItemPanelWidgetGenerated } = await import('./tableListListItemPanelWidget.gb');
    return await buildDotNetTableListListItemPanelWidgetGenerated(jsObject);
}
