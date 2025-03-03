
export async function buildJsMagnifierScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMagnifierScreenPointGenerated } = await import('./magnifierScreenPoint.gb');
    return await buildJsMagnifierScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMagnifierScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetMagnifierScreenPointGenerated } = await import('./magnifierScreenPoint.gb');
    return await buildDotNetMagnifierScreenPointGenerated(jsObject);
}
