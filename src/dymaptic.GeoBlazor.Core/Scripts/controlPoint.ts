export async function buildJsControlPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsControlPointGenerated} = await import('./controlPoint.gb');
    return await buildJsControlPointGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetControlPoint(jsObject: any): Promise<any> {
    let {buildDotNetControlPointGenerated} = await import('./controlPoint.gb');
    return await buildDotNetControlPointGenerated(jsObject);
}
