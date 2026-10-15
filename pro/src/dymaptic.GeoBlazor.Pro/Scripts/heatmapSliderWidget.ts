// override generated code in this file
import HeatmapSliderWidgetGenerated from './heatmapSliderWidget.gb';
import HeatmapSlider from '@arcgis/core/widgets/smartMapping/HeatmapSlider';

export default class HeatmapSliderWidgetWrapper extends HeatmapSliderWidgetGenerated {

    constructor(widget: HeatmapSlider) {
        super(widget);
    }
    
}

export async function buildJsHeatmapSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapSliderWidgetGenerated } = await import('./heatmapSliderWidget.gb');
    return await buildJsHeatmapSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHeatmapSliderWidgetGenerated } = await import('./heatmapSliderWidget.gb');
    return await buildDotNetHeatmapSliderWidgetGenerated(jsObject, layerId, viewId);
}
