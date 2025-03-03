
export async function buildJsCIMColorSubstitution(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMColorSubstitutionGenerated } = await import('./cIMColorSubstitution.gb');
    return await buildJsCIMColorSubstitutionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMColorSubstitution(jsObject: any): Promise<any> {
    let { buildDotNetCIMColorSubstitutionGenerated } = await import('./cIMColorSubstitution.gb');
    return await buildDotNetCIMColorSubstitutionGenerated(jsObject);
}
