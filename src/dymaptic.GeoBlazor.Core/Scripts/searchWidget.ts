import widgetsSearch from '@arcgis/core/widgets/Search';
import Search from '@arcgis/core/widgets/Search';
import SearchWidgetGenerated from './searchWidget.gb';
import {buildJsGeometry} from './geometry';
import {buildEncodedJson, hasValue} from "./arcGisJsInterop";


export default class SearchWidgetWrapper extends SearchWidgetGenerated {

    constructor(search: Search) {
        super(search);
    }

    async getActiveSource() {
        let jsSource = this.widget.activeSource;
        let {buildDotNetSearchSource} = await import('./searchSource');
        let dnSource = buildDotNetSearchSource(jsSource);
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
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }

        let encodedJson = buildEncodedJson(dotNetSources);
        return encodedJson;
    }

    async getDefaultSources() {
        let jsSources = this.widget.defaultSources;
        let dotNetSources: any[] = [];
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }

        return dotNetSources;
    }

    async getResultGraphic() {
        let {buildDotNetGraphic} = await import('./graphic');
        return buildDotNetGraphic(this.widget.resultGraphic, null, null);
    }

    async getResults() {
        let jsResults = this.widget.results;
        let dnResults: any[] = [];
        let {buildDotNetSearchResult} = await import('./searchResult');
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsResult of jsResults) {
            let searchResults: any[] = [];
            for (let jsSearchResult of jsResult.results) {
                searchResults.push(buildDotNetSearchResult(jsSearchResult));
            }
            let dnResult = {
                results: searchResults,
                source: buildDotNetSearchSource(jsResult.source),
                sourceIndex: jsResult.sourceIndex
            }
            dnResults.push(dnResult);
        }

        let encodedJson = buildEncodedJson(dnResults);
        return encodedJson;
    }

    async getSelectedResult() {
        let {buildDotNetSearchResult} = await import('./searchResult');
        let dnResponse = buildDotNetSearchResult(this.widget.selectedResult);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }

    async getSources(): Promise<any> {
        if (!hasValue(this.widget.sources)) {
            return null;
        }

        let { buildDotNetSearchSource } = await import('./searchSource');
        let dnSources = await Promise.all(this.widget.sources.map(async i => await buildDotNetSearchSource(i)));
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
        let dnResponse = await buildDotNetSearchResponse(response);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }

    async suggest(term: string) {
        let result = await this.widget.suggest(term);
        let {buildDotNetSuggestResponse} = await import('./suggestResponse');
        let dnResponse = await buildDotNetSuggestResponse(result);
        let encodedJson = buildEncodedJson(dnResponse);
        return encodedJson;
    }


}

export async function buildJsSearchWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchWidgetGenerated} = await import('./searchWidget.gb');
    return await buildJsSearchWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchWidgetGenerated} = await import('./searchWidget.gb');
    return await buildDotNetSearchWidgetGenerated(jsObject, layerId, viewId);
}
