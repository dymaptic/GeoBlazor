// override generated code in this file
import ClassedColorSliderViewModelGenerated from './classedColorSliderViewModel.gb';
import ClassedColorSliderViewModel from '@arcgis/core/widgets/smartMapping/ClassedColorSlider/ClassedColorSliderViewModel';

export default class ClassedColorSliderViewModelWrapper extends ClassedColorSliderViewModelGenerated {

    constructor(component: ClassedColorSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsClassedColorSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedColorSliderViewModelGenerated } = await import('./classedColorSliderViewModel.gb');
    return await buildJsClassedColorSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedColorSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetClassedColorSliderViewModelGenerated } = await import('./classedColorSliderViewModel.gb');
    return await buildDotNetClassedColorSliderViewModelGenerated(jsObject);
}
