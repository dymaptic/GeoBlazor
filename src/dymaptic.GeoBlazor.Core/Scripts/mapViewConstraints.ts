export async function buildJsMapViewConstraints(dotNetObject: any): Promise<any> {
    let {buildJsMapViewConstraintsGenerated} = await import('./mapViewConstraints.gb');
    return await buildJsMapViewConstraintsGenerated(dotNetObject);
}

export async function buildDotNetMapViewConstraints(jsObject: any): Promise<any> {
    let {buildDotNetMapViewConstraintsGenerated} = await import('./mapViewConstraints.gb');
    return await buildDotNetMapViewConstraintsGenerated(jsObject);
}
