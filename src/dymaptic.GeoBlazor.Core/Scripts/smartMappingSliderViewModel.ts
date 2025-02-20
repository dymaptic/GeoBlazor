import SmartMappingSliderViewModel from '@arcgis/core/widgets/smartMapping/SmartMappingSliderViewModel';
import SmartMappingSliderViewModelGenerated from './smartMappingSliderViewModel.gb';

export default class SmartMappingSliderViewModelWrapper extends SmartMappingSliderViewModelGenerated {

    constructor(component: SmartMappingSliderViewModel) {
        super(component);
    }

}

export async function buildJsSmartMappingSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSmartMappingSliderViewModelGenerated} = await import('./smartMappingSliderViewModel.gb');
    return await buildJsSmartMappingSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSmartMappingSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetSmartMappingSliderViewModelGenerated} = await import('./smartMappingSliderViewModel.gb');
    return await buildDotNetSmartMappingSliderViewModelGenerated(jsObject);
}
