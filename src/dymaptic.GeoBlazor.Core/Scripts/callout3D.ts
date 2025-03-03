
export async function buildJsCallout3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCallout3DGenerated } = await import('./callout3D.gb');
    return await buildJsCallout3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCallout3D(jsObject: any): Promise<any> {
    let { buildDotNetCallout3DGenerated } = await import('./callout3D.gb');
    return await buildDotNetCallout3DGenerated(jsObject);
}
