
export async function buildJsCIMKGTraversalDirection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMKGTraversalDirectionGenerated } = await import('./cIMKGTraversalDirection.gb');
    return await buildJsCIMKGTraversalDirectionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMKGTraversalDirection(jsObject: any): Promise<any> {
    let { buildDotNetCIMKGTraversalDirectionGenerated } = await import('./cIMKGTraversalDirection.gb');
    return await buildDotNetCIMKGTraversalDirectionGenerated(jsObject);
}
