// override generated code in this file
import WidgetGenerated from './widget.gb';
import Widget from '@arcgis/core/widgets/Widget';

export default class WidgetWrapper extends WidgetGenerated {

    constructor(widget: Widget) {
        super(widget);
    }
    
}

export async function buildJsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWidgetGenerated } = await import('./widget.gb');
    return await buildJsWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWidget(jsObject: any): Promise<any> {
    let { buildDotNetWidgetGenerated } = await import('./widget.gb');
    return await buildDotNetWidgetGenerated(jsObject);
}
