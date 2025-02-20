export async function buildJsLineCallout3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineCallout3DGenerated} = await import('./lineCallout3D.gb');
    return await buildJsLineCallout3DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineCallout3D(jsObject: any): Promise<any> {
    let {buildDotNetLineCallout3DGenerated} = await import('./lineCallout3D.gb');
    return await buildDotNetLineCallout3DGenerated(jsObject);
}
