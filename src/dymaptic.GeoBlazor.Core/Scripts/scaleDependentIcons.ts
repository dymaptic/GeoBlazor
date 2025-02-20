export async function buildJsScaleDependentIcons(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsScaleDependentIconsGenerated} = await import('./scaleDependentIcons.gb');
    return await buildJsScaleDependentIconsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetScaleDependentIcons(jsObject: any): Promise<any> {
    let {buildDotNetScaleDependentIconsGenerated} = await import('./scaleDependentIcons.gb');
    return await buildDotNetScaleDependentIconsGenerated(jsObject);
}
