import CoordinateConversion from '@arcgis/core/widgets/CoordinateConversion';
import CoordinateConversionWidgetGenerated from './coordinateConversionWidget.gb';

export default class CoordinateConversionWidgetWrapper extends CoordinateConversionWidgetGenerated {

    constructor(widget: CoordinateConversion) {
        super(widget);
    }
    
}

export async function buildJsCoordinateConversionWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoordinateConversionWidgetGenerated } = await import('./coordinateConversionWidget.gb');
    return await buildJsCoordinateConversionWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCoordinateConversionWidget(jsObject: any): Promise<any> {
    let { buildDotNetCoordinateConversionWidgetGenerated } = await import('./coordinateConversionWidget.gb');
    return await buildDotNetCoordinateConversionWidgetGenerated(jsObject);
}
