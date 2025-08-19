// override generated code in this file
export async function buildJsQuery(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsQueryGenerated} = await import('./query.gb');
    return await buildJsQueryGenerated(dotNetObject, viewId);
}

export async function buildDotNetQuery(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetQueryGenerated} = await import('./query.gb');
    return await buildDotNetQueryGenerated(jsObject, viewId);
}
