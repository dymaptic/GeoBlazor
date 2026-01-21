export async function buildJsView2DConstraints(dotNetObject: any): Promise<any> {
    let { buildJsView2DConstraintsGenerated } = await import('./view2DConstraints.gb');
    return await buildJsView2DConstraintsGenerated(dotNetObject);
}

export async function buildDotNetView2DConstraints(jsObject: any): Promise<any> {
    let { buildDotNetView2DConstraintsGenerated } = await import('./view2DConstraints.gb');
    return await buildDotNetView2DConstraintsGenerated(jsObject);
}
