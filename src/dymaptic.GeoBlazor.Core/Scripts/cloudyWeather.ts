
export async function buildJsCloudyWeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCloudyWeatherGenerated } = await import('./cloudyWeather.gb');
    return await buildJsCloudyWeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCloudyWeather(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCloudyWeatherGenerated } = await import('./cloudyWeather.gb');
    return await buildDotNetCloudyWeatherGenerated(jsObject, layerId, viewId);
}
