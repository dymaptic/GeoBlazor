
export async function buildJsComboboxItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsComboboxItemGenerated } = await import('./comboboxItem.gb');
    return await buildJsComboboxItemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetComboboxItem(jsObject: any): Promise<any> {
    let { buildDotNetComboboxItemGenerated } = await import('./comboboxItem.gb');
    return await buildDotNetComboboxItemGenerated(jsObject);
}
