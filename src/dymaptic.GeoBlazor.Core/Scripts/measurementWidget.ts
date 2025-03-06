import Measurement from '@arcgis/core/widgets/Measurement';
import MeasurementWidgetGenerated from './measurementWidget.gb';

export default class MeasurementWidgetWrapper extends MeasurementWidgetGenerated {

    constructor(widget: Measurement) {
        super(widget);
    }

}

export async function buildJsMeasurementWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMeasurementWidgetGenerated} = await import('./measurementWidget.gb');
    return await buildJsMeasurementWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMeasurementWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMeasurementWidgetGenerated} = await import('./measurementWidget.gb');
    return await buildDotNetMeasurementWidgetGenerated(jsObject, layerId, viewId);
}
