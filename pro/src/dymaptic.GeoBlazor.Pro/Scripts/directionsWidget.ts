// override generated code in this file
import DirectionsWidgetGenerated from './directionsWidget.gb';
import Directions from '@arcgis/core/widgets/Directions';

export default class DirectionsWidgetWrapper extends DirectionsWidgetGenerated {

    constructor(widget: Directions) {
        super(widget);
    }
    
}

export async function buildJsDirectionsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsWidgetGenerated } = await import('./directionsWidget.gb');
    return await buildJsDirectionsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionsWidgetGenerated } = await import('./directionsWidget.gb');
    return await buildDotNetDirectionsWidgetGenerated(jsObject, layerId, viewId);
}
