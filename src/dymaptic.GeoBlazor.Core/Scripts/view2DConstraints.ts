
export async function buildJsView2DConstraints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsView2DConstraintsGenerated } = await import('./view2DConstraints.gb');
    return await buildJsView2DConstraintsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetView2DConstraints(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetView2DConstraintsGenerated } = await import('./view2DConstraints.gb');
    return await buildDotNetView2DConstraintsGenerated(jsObject, viewId);
}
