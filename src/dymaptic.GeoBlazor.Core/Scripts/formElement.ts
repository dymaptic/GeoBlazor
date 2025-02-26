
export async function buildJsFormElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFormElementGenerated } = await import('./formElement.gb');
    return await buildJsFormElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFormElement(jsObject: any): Promise<any> {
    let { buildDotNetFormElementGenerated } = await import('./formElement.gb');
    return await buildDotNetFormElementGenerated(jsObject);
}
