
export async function buildJsAuthoringInfoField2ClassBreakInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoField2ClassBreakInfosGenerated } = await import('./authoringInfoField2ClassBreakInfos.gb');
    return await buildJsAuthoringInfoField2ClassBreakInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAuthoringInfoField2ClassBreakInfos(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoField2ClassBreakInfosGenerated } = await import('./authoringInfoField2ClassBreakInfos.gb');
    return await buildDotNetAuthoringInfoField2ClassBreakInfosGenerated(jsObject, layerId, viewId);
}
