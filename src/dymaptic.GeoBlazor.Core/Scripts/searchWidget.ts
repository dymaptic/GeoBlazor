import widgetsSearch from '@arcgis/core/widgets/Search';
import Search from '@arcgis/core/widgets/Search';
import SearchWidgetGenerated from './searchWidget.gb';
import {buildJsGeometry} from './geometry';
import {buildDotNetExtent} from "./extent";


export default class SearchWidgetWrapper extends SearchWidgetGenerated {
    private searchWidget: Search;

    constructor(search: Search) {
        super(search);
        this.searchWidget = search;
    }

    async getActiveSource() {
        let jsSource = this.searchWidget.activeSource;
        let {buildDotNetSearchSource} = await import('./searchSource');
        return buildDotNetSearchSource(jsSource);
    }

    getActiveMenu() {
        return this.searchWidget.activeMenu;
    }

    getActiveSourceIndex(): number {
        return this.searchWidget.activeSourceIndex;
    }

    async getAllSources() {
        let jsSources = this.searchWidget.allSources;
        let dotNetSources: any[] = [];
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }

        return dotNetSources;
    }

    async getDefaultSources() {
        let jsSources = this.searchWidget.defaultSources;
        let dotNetSources: any[] = [];
        let {buildDotNetSearchSource} = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }

        return dotNetSources;
    }

    async getResultGraphic() {
        let {buildDotNetGraphic} = await import('./graphic');
        return buildDotNetGraphic(this.searchWidget.resultGraphic, null, null);
    }

    async getResults() {
        let jsResults = this.searchWidget.results;
        let dnResults: any[] = [];
        for (let jsResult of jsResults) {
            let searchResults: any[] = [];
            let {buildDotNetSearchResult} = await import('./searchResult');
            let {buildDotNetSearchSource} = await import('./searchSource');
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

        return dnResults;
    }

    async getSelectedResult() {
        let {buildDotNetSearchResult} = await import('./searchResult');
        return buildDotNetSearchResult(this.searchWidget.selectedResult);
    }

    setSearchTerm(term: string) {
        this.searchWidget.searchTerm = term;
    }

    getSearchTerm() {
        return this.searchWidget.searchTerm;
    }

    async search(term: any) {
        if (term.hasOwnProperty('id') && term.hasOwnProperty('type')) {
            // if there's an id, this is probably a geometry, we should convert it
            term = buildJsGeometry(term);
        }
        let response = await this.searchWidget.search(term);
        let {buildDotNetSearchResponse} = await import('./searchResponse');
        let dnresponse = await buildDotNetSearchResponse(response);
        return dnresponse;
    }

    suggest(term: string) {
        return this.searchWidget.suggest(term);
    }


}

export async function buildJsSearchWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchWidgetGenerated} = await import('./searchWidget.gb');
    let jsSearch = await buildJsSearchWidgetGenerated(dotNetObject, layerId, viewId);
    
    // obsolete/deprecated call for backwards compatibility
    jsSearch.on('select-result', async (evt) => {
        const {buildDotNetGraphic} = await import('./graphic');
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJavaScriptSearchSelectResult', {
            extent: buildDotNetExtent(evt.result.extent),
            feature: buildDotNetGraphic(evt.result.feature, null, viewId),
            name: evt.result.name
        });
    });
    
    return jsSearch;
}

export async function buildDotNetSearchWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSearchWidgetGenerated} = await import('./searchWidget.gb');
    return await buildDotNetSearchWidgetGenerated(jsObject, layerId, viewId);
}
