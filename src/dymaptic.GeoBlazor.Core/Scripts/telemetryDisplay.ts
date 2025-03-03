
export async function buildJsTelemetryDisplay(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildJsTelemetryDisplayGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTelemetryDisplay(jsObject: any): Promise<any> {
    let { buildDotNetTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildDotNetTelemetryDisplayGenerated(jsObject);
}
