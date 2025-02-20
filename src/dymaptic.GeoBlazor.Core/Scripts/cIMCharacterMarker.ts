export async function buildJsCIMCharacterMarker(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCIMCharacterMarkerGenerated} = await import('./cIMCharacterMarker.gb');
    return await buildJsCIMCharacterMarkerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCIMCharacterMarker(jsObject: any): Promise<any> {
    let {buildDotNetCIMCharacterMarkerGenerated} = await import('./cIMCharacterMarker.gb');
    return await buildDotNetCIMCharacterMarkerGenerated(jsObject);
}
