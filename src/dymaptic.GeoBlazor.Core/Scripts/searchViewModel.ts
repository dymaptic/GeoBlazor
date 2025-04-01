import SearchViewModel from '@arcgis/core/widgets/Search/SearchViewModel';
import SearchViewModelGenerated from './searchViewModel.gb';

export default class SearchViewModelWrapper extends SearchViewModelGenerated {

    constructor(component: SearchViewModel) {
        super(component);
    }

}

export async function buildJsSearchViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelGenerated} = await import('./searchViewModel.gb');
    return await buildJsSearchViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelGenerated} = await import('./searchViewModel.gb');
    return await buildDotNetSearchViewModelGenerated(jsObject, layerId, viewId);
}
