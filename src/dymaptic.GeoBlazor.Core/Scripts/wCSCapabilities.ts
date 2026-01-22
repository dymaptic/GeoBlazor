export async function buildJsWCSCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsWCSCapabilitiesGenerated } = await import('./wCSCapabilities.gb');
    return await buildJsWCSCapabilitiesGenerated(dotNetObject);
}

export async function buildDotNetWCSCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetWCSCapabilitiesGenerated } = await import('./wCSCapabilities.gb');
    return await buildDotNetWCSCapabilitiesGenerated(jsObject);
}
