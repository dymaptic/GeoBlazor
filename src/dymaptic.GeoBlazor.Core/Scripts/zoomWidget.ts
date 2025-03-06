// override generated code in this file
import ZoomWidgetGenerated from './zoomWidget.gb';
import Zoom from '@arcgis/core/widgets/Zoom';

export default class ZoomWidgetWrapper extends ZoomWidgetGenerated {

    constructor(widget: Zoom) {
        super(widget);
    }

}

export async function buildJsZoomWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsZoomWidgetGenerated} = await import('./zoomWidget.gb');
    return await buildJsZoomWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetZoomWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetZoomWidgetGenerated} = await import('./zoomWidget.gb');
    return await buildDotNetZoomWidgetGenerated(jsObject, layerId, viewId);
}
