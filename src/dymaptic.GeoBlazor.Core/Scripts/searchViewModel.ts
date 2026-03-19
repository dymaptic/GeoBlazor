import SearchViewModel from '@arcgis/core/widgets/Search/SearchViewModel';
import SearchViewModelGenerated from './searchViewModel.gb';
import { hasValue } from './geoBlazorCore';

export default class SearchViewModelWrapper extends SearchViewModelGenerated {

    constructor(component: SearchViewModel) {
        super(component);
    }

}

export async function buildJsSearchViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelGenerated} = await import('./searchViewModel.gb');
    let jsViewModel = await buildJsSearchViewModelGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.hasIncludeDefaultSourcesFunction) && dotNetObject.hasIncludeDefaultSourcesFunction) {
        jsViewModel.includeDefaultSources = async (options) => {
            let { buildDotNetSearchSource, buildJsSearchSource } = await import('./searchSource');
            let dnSources = await Promise.all(options.sources.map((s) => buildDotNetSearchSource(s, viewId)));
            let dnDefaultSources = await Promise.all(options.defaultSources.map((s) => buildDotNetSearchSource(s, viewId)));
            let dnOptions = {
                sources: dnSources,
                defaultSources: dnDefaultSources
            };

            let dnResult: any[] = await dotNetObject.dotNetComponentReference
                .invokeMethodAsync('OnJsIncludeDefaultSearchSource', dnOptions);
            return await Promise.all(dnResult.map((s) => buildJsSearchSource(s, viewId)));
        }
    } else if (hasValue(dotNetObject.includeDefaultSources)) {
        jsViewModel.includeDefaultSources = dotNetObject.includeDefaultSources;
    }

    return jsViewModel;
}

export async function buildDotNetSearchViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelGenerated} = await import('./searchViewModel.gb');
    let dnViewModel = await buildDotNetSearchViewModelGenerated(jsObject, layerId, viewId);
    if (hasValue(jsObject.includeDefaultSources) && jsObject.includeDefaultSources instanceof Boolean) {
        dnViewModel.includeDefaultSources = jsObject.includeDefaultSources;
    }

    return dnViewModel;
}
