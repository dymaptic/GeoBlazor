// override generated code in this file
import AreaMeasurement3DWidgetGenerated from './areaMeasurement3DWidget.gb';
import AreaMeasurement3D from '@arcgis/core/widgets/AreaMeasurement3D';

export default class AreaMeasurement3DWidgetWrapper extends AreaMeasurement3DWidgetGenerated {

    constructor(widget: AreaMeasurement3D) {
        super(widget);
    }

}

export async function buildJsAreaMeasurement3DWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAreaMeasurement3DWidgetGenerated} = await import('./areaMeasurement3DWidget.gb');
    return await buildJsAreaMeasurement3DWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAreaMeasurement3DWidget(jsObject: any): Promise<any> {
    let {buildDotNetAreaMeasurement3DWidgetGenerated} = await import('./areaMeasurement3DWidget.gb');
    return await buildDotNetAreaMeasurement3DWidgetGenerated(jsObject);
}
