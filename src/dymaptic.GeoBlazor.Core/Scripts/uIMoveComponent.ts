export async function buildJsUIMoveComponent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUIMoveComponentGenerated} = await import('./uIMoveComponent.gb');
    return await buildJsUIMoveComponentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUIMoveComponent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetUIMoveComponentGenerated} = await import('./uIMoveComponent.gb');
    return await buildDotNetUIMoveComponentGenerated(jsObject, layerId, viewId);
}
