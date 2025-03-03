
export async function buildJsCIMClippingPath(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMClippingPathGenerated } = await import('./cIMClippingPath.gb');
    return await buildJsCIMClippingPathGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMClippingPath(jsObject: any): Promise<any> {
    let { buildDotNetCIMClippingPathGenerated } = await import('./cIMClippingPath.gb');
    return await buildDotNetCIMClippingPathGenerated(jsObject);
}
