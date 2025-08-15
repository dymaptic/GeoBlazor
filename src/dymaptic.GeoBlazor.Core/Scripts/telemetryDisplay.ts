
export async function buildJsTelemetryDisplay(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildJsTelemetryDisplayGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTelemetryDisplay(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildDotNetTelemetryDisplayGenerated(jsObject, viewId);
}
