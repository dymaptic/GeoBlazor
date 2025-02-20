export async function buildJsValidateTopologyProps(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsValidateTopologyPropsGenerated} = await import('./validateTopologyProps.gb');
    return await buildJsValidateTopologyPropsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetValidateTopologyProps(jsObject: any): Promise<any> {
    let {buildDotNetValidateTopologyPropsGenerated} = await import('./validateTopologyProps.gb');
    return await buildDotNetValidateTopologyPropsGenerated(jsObject);
}
