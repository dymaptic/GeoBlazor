import MeasurementWidgetActiveWidget = __esri.MeasurementWidgetActiveWidget;
import IMeasurementWidgetActiveWidgetGenerated from './iMeasurementWidgetActiveWidget.gb';

export default class IMeasurementWidgetActiveWidgetWrapper extends IMeasurementWidgetActiveWidgetGenerated {

    constructor(widget: MeasurementWidgetActiveWidget) {
        super(widget);
    }
    
}

export async function buildJsIMeasurementWidgetActiveWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIMeasurementWidgetActiveWidgetGenerated } = await import('./iMeasurementWidgetActiveWidget.gb');
    return await buildJsIMeasurementWidgetActiveWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIMeasurementWidgetActiveWidget(jsObject: any): Promise<any> {
    let { buildDotNetIMeasurementWidgetActiveWidgetGenerated } = await import('./iMeasurementWidgetActiveWidget.gb');
    return await buildDotNetIMeasurementWidgetActiveWidgetGenerated(jsObject);
}
