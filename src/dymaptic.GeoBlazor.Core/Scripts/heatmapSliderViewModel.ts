// override generated code in this file
import HeatmapSliderViewModelGenerated from './heatmapSliderViewModel.gb';
import HeatmapSliderViewModel from '@arcgis/core/widgets/smartMapping/HeatmapSlider/HeatmapSliderViewModel';

export default class HeatmapSliderViewModelWrapper extends HeatmapSliderViewModelGenerated {

    constructor(component: HeatmapSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsHeatmapSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapSliderViewModelGenerated } = await import('./heatmapSliderViewModel.gb');
    return await buildJsHeatmapSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetHeatmapSliderViewModelGenerated } = await import('./heatmapSliderViewModel.gb');
    return await buildDotNetHeatmapSliderViewModelGenerated(jsObject);
}
