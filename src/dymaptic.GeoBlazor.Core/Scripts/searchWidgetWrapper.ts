import Search from "@arcgis/core/widgets/Search";
import {
    buildDotNetGraphic,
    buildDotNetSearchResult,
    buildDotNetSearchSource,
    buildDotNetSuggestResult
} from "./dotNetBuilder";


export default class SearchWidgetWrapper {
    private search: Search;

    constructor(search: Search) {
        this.search = search;
        // set all properties from graphic
        for (let prop in search) {
            if (prop.hasOwnProperty(prop)) {
                this[prop] = search[prop];
            }
        }
    }

    getActiveSource() {
        let jsSource = this.search.activeSource;
        return buildDotNetSearchSource(jsSource);
    }
    
    getActiveMenu() {
        return this.search.activeMenu;
    }
    
    getActiveSourceIndex(): number {
        return this.search.activeSourceIndex;
    }
    
    getAllSources() {
        let jsSources = this.search.allSources;
        let dotNetSources: any[] = [];
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    getDefaultSources() {
        let jsSources = this.search.defaultSources;
        let dotNetSources: any[] = [];
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    getResultGraphic() {
        return buildDotNetGraphic(this.search.resultGraphic);
    }
    
    getResults() {
        let jsResults = this.search.results;
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
        return buildDotNetSearchResult(this.search.selectedResult);
    }
    
    getSuggestions() {
        let jsSuggestions = this.search.suggestions;
        let dnSuggestions: any[] = [];
        for (let jsSuggestion of jsSuggestions) {
            dnSuggestions.push(buildDotNetSuggestResult(jsSuggestion));
        }
        
        return dnSuggestions;
    }
}