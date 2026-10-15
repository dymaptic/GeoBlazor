// override generated code in this file
import HistogramRangeSliderWidgetGenerated from './histogramRangeSliderWidget.gb';
import HistogramRangeSlider from '@arcgis/core/widgets/HistogramRangeSlider';

export default class HistogramRangeSliderWidgetWrapper extends HistogramRangeSliderWidgetGenerated {

    constructor(widget: HistogramRangeSlider) {
        super(widget);
    }
    
}

export async function buildJsHistogramRangeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramRangeSliderWidgetGenerated } = await import('./histogramRangeSliderWidget.gb');
    return await buildJsHistogramRangeSliderWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramRangeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramRangeSliderWidgetGenerated } = await import('./histogramRangeSliderWidget.gb');
    return await buildDotNetHistogramRangeSliderWidgetGenerated(jsObject, layerId, viewId);
}
