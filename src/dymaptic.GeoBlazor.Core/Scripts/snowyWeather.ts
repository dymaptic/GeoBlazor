
export async function buildJsSnowyWeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnowyWeatherGenerated } = await import('./snowyWeather.gb');
    return await buildJsSnowyWeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnowyWeather(jsObject: any): Promise<any> {
    let { buildDotNetSnowyWeatherGenerated } = await import('./snowyWeather.gb');
    return await buildDotNetSnowyWeatherGenerated(jsObject);
}
