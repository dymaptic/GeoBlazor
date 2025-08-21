// override generated code in this file
import HomeViewModelGenerated from './homeViewModel.gb';
import HomeViewModel from '@arcgis/core/widgets/Home/HomeViewModel';

export default class HomeViewModelWrapper extends HomeViewModelGenerated {

    constructor(component: HomeViewModel) {
        super(component);
    }

}

export async function buildJsHomeViewModel(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsHomeViewModelGenerated} = await import('./homeViewModel.gb');
    return await buildJsHomeViewModelGenerated(dotNetObject, viewId);
}

export async function buildDotNetHomeViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetHomeViewModelGenerated} = await import('./homeViewModel.gb');
    return await buildDotNetHomeViewModelGenerated(jsObject, viewId);
}
