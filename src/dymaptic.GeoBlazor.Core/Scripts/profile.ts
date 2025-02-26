
export async function buildJsProfile(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProfileGenerated } = await import('./profile.gb');
    return await buildJsProfileGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProfile(jsObject: any): Promise<any> {
    let { buildDotNetProfileGenerated } = await import('./profile.gb');
    return await buildDotNetProfileGenerated(jsObject);
}
