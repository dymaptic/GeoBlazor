
export async function buildJsRainyWeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRainyWeatherGenerated } = await import('./rainyWeather.gb');
    return await buildJsRainyWeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRainyWeather(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRainyWeatherGenerated } = await import('./rainyWeather.gb');
    return await buildDotNetRainyWeatherGenerated(jsObject, layerId, viewId);
}
