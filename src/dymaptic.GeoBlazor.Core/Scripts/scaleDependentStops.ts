export async function buildJsScaleDependentStops(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsScaleDependentStopsGenerated} = await import('./scaleDependentStops.gb');
    return await buildJsScaleDependentStopsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetScaleDependentStops(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetScaleDependentStopsGenerated} = await import('./scaleDependentStops.gb');
    return await buildDotNetScaleDependentStopsGenerated(jsObject, layerId, viewId);
}
