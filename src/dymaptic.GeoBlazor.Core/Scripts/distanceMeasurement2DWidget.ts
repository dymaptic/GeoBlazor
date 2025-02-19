import DistanceMeasurement2D from '@arcgis/core/widgets/DistanceMeasurement2D';
import DistanceMeasurement2DWidgetGenerated from './distanceMeasurement2DWidget.gb';

export default class DistanceMeasurement2DWidgetWrapper extends DistanceMeasurement2DWidgetGenerated {

    constructor(widget: DistanceMeasurement2D) {
        super(widget);
    }
    
}

export async function buildJsDistanceMeasurement2DWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDistanceMeasurement2DWidgetGenerated } = await import('./distanceMeasurement2DWidget.gb');
    return await buildJsDistanceMeasurement2DWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDistanceMeasurement2DWidget(jsObject: any): Promise<any> {
    let { buildDotNetDistanceMeasurement2DWidgetGenerated } = await import('./distanceMeasurement2DWidget.gb');
    return await buildDotNetDistanceMeasurement2DWidgetGenerated(jsObject);
}
