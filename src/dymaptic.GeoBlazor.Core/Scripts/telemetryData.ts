export async function buildJsTelemetryData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTelemetryDataGenerated} = await import('./telemetryData.gb');
    return await buildJsTelemetryDataGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTelemetryData(jsObject: any): Promise<any> {
    let {buildDotNetTelemetryDataGenerated} = await import('./telemetryData.gb');
    return await buildDotNetTelemetryDataGenerated(jsObject);
}
