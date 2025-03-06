export async function buildJsMapViewConstraints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapViewConstraintsGenerated} = await import('./mapViewConstraints.gb');
    return await buildJsMapViewConstraintsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapViewConstraints(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMapViewConstraintsGenerated} = await import('./mapViewConstraints.gb');
    return await buildDotNetMapViewConstraintsGenerated(jsObject, layerId, viewId);
}
