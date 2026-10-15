// override generated code in this file
import SmartMappingPrimaryHandleSliderViewModelGenerated from './smartMappingPrimaryHandleSliderViewModel.gb';
import SmartMappingPrimaryHandleSliderViewModel from '@arcgis/core/widgets/smartMapping/SmartMappingPrimaryHandleSliderViewModel';

export default class SmartMappingPrimaryHandleSliderViewModelWrapper extends SmartMappingPrimaryHandleSliderViewModelGenerated {

    constructor(component: SmartMappingPrimaryHandleSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsSmartMappingPrimaryHandleSliderViewModel(dotNetObject: any): Promise<any> {
    let { buildJsSmartMappingPrimaryHandleSliderViewModelGenerated } = await import('./smartMappingPrimaryHandleSliderViewModel.gb');
    return await buildJsSmartMappingPrimaryHandleSliderViewModelGenerated(dotNetObject);
}     

export async function buildDotNetSmartMappingPrimaryHandleSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetSmartMappingPrimaryHandleSliderViewModelGenerated } = await import('./smartMappingPrimaryHandleSliderViewModel.gb');
    return await buildDotNetSmartMappingPrimaryHandleSliderViewModelGenerated(jsObject);
}
