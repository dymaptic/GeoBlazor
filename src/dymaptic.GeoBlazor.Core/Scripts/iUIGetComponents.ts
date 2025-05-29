
export async function buildJsIUIGetComponents(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIUIGetComponentsGenerated } = await import('./iUIGetComponents.gb');
    return await buildJsIUIGetComponentsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIUIGetComponents(jsObject: any): Promise<any> {
    let { buildDotNetIUIGetComponentsGenerated } = await import('./iUIGetComponents.gb');
    return await buildDotNetIUIGetComponentsGenerated(jsObject);
}
