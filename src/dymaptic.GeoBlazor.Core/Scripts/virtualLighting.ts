export async function buildJsVirtualLighting(dotNetObject: any): Promise<any> {
    let {buildJsVirtualLightingGenerated} = await import('./virtualLighting.gb');
    return await buildJsVirtualLightingGenerated(dotNetObject);
}

export async function buildDotNetVirtualLighting(jsObject: any): Promise<any> {
    let {buildDotNetVirtualLightingGenerated} = await import('./virtualLighting.gb');
    return await buildDotNetVirtualLightingGenerated(jsObject);
}
