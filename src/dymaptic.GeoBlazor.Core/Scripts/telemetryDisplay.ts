
export async function buildJsTelemetryDisplay(dotNetObject: any): Promise<any> {
    let { buildJsTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildJsTelemetryDisplayGenerated(dotNetObject);
}     

export async function buildDotNetTelemetryDisplay(jsObject: any): Promise<any> {
    let { buildDotNetTelemetryDisplayGenerated } = await import('./telemetryDisplay.gb');
    return await buildDotNetTelemetryDisplayGenerated(jsObject);
}
