// override generated code in this file
import ElevationProfileViewModelGenerated from './elevationProfileViewModel.gb';
import ElevationProfileViewModel from '@arcgis/core/widgets/ElevationProfile/ElevationProfileViewModel';

export default class ElevationProfileViewModelWrapper extends ElevationProfileViewModelGenerated {

    constructor(component: ElevationProfileViewModel) {
        super(component);
    }
    
}

export async function buildJsElevationProfileViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileViewModelGenerated } = await import('./elevationProfileViewModel.gb');
    return await buildJsElevationProfileViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetElevationProfileViewModelGenerated } = await import('./elevationProfileViewModel.gb');
    return await buildDotNetElevationProfileViewModelGenerated(jsObject, layerId, viewId);
}
