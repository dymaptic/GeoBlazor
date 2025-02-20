export async function buildJsSynthesizeAssociationGeometriesParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSynthesizeAssociationGeometriesParametersGenerated} = await import('./synthesizeAssociationGeometriesParameters.gb');
    return await buildJsSynthesizeAssociationGeometriesParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSynthesizeAssociationGeometriesParameters(jsObject: any): Promise<any> {
    let {buildDotNetSynthesizeAssociationGeometriesParametersGenerated} = await import('./synthesizeAssociationGeometriesParameters.gb');
    return await buildDotNetSynthesizeAssociationGeometriesParametersGenerated(jsObject);
}
