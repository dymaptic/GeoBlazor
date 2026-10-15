// override generated code in this file
import WeatherWidgetGenerated from './weatherWidget.gb';
import Weather from '@arcgis/core/widgets/Weather';

export default class WeatherWidgetWrapper extends WeatherWidgetGenerated {

    constructor(widget: Weather) {
        super(widget);
    }
    
}

export async function buildJsWeatherWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWeatherWidgetGenerated } = await import('./weatherWidget.gb');
    return await buildJsWeatherWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWeatherWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWeatherWidgetGenerated } = await import('./weatherWidget.gb');
    return await buildDotNetWeatherWidgetGenerated(jsObject, layerId, viewId);
}
