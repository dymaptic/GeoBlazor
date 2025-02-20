export async function buildJsLineOfSightTarget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineOfSightTargetGenerated} = await import('./lineOfSightTarget.gb');
    return await buildJsLineOfSightTargetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineOfSightTarget(jsObject: any): Promise<any> {
    let {buildDotNetLineOfSightTargetGenerated} = await import('./lineOfSightTarget.gb');
    return await buildDotNetLineOfSightTargetGenerated(jsObject);
}
