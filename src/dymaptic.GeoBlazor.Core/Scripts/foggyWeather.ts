
export async function buildJsFoggyWeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFoggyWeatherGenerated } = await import('./foggyWeather.gb');
    return await buildJsFoggyWeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFoggyWeather(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFoggyWeatherGenerated } = await import('./foggyWeather.gb');
    return await buildDotNetFoggyWeatherGenerated(jsObject, viewId);
}
