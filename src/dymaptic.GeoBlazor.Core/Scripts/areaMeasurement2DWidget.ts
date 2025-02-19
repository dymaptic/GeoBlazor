// override generated code in this file
import AreaMeasurement2DWidgetGenerated from './areaMeasurement2DWidget.gb';
import AreaMeasurement2D from '@arcgis/core/widgets/AreaMeasurement2D';

export default class AreaMeasurement2DWidgetWrapper extends AreaMeasurement2DWidgetGenerated {

    constructor(widget: AreaMeasurement2D) {
        super(widget);
    }
    
}

export async function buildJsAreaMeasurement2DWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement2DWidgetGenerated } = await import('./areaMeasurement2DWidget.gb');
    return await buildJsAreaMeasurement2DWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement2DWidget(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement2DWidgetGenerated } = await import('./areaMeasurement2DWidget.gb');
    return await buildDotNetAreaMeasurement2DWidgetGenerated(jsObject);
}
