export async function buildJsMediaElementBase(dotNetObject: any): Promise<any> {
    let {buildJsMediaElementBaseGenerated} = await import('./mediaElementBase.gb');
    return buildJsMediaElementBaseGenerated(dotNetObject);
}

export async function buildDotNetMediaElementBase(jsObject: any): Promise<any> {
    let {buildDotNetMediaElementBaseGenerated} = await import('./mediaElementBase.gb');
    return await buildDotNetMediaElementBaseGenerated(jsObject);
}
