// override generated code in this file
import ScaleRangeSliderViewModelGenerated from './scaleRangeSliderViewModel.gb';
import ScaleRangeSliderViewModel from '@arcgis/core/widgets/ScaleRangeSlider/ScaleRangeSliderViewModel';

export default class ScaleRangeSliderViewModelWrapper extends ScaleRangeSliderViewModelGenerated {

    constructor(component: ScaleRangeSliderViewModel) {
        super(component);
    }

}

export async function buildJsScaleRangeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsScaleRangeSliderViewModelGenerated} = await import('./scaleRangeSliderViewModel.gb');
    return await buildJsScaleRangeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetScaleRangeSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetScaleRangeSliderViewModelGenerated} = await import('./scaleRangeSliderViewModel.gb');
    return await buildDotNetScaleRangeSliderViewModelGenerated(jsObject);
}
