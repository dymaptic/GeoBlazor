
export async function buildJsCoverageBrief(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoverageBriefGenerated } = await import('./coverageBrief.gb');
    return await buildJsCoverageBriefGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoverageBrief(jsObject: any): Promise<any> {
    let { buildDotNetCoverageBriefGenerated } = await import('./coverageBrief.gb');
    return await buildDotNetCoverageBriefGenerated(jsObject);
}
