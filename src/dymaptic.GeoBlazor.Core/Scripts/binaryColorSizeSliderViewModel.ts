import BinaryColorSizeSliderViewModel
    from '@arcgis/core/widgets/smartMapping/BinaryColorSizeSlider/BinaryColorSizeSliderViewModel';
import BinaryColorSizeSliderViewModelGenerated from './binaryColorSizeSliderViewModel.gb';

export default class BinaryColorSizeSliderViewModelWrapper extends BinaryColorSizeSliderViewModelGenerated {

    constructor(component: BinaryColorSizeSliderViewModel) {
        super(component);
    }

}

export async function buildJsBinaryColorSizeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBinaryColorSizeSliderViewModelGenerated} = await import('./binaryColorSizeSliderViewModel.gb');
    return await buildJsBinaryColorSizeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBinaryColorSizeSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetBinaryColorSizeSliderViewModelGenerated} = await import('./binaryColorSizeSliderViewModel.gb');
    return await buildDotNetBinaryColorSizeSliderViewModelGenerated(jsObject);
}
