import ScaleBarViewModel from '@arcgis/core/widgets/ScaleBar/ScaleBarViewModel';
import ScaleBarViewModelGenerated from './scaleBarViewModel.gb';

export async function buildJsScaleBarViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleBarViewModelGenerated } = await import('./scaleBarViewModel.gb');
    return await buildJsScaleBarViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleBarViewModel(jsObject: any): Promise<any> {
    let { buildDotNetScaleBarViewModelGenerated } = await import('./scaleBarViewModel.gb');
    return await buildDotNetScaleBarViewModelGenerated(jsObject);
}

export default class ScaleBarViewModelWrapper extends ScaleBarViewModelGenerated {

    constructor(component: ScaleBarViewModel) {
        super(component);
    }
    
}

