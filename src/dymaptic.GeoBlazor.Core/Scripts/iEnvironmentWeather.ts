
export async function buildJsIEnvironmentWeather(dotNetObject: any): Promise<any> {
    let { buildJsIEnvironmentWeatherGenerated } = await import('./iEnvironmentWeather.gb');
    return await buildJsIEnvironmentWeatherGenerated(dotNetObject);
}     

export async function buildDotNetIEnvironmentWeather(jsObject: any): Promise<any> {
    let { buildDotNetIEnvironmentWeatherGenerated } = await import('./iEnvironmentWeather.gb');
    return await buildDotNetIEnvironmentWeatherGenerated(jsObject);
}
