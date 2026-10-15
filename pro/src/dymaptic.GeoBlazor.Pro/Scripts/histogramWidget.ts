// override generated code in this file
import HistogramWidgetGenerated from './histogramWidget.gb';
import Histogram from '@arcgis/core/widgets/Histogram';

export default class HistogramWidgetWrapper extends HistogramWidgetGenerated {

    constructor(widget: Histogram) {
        super(widget);
    }
    
}

export async function buildJsHistogramWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramWidgetGenerated } = await import('./histogramWidget.gb');
    return await buildJsHistogramWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramWidgetGenerated } = await import('./histogramWidget.gb');
    return await buildDotNetHistogramWidgetGenerated(jsObject, layerId, viewId);
}
