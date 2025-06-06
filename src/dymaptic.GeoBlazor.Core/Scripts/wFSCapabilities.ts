export async function buildJsWFSCapabilities(dotNetObject: any): Promise<any> {
    let {buildJsWFSCapabilitiesGenerated} = await import('./wFSCapabilities.gb');
    return await buildJsWFSCapabilitiesGenerated(dotNetObject);
}

export async function buildDotNetWFSCapabilities(jsObject: any): Promise<any> {
    let {buildDotNetWFSCapabilitiesGenerated} = await import('./wFSCapabilities.gb');
    return await buildDotNetWFSCapabilitiesGenerated(jsObject);
}
