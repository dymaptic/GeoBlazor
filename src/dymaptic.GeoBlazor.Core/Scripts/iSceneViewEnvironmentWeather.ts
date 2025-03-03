
export async function buildJsISceneViewEnvironmentWeather(dotNetObject: any): Promise<any> {
    let { buildJsISceneViewEnvironmentWeatherGenerated } = await import('./iSceneViewEnvironmentWeather.gb');
    return await buildJsISceneViewEnvironmentWeatherGenerated(dotNetObject);
}     

export async function buildDotNetISceneViewEnvironmentWeather(jsObject: any): Promise<any> {
    let { buildDotNetISceneViewEnvironmentWeatherGenerated } = await import('./iSceneViewEnvironmentWeather.gb');
    return await buildDotNetISceneViewEnvironmentWeatherGenerated(jsObject);
}
