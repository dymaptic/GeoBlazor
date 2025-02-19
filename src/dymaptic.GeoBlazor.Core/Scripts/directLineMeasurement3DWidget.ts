// override generated code in this file
import DirectLineMeasurement3DWidgetGenerated from './directLineMeasurement3DWidget.gb';
import DirectLineMeasurement3D from '@arcgis/core/widgets/DirectLineMeasurement3D';

export default class DirectLineMeasurement3DWidgetWrapper extends DirectLineMeasurement3DWidgetGenerated {

    constructor(widget: DirectLineMeasurement3D) {
        super(widget);
    }
    
}

export async function buildJsDirectLineMeasurement3DWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurement3DWidgetGenerated } = await import('./directLineMeasurement3DWidget.gb');
    return await buildJsDirectLineMeasurement3DWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectLineMeasurement3DWidget(jsObject: any): Promise<any> {
    let { buildDotNetDirectLineMeasurement3DWidgetGenerated } = await import('./directLineMeasurement3DWidget.gb');
    return await buildDotNetDirectLineMeasurement3DWidgetGenerated(jsObject);
}
