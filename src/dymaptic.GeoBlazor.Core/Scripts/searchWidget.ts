import widgetsSearch from '@arcgis/core/widgets/Search';
import Search from '@arcgis/core/widgets/Search';
import SearchWidgetGenerated from './searchWidget.gb';
import {buildJsGeometry} from './geometry';
import {buildEncodedJson, buildJsStreamReference, hasValue} from './geoBlazorCore';
import {buildDotNetSearchResult, buildJsSearchResult} from "./searchResult";
import {buildDotNetSearchSource, buildJsSearchSource} from "./searchSource";


export default class SearchWidgetWrapper extends SearchWidgetGenerated {

    constructor(search: Search) {
        super(search);
    }

    async getActiveSource() {
        let jsSource = this.widget.activeSource;
        let {buildDotNetSearchSource} = await import('./searchSource');
        let dnSource = await buildDotNetSearchSource(jsSource, this.viewId);
        let encodedJson = buildEncodedJson(dnSource);
        return encodedJson;
    }

    getActiveMenu() {
        return this.widget.activeMenu;
    }

    getActiveSourceIndex(): number {
        return this.widget.activeSourceIndex;
    }

    async getAllSources() {
        let jsSources = this.widget.allSources;
        let dotNetSources: any[] = [];
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(await buildDotNetSearchSource(jsSource, this.viewId));
        }

        let encodedJson = buildEncodedJson(dotNetSources);
        return encodedJson;
    }

    async getDefaultSources() {
        let jsSources = this.widget.defaultSources;
        let dotNetSources: any[] = [];
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(await buildDotNetSearchSource(jsSource, this.viewId));
        }

        return dotNetSources;
    }

    async getResultGraphic() {
        let {buildDotNetGraphic} = await import('./graphic');
        return buildDotNetGraphic(this.widget.resultGraphic!, null, this.viewId);
    }

    async getResults() {
        let jsResults = this.widget.results;
        let dnResults: any[] = [];
        let {buildDotNetSearchResult} = await import('./searchResult');
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsResult of jsResults!) {
            let searchResults: any[] = [];
            for (let jsSearchResult of jsResult.results) {
                searchResults.push(buildDotNetSearchResult(jsSearchResult, this.layerId, this.viewId));
            }
            let dnResult = {
                results: searchResults,
                source: await buildDotNetSearchSource(jsResult.source, this.viewId),
                sourceIndex: jsResult.sourceIndex
            }
            dnResults.push(dnResult);
        }

        let encodedJson = buildEncodedJson(dnResults);
        return encodedJson;
    }

    async getSelectedResult() {
        let {buildDotNetSearchResult} = await import('./searchResult');
        let dnResponse = buildDotNetSearchResult(this.widget.selectedResult, this.layerId, this.viewId);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }

    async getSources(): Promise<any> {
        if (!hasValue(this.widget.sources)) {
            return null;
        }

        let { buildDotNetSearchSource } = await import('./searchSource');
        let dnSources = await Promise.all(this.widget.sources.map(async i => await buildDotNetSearchSource(i, this.viewId)));
        let encodedJson = buildEncodedJson(dnSources);
        return encodedJson;
    }

    setSearchTerm(term: string) {
        this.widget.searchTerm = term;
    }

    getSearchTerm() {
        return this.widget.searchTerm;
    }

    async search(term: any) {
        if (term.hasOwnProperty('id') && term.hasOwnProperty('type')) {
            // if there's an id, this is probably a geometry, we should convert it
            term = buildJsGeometry(term);
        }
        let response = await this.widget.search(term);
        let {buildDotNetSearchResponse} = await import('./searchResponse');
        let dnResponse = await buildDotNetSearchResponse(response, this.viewId);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }

    async suggest(term: string) {
        let result = await this.widget.suggest(term);
        let {buildDotNetSuggestResponse} = await import('./suggestResponse');
        let dnResponse = await buildDotNetSuggestResponse(result, this.viewId);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }

    async getSuggestions() {
        if (!hasValue(this.widget.suggestions)) {
            return null;
        }
        let jsSuggestions = this.widget.suggestions;
        let dotNetSuggestions: any[] = [];
        let {buildDotNetSuggestResult} = await import('./suggestResult');
        for (let jsSuggestion of jsSuggestions!) {
            dotNetSuggestions.push(buildDotNetSuggestResult(jsSuggestion));
        }

        let encodedJson = buildEncodedJson(dotNetSuggestions);
        return encodedJson;
    }
}

export async function buildJsSearchWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchWidgetGenerated} = await import('./searchWidget.gb');
    let jswidgetsSearch = await buildJsSearchWidgetGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.hasSearchCompleteListener) && dotNetObject.hasSearchCompleteListener) {
        jswidgetsSearch.on('search-complete', async (evt: any) => {
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
                })) : null,
            }
            let streamRef = buildJsStreamReference(dotNetEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSearchComplete', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasSelectResultListener) && dotNetObject.hasSelectResultListener) {
        jswidgetsSearch.on('select-result', async (evt: any) => {
            let dotNetEvent = {
                result: evt.result ? await buildDotNetSearchResult(evt.result, layerId, viewId) : null,
                source: evt.source ? await buildDotNetSearchSource(evt.source, viewId) : null,
                sourceIndex: evt.sourceIndex
            }
            let streamRef = buildJsStreamReference(dotNetEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSelectResult', streamRef);
        });
    }
    
    return jswidgetsSearch;
}

export async function buildDotNetSearchWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchWidgetGenerated} = await import('./searchWidget.gb');
    return await buildDotNetSearchWidgetGenerated(jsObject, layerId, viewId);
}
