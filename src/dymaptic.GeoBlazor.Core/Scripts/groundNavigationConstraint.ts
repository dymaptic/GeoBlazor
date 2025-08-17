
export async function buildJsGroundNavigationConstraint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroundNavigationConstraintGenerated } = await import('./groundNavigationConstraint.gb');
    return await buildJsGroundNavigationConstraintGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroundNavigationConstraint(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGroundNavigationConstraintGenerated } = await import('./groundNavigationConstraint.gb');
    return await buildDotNetGroundNavigationConstraintGenerated(jsObject, viewId);
}
