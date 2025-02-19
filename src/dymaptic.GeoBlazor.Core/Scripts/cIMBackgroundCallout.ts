
export async function buildJsCIMBackgroundCallout(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMBackgroundCalloutGenerated } = await import('./cIMBackgroundCallout.gb');
    return await buildJsCIMBackgroundCalloutGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMBackgroundCallout(jsObject: any): Promise<any> {
    let { buildDotNetCIMBackgroundCalloutGenerated } = await import('./cIMBackgroundCallout.gb');
    return await buildDotNetCIMBackgroundCalloutGenerated(jsObject);
}
