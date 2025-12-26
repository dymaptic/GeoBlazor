import ScaleBarWidgetGenerated from './scaleBarWidget.gb';
import ScaleBar from '@arcgis/core/widgets/ScaleBar';

export default class ScaleBarWidgetWrapper extends ScaleBarWidgetGenerated {

    constructor(widget: ScaleBar) {
        super(widget);
    }
    
}

export async function buildJsScaleBarWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleBarWidgetGenerated } = await import('./scaleBarWidget.gb');
    return await buildJsScaleBarWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetScaleBarWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetScaleBarWidgetGenerated } = await import('./scaleBarWidget.gb');
    return await buildDotNetScaleBarWidgetGenerated(jsObject, layerId, viewId);
}
