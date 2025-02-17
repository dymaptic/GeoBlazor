import Search from '@arcgis/core/widgets/Search';
import {IPropertyWrapper} from './definitions';
import { buildJsGeometry } from './geometry';


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
    async getActiveSource() {
        let jsSource = this.searchWidget.activeSource;
        let { buildDotNetSearchSource } = await import('./searchSource');
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
        let { buildDotNetSearchSource } = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    async getDefaultSources() {
        let jsSources = this.searchWidget.defaultSources;
        let dotNetSources: any[] = [];
        let { buildDotNetSearchSource } = await import('./searchSource');
        for (let jsSource of jsSources) {
            dotNetSources.push(buildDotNetSearchSource(jsSource));
        }
        
        return dotNetSources;
    }
    
    async getResultGraphic() {
        let { buildDotNetGraphic } = await import('./graphic');
        return buildDotNetGraphic(this.searchWidget.resultGraphic, null, null);
    }
    
    async getResults() {
        let jsResults = this.searchWidget.results;
        let dnResults: any[] = [];
        for (let jsResult of jsResults) {
            let searchResults: any[] = [];
            let { buildDotNetSearchResult } = await import('./searchResult');
            let { buildDotNetSearchSource } = await import('./searchSource');
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
        let { buildDotNetSearchResult } = await import('./searchResult');
        return buildDotNetSearchResult(this.searchWidget.selectedResult);
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

    getProperty(prop: string) {
        return this.searchWidget[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.searchWidget[prop].addMany(value);
        } else {
            this.searchWidget[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.searchWidget[prop].removeMany(value);
        } else {
            this.searchWidget[prop].remove(value);
        }
    }
}