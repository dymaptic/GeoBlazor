// override generated code in this file
import SmartMappingSliderViewModelGenerated from './smartMappingSliderViewModel.gb';
import SmartMappingSliderViewModel from '@arcgis/core/widgets/smartMapping/SmartMappingSliderViewModel';

export default class SmartMappingSliderViewModelWrapper extends SmartMappingSliderViewModelGenerated {

    constructor(component: SmartMappingSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsSmartMappingSliderViewModel(dotNetObject: any): Promise<any> {
    let { buildJsSmartMappingSliderViewModelGenerated } = await import('./smartMappingSliderViewModel.gb');
    return await buildJsSmartMappingSliderViewModelGenerated(dotNetObject);
}     

export async function buildDotNetSmartMappingSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetSmartMappingSliderViewModelGenerated } = await import('./smartMappingSliderViewModel.gb');
    return await buildDotNetSmartMappingSliderViewModelGenerated(jsObject);
}
