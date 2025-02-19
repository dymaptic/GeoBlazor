export async function buildJsCIMLineCallout(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMLineCalloutGenerated } = await import('./cIMLineCallout.gb');
    return await buildJsCIMLineCalloutGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCIMLineCallout(jsObject: any): Promise<any> {
    let { buildDotNetCIMLineCalloutGenerated } = await import('./cIMLineCallout.gb');
    return await buildDotNetCIMLineCalloutGenerated(jsObject);
}
