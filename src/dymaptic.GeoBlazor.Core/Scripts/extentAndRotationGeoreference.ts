
export async function buildJsExtentAndRotationGeoreference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExtentAndRotationGeoreferenceGenerated } = await import('./extentAndRotationGeoreference.gb');
    return await buildJsExtentAndRotationGeoreferenceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExtentAndRotationGeoreference(jsObject: any): Promise<any> {
    let { buildDotNetExtentAndRotationGeoreferenceGenerated } = await import('./extentAndRotationGeoreference.gb');
    return await buildDotNetExtentAndRotationGeoreferenceGenerated(jsObject);
}
