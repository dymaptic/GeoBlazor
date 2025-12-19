import SearchViewModel from '@arcgis/core/widgets/Search/SearchViewModel';
import SearchViewModelGenerated from './searchViewModel.gb';
import {buildJsStreamReference, hasValue} from "./geoBlazorCore";
import {buildDotNetSearchResult} from "./searchResult";
import {buildDotNetSearchSource} from "./searchSource";

export default class SearchViewModelWrapper extends SearchViewModelGenerated {

    constructor(component: SearchViewModel) {
        super(component);
    }

}

export async function buildJsSearchViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelGenerated} = await import('./searchViewModel.gb');
    let jsSearchViewModel = await buildJsSearchViewModelGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.hasSearchCompleteListener) && dotNetObject.hasSearchCompleteListener) {
        jsSearchViewModel.on('search-complete', async (evt: any) => {
            let dotNetEvent = {
                activeSourceIndex: evt.activeSourceIndex,
                errors: evt.errors,
                numResults: evt.numResults,
                searchTerm: evt.searchTerm,
                results: evt.results ? await Promise.all(evt.results.map(async r => {
                    return {
                        results: r.results?.map(rr => buildDotNetSearchResult(rr, layerId, viewId)),
                        sourceIndex: r.sourceIndex,
                        source: r.source ? await buildDotNetSearchSource(r.source, viewId) : null
                    };
                })): null,
            }
            let streamRef = buildJsStreamReference(dotNetEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSearchComplete', streamRef);
        });
    }

    if (hasValue(dotNetObject.hasSelectResultListener) && dotNetObject.hasSelectResultListener) {
        jsSearchViewModel.on('select-result', async (evt: any) => {
            let dotNetEvent = {
                result: evt.result ? await buildDotNetSearchResult(evt.result, layerId, viewId) : null,
                source: evt.source ? await buildDotNetSearchSource(evt.source, viewId) : null,
                sourceIndex: evt.sourceIndex
            }
            let streamRef = buildJsStreamReference(dotNetEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSelectResult', streamRef);
        });
    }

    if (hasValue(dotNetObject.hasSuggestCompleteListener) && dotNetObject.hasSuggestCompleteListener) {
        jsSearchViewModel.on('suggest-complete', async (evt: any) => {
            let { buildDotNetSearchSuggestCompleteEvent } = await import('./searchSuggestCompleteEvent');
            let dnEvent = await buildDotNetSearchSuggestCompleteEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSuggestComplete', streamRef);
        });
    }
    
    return jsSearchViewModel;
}

export async function buildDotNetSearchViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelGenerated} = await import('./searchViewModel.gb');
    return await buildDotNetSearchViewModelGenerated(jsObject, layerId, viewId);
}
