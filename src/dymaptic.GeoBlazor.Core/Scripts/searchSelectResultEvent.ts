export function buildJsSearchSelectResultEvent(dnObject: any): any {
    // not used
}
export async function buildDotNetSearchSelectResultEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchSelectResultEventGenerated } = await import('./searchSelectResultEvent.gb');
    return await buildDotNetSearchSelectResultEventGenerated(jsObject, layerId, viewId);
}
