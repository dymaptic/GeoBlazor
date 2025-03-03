
export async function buildJsComboBoxInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsComboBoxInputGenerated } = await import('./comboBoxInput.gb');
    return await buildJsComboBoxInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetComboBoxInput(jsObject: any): Promise<any> {
    let { buildDotNetComboBoxInputGenerated } = await import('./comboBoxInput.gb');
    return await buildDotNetComboBoxInputGenerated(jsObject);
}
