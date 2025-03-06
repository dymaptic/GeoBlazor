// override generated code in this file


export async function buildJsDOMContainer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDOMContainerGenerated} = await import('./dOMContainer.gb');
    return await buildJsDOMContainerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDOMContainer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetDOMContainerGenerated} = await import('./dOMContainer.gb');
    return await buildDotNetDOMContainerGenerated(jsObject, layerId, viewId);
}
