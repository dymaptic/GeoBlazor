
export async function buildJsAuthoringInfoField1ClassBreakInfos(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoField1ClassBreakInfosGenerated } = await import('./authoringInfoField1ClassBreakInfos.gb');
    return await buildJsAuthoringInfoField1ClassBreakInfosGenerated(dotNetObject, viewId);
}     

export async function buildDotNetAuthoringInfoField1ClassBreakInfos(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoField1ClassBreakInfosGenerated } = await import('./authoringInfoField1ClassBreakInfos.gb');
    return await buildDotNetAuthoringInfoField1ClassBreakInfosGenerated(jsObject, viewId);
}
