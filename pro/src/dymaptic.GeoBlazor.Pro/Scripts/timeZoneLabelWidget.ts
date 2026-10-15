// override generated code in this file
import TimeZoneLabelWidgetGenerated from './timeZoneLabelWidget.gb';
import TimeZoneLabel from '@arcgis/core/widgets/TimeZoneLabel';

export default class TimeZoneLabelWidgetWrapper extends TimeZoneLabelWidgetGenerated {

    constructor(widget: TimeZoneLabel) {
        super(widget);
    }
    
}

export async function buildJsTimeZoneLabelWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeZoneLabelWidgetGenerated } = await import('./timeZoneLabelWidget.gb');
    return await buildJsTimeZoneLabelWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeZoneLabelWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTimeZoneLabelWidgetGenerated } = await import('./timeZoneLabelWidget.gb');
    return await buildDotNetTimeZoneLabelWidgetGenerated(jsObject, layerId, viewId);
}
