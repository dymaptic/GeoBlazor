// override generated code in this file
import DaylightWidgetGenerated from './daylightWidget.gb';
import Daylight from '@arcgis/core/widgets/Daylight';

export default class DaylightWidgetWrapper extends DaylightWidgetGenerated {

    constructor(widget: Daylight) {
        super(widget);
    }
    
}

export async function buildJsDaylightWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDaylightWidgetGenerated } = await import('./daylightWidget.gb');
    return await buildJsDaylightWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDaylightWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDaylightWidgetGenerated } = await import('./daylightWidget.gb');
    return await buildDotNetDaylightWidgetGenerated(jsObject, layerId, viewId);
}
