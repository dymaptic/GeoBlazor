export async function buildJsMediaElementBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMediaElementBaseGenerated} = await import('./mediaElementBase.gb');
    return await buildJsMediaElementBaseGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMediaElementBase(jsObject: any): Promise<any> {
    let {buildDotNetMediaElementBaseGenerated} = await import('./mediaElementBase.gb');
    return await buildDotNetMediaElementBaseGenerated(jsObject);
}
