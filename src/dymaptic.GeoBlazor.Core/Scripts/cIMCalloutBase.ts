
export async function buildJsCIMCalloutBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMCalloutBaseGenerated } = await import('./cIMCalloutBase.gb');
    return await buildJsCIMCalloutBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMCalloutBase(jsObject: any): Promise<any> {
    let { buildDotNetCIMCalloutBaseGenerated } = await import('./cIMCalloutBase.gb');
    return await buildDotNetCIMCalloutBaseGenerated(jsObject);
}
