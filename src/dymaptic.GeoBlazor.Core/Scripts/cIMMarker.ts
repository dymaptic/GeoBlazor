
export async function buildJsCIMMarker(dotNetObject: any): Promise<any> {
    let { buildJsCIMMarkerGenerated } = await import('./cIMMarker.gb');
    return await buildJsCIMMarkerGenerated(dotNetObject);
}     

export async function buildDotNetCIMMarker(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerGenerated } = await import('./cIMMarker.gb');
    return await buildDotNetCIMMarkerGenerated(jsObject);
}
