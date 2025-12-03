
export async function buildJsSunnyWeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSunnyWeatherGenerated } = await import('./sunnyWeather.gb');
    return await buildJsSunnyWeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSunnyWeather(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSunnyWeatherGenerated } = await import('./sunnyWeather.gb');
    return await buildDotNetSunnyWeatherGenerated(jsObject, viewId);
}
