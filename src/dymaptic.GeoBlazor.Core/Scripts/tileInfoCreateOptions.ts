// override generated code in this file


export async function buildJsTileInfoCreateOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileInfoCreateOptionsGenerated} = await import('./tileInfoCreateOptions.gb');
    return await buildJsTileInfoCreateOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileInfoCreateOptions(jsObject: any): Promise<any> {
    let {buildDotNetTileInfoCreateOptionsGenerated} = await import('./tileInfoCreateOptions.gb');
    return await buildDotNetTileInfoCreateOptionsGenerated(jsObject);
}
