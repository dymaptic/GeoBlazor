// override generated code in this file
import ClassedSizeSliderViewModelGenerated from './classedSizeSliderViewModel.gb';
import ClassedSizeSliderViewModel from '@arcgis/core/widgets/smartMapping/ClassedSizeSlider/ClassedSizeSliderViewModel';

export default class ClassedSizeSliderViewModelWrapper extends ClassedSizeSliderViewModelGenerated {

    constructor(component: ClassedSizeSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsClassedSizeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedSizeSliderViewModelGenerated } = await import('./classedSizeSliderViewModel.gb');
    return await buildJsClassedSizeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedSizeSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetClassedSizeSliderViewModelGenerated } = await import('./classedSizeSliderViewModel.gb');
    return await buildDotNetClassedSizeSliderViewModelGenerated(jsObject);
}
