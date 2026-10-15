// override generated code in this file
import HistogramRangeSliderViewModelGenerated from './histogramRangeSliderViewModel.gb';
import HistogramRangeSliderViewModel from '@arcgis/core/widgets/HistogramRangeSlider/HistogramRangeSliderViewModel';

export default class HistogramRangeSliderViewModelWrapper extends HistogramRangeSliderViewModelGenerated {

    constructor(component: HistogramRangeSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsHistogramRangeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramRangeSliderViewModelGenerated } = await import('./histogramRangeSliderViewModel.gb');
    return await buildJsHistogramRangeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramRangeSliderViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramRangeSliderViewModelGenerated } = await import('./histogramRangeSliderViewModel.gb');
    return await buildDotNetHistogramRangeSliderViewModelGenerated(jsObject, layerId, viewId);
}
