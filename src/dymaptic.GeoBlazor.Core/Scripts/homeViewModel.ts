// override generated code in this file
import HomeViewModelGenerated from './homeViewModel.gb';
import HomeViewModel from '@arcgis/core/widgets/Home/HomeViewModel';

export default class HomeViewModelWrapper extends HomeViewModelGenerated {

    constructor(component: HomeViewModel) {
        super(component);
    }
    
}

export async function buildJsHomeViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHomeViewModelGenerated } = await import('./homeViewModel.gb');
    return await buildJsHomeViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHomeViewModel(jsObject: any): Promise<any> {
    let { buildDotNetHomeViewModelGenerated } = await import('./homeViewModel.gb');
    return await buildDotNetHomeViewModelGenerated(jsObject);
}
