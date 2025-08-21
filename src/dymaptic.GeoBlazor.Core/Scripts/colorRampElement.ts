export async function buildJsColorRampElement(dotNetObject: any): Promise<any> {
    let {buildJsColorRampElementGenerated} = await import('./colorRampElement.gb');
    return await buildJsColorRampElementGenerated(dotNetObject);
}

export async function buildDotNetColorRampElement(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetColorRampElementGenerated} = await import('./colorRampElement.gb');
    return await buildDotNetColorRampElementGenerated(jsObject, viewId);
}
