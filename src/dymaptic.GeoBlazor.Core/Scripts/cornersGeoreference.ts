export async function buildJsCornersGeoreference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCornersGeoreferenceGenerated} = await import('./cornersGeoreference.gb');
    return await buildJsCornersGeoreferenceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCornersGeoreference(jsObject: any): Promise<any> {
    let {buildDotNetCornersGeoreferenceGenerated} = await import('./cornersGeoreference.gb');
    return await buildDotNetCornersGeoreferenceGenerated(jsObject);
}
