export async function buildJsUIAddComponent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUIAddComponentGenerated } = await import('./uIAddComponent.gb');
    return await buildJsUIAddComponentGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUIAddComponent(jsObject: any): Promise<any> {
    let { buildDotNetUIAddComponentGenerated } = await import('./uIAddComponent.gb');
    return await buildDotNetUIAddComponentGenerated(jsObject);
}
