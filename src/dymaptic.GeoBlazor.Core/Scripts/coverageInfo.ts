// override generated code in this file


export async function buildJsCoverageInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageInfoGenerated} = await import('./coverageInfo.gb');
    return await buildJsCoverageInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageInfo(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetCoverageInfoGenerated} = await import('./coverageInfo.gb');
    return await buildDotNetCoverageInfoGenerated(jsObject, viewId);
}
