// override generated code in this file
import WeatherViewModelGenerated from './weatherViewModel.gb';
import WeatherViewModel from '@arcgis/core/widgets/Weather/WeatherViewModel';

export default class WeatherViewModelWrapper extends WeatherViewModelGenerated {

    constructor(component: WeatherViewModel) {
        super(component);
    }

}

export async function buildJsWeatherViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWeatherViewModelGenerated} = await import('./weatherViewModel.gb');
    return await buildJsWeatherViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWeatherViewModel(jsObject: any): Promise<any> {
    let {buildDotNetWeatherViewModelGenerated} = await import('./weatherViewModel.gb');
    return await buildDotNetWeatherViewModelGenerated(jsObject);
}
