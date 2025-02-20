export async function buildJsLabel(dotNetObject: any): Promise<any> {
    let {buildJsLabelGenerated} = await import('./label.gb');
    return await buildJsLabelGenerated(dotNetObject);
}

export async function buildDotNetLabel(jsObject: any): Promise<any> {
    let {buildDotNetLabelGenerated} = await import('./label.gb');
    return await buildDotNetLabelGenerated(jsObject);
}
