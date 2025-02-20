export async function buildJsEnvironment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEnvironmentGenerated} = await import('./environment.gb');
    return await buildJsEnvironmentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEnvironment(jsObject: any): Promise<any> {
    let {buildDotNetEnvironmentGenerated} = await import('./environment.gb');
    return await buildDotNetEnvironmentGenerated(jsObject);
}
