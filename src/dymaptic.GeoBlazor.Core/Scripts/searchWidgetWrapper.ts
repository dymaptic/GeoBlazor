import Search from "@arcgis/core/widgets/Search";
import {
    buildDotNetGraphic,
    buildDotNetSearchResult,
    buildDotNetSearchSource,
    buildDotNetSuggestResult
} from "./dotNetBuilder";
import {buildJsGeometry} from "./jsBuilder";
import {IPropertyWrapper} from "./definitions";


export default class SearchWidgetWrapper implements IPropertyWrapper {
    private searchWidget: Search;

    constructor(search: Search) {
        this.searchWidget = search;
        // set all properties from graphic
        for (let prop in search) {
            if (prop.hasOwnProperty(prop)) {
                this[prop] = search[prop];
            }
        }
    }

    unwrap() {
        return this.searchWidget;
    }
    getActiveSource() {
        let jsSource = this.searchWidget.activeSource;
        return buildDotNetSearchSource(jsSource);
    }
    
    getActiveMenu() {
        return this.searchWidget.activeMenu;
    }
    
    getActiveSourceIndex(): number {
        return this.searchWidget.activeSourceIndex;
    }
    
    getAllSources() {
        let jsSources = this.searchWidget.allSources;
        let dotNetSources: any[] = [];
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    getDefaultSources() {
        let jsSources = this.searchWidget.defaultSources;
        let dotNetSources: any[] = [];
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    getResultGraphic() {
        return buildDotNetGraphic(this.searchWidget.resultGraphic);
    }
    
    getResults() {
        let jsResults = this.searchWidget.results;
        let dnResults: any[] = [];
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
        
        return dnResults;
    }
    
    getSelectedResult() {
        return buildDotNetSearchResult(this.searchWidget.selectedResult);
    }
    
    getSuggestions() {
        let jsSuggestions = this.searchWidget.suggestions;
        let dnSuggestions: any[] = [];
        for (let jsSuggestion of jsSuggestions) {
            dnSuggestions.push(buildDotNetSuggestResult(jsSuggestion));
        }
        
        return dnSuggestions;
    }
    
    setSearchTerm(term: string) {
        this.searchWidget.searchTerm = term;
    }
    
    getSearchTerm() {
        return this.searchWidget.searchTerm;
    }
    
    search(term: any) {
        if (term.hasOwnProperty('id') && term.hasOwnProperty('type')) {
            // if there's an id, this is probably a geometry, we should convert it
            term = buildJsGeometry(term);
        }
        return this.searchWidget.search(term);
    }
    
    suggest(term: string) {
        return this.searchWidget.suggest(term);
    }

    setProperty(prop: string, value: any): void {
        this.searchWidget[prop] = value;
    }
}