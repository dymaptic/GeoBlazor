// override generated code in this file


export async function buildJsCoverageInfo(dotNetObject: any): Promise<any> {
    let {buildJsCoverageInfoGenerated} = await import('./coverageInfo.gb');
    return await buildJsCoverageInfoGenerated(dotNetObject);
}

export async function buildDotNetCoverageInfo(jsObject: any): Promise<any> {
    let {buildDotNetCoverageInfoGenerated} = await import('./coverageInfo.gb');
    return await buildDotNetCoverageInfoGenerated(jsObject);
}
