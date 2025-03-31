
export async function buildJsCapabilitiesData(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildJsCapabilitiesDataGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesData(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildDotNetCapabilitiesDataGenerated(jsObject);
}
