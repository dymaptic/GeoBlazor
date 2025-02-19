// override generated code in this file
import TimeSliderViewModelGenerated from './timeSliderViewModel.gb';
import TimeSliderViewModel from '@arcgis/core/widgets/TimeSlider/TimeSliderViewModel';

export default class TimeSliderViewModelWrapper extends TimeSliderViewModelGenerated {

    constructor(component: TimeSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsTimeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeSliderViewModelGenerated } = await import('./timeSliderViewModel.gb');
    return await buildJsTimeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetTimeSliderViewModelGenerated } = await import('./timeSliderViewModel.gb');
    return await buildDotNetTimeSliderViewModelGenerated(jsObject);
}
