// override generated code in this file


export async function buildJsEditedFeatureResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEditedFeatureResultGenerated} = await import('./editedFeatureResult.gb');
    return await buildJsEditedFeatureResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEditedFeatureResult(jsObject: any): Promise<any> {
    let {buildDotNetEditedFeatureResultGenerated} = await import('./editedFeatureResult.gb');
    return await buildDotNetEditedFeatureResultGenerated(jsObject);
}
