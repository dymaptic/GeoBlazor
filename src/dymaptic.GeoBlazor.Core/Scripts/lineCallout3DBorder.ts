export async function buildJsLineCallout3DBorder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineCallout3DBorderGenerated } = await import('./lineCallout3DBorder.gb');
    return await buildJsLineCallout3DBorderGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLineCallout3DBorder(jsObject: any): Promise<any> {
    let { buildDotNetLineCallout3DBorderGenerated } = await import('./lineCallout3DBorder.gb');
    return await buildDotNetLineCallout3DBorderGenerated(jsObject);
}
