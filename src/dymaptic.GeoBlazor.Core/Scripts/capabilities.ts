
export async function buildJsCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesGenerated } = await import('./capabilities.gb');
    return await buildJsCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesGenerated } = await import('./capabilities.gb');
    return await buildDotNetCapabilitiesGenerated(jsObject);
}
