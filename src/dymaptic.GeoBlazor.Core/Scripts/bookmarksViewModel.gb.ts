// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import BookmarksViewModel from '@arcgis/core/widgets/Bookmarks/BookmarksViewModel';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class BookmarksViewModelGenerated implements IPropertyWrapper {
    public component: BookmarksViewModel;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: BookmarksViewModel) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.bookmarks) && dotNetObject.bookmarks.length > 0) {
            let { buildJsBookmark } = await import('./bookmark');
            this.component.bookmarks = await Promise.all(dotNetObject.bookmarks.map(async i => await buildJsBookmark(i))) as any;
        }
        if (hasValue(dotNetObject.capabilities)) {
            let { buildJsBookmarksCapabilities } = await import('./bookmarksCapabilities');
            this.component.capabilities = await buildJsBookmarksCapabilities(dotNetObject.capabilities) as any;
        }
        if (hasValue(dotNetObject.defaultCreateOptions)) {
            let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
            this.component.defaultCreateOptions = await buildJsBookmarkOptions(dotNetObject.defaultCreateOptions, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.defaultEditOptions)) {
            let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
            this.component.defaultEditOptions = await buildJsBookmarkOptions(dotNetObject.defaultEditOptions, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.goToOverride)) {
            let { buildJsGoToOverride } = await import('./goToOverride');
            this.component.goToOverride = buildJsGoToOverride(dotNetObject.goToOverride, this.viewId) as any;
        }

    }
    
    async createBookmark(options: any): Promise<any> {
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        let jsOptions = await buildJsBookmarkOptions(options, this.layerId, this.viewId) as any;
        return await this.component.createBookmark(jsOptions);
    }

    async editBookmark(bookmark: any,
        options: any): Promise<any> {
        let { buildJsBookmark } = await import('./bookmark');
        let jsBookmark = await buildJsBookmark(bookmark) as any;
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        let jsOptions = await buildJsBookmarkOptions(options, this.layerId, this.viewId) as any;
        return await this.component.editBookmark(jsBookmark,
            jsOptions);
    }

    async goTo(bookmark: any): Promise<any> {
        let { buildJsBookmark } = await import('./bookmark');
        let jsBookmark = await buildJsBookmark(bookmark) as any;
        let result = await this.component.goTo(jsBookmark);
        
        return generateSerializableJson(result);
    }

    // region properties
    
    async getActiveBookmark(): Promise<any> {
        if (!hasValue(this.component.activeBookmark)) {
            return null;
        }
        
        let { buildDotNetBookmark } = await import('./bookmark');
        return await buildDotNetBookmark(this.component.activeBookmark);
    }
    
    async getBookmarks(): Promise<any> {
        if (!hasValue(this.component.bookmarks)) {
            return null;
        }
        
        let { buildDotNetBookmark } = await import('./bookmark');
        return await Promise.all(this.component.bookmarks!.map(async i => await buildDotNetBookmark(i)));
    }
    
    async setBookmarks(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.component.bookmarks = [];
        }
        let { buildJsBookmark } = await import('./bookmark');
        this.component.bookmarks = await Promise.all(value.map(async i => await buildJsBookmark(i))) as any;
    }
    
    async getCapabilities(): Promise<any> {
        if (!hasValue(this.component.capabilities)) {
            return null;
        }
        
        let { buildDotNetBookmarksCapabilities } = await import('./bookmarksCapabilities');
        return await buildDotNetBookmarksCapabilities(this.component.capabilities);
    }
    
    async setCapabilities(value: any): Promise<void> {
        let { buildJsBookmarksCapabilities } = await import('./bookmarksCapabilities');
        this.component.capabilities = await  buildJsBookmarksCapabilities(value);
    }
    
    async getDefaultCreateOptions(): Promise<any> {
        if (!hasValue(this.component.defaultCreateOptions)) {
            return null;
        }
        
        let { buildDotNetBookmarkOptions } = await import('./bookmarkOptions');
        return await buildDotNetBookmarkOptions(this.component.defaultCreateOptions);
    }
    
    async setDefaultCreateOptions(value: any): Promise<void> {
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        this.component.defaultCreateOptions = await  buildJsBookmarkOptions(value, this.layerId, this.viewId);
    }
    
    async getDefaultEditOptions(): Promise<any> {
        if (!hasValue(this.component.defaultEditOptions)) {
            return null;
        }
        
        let { buildDotNetBookmarkOptions } = await import('./bookmarkOptions');
        return await buildDotNetBookmarkOptions(this.component.defaultEditOptions);
    }
    
    async setDefaultEditOptions(value: any): Promise<void> {
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        this.component.defaultEditOptions = await  buildJsBookmarkOptions(value, this.layerId, this.viewId);
    }
    
    async getGoToOverride(): Promise<any> {
        if (!hasValue(this.component.goToOverride)) {
            return null;
        }
        
        let { buildDotNetGoToOverride } = await import('./goToOverride');
        return await buildDotNetGoToOverride(this.component.goToOverride);
    }
    
    async setGoToOverride(value: any): Promise<void> {
        let { buildJsGoToOverride } = await import('./goToOverride');
        this.component.goToOverride =  buildJsGoToOverride(value, this.viewId);
    }
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsBookmarksViewModelGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(viewId)) {
        properties.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.bookmarks) && dotNetObject.bookmarks.length > 0) {
        let { buildJsBookmark } = await import('./bookmark');
        properties.bookmarks = await Promise.all(dotNetObject.bookmarks.map(async i => await buildJsBookmark(i))) as any;
    }
    if (hasValue(dotNetObject.capabilities)) {
        let { buildJsBookmarksCapabilities } = await import('./bookmarksCapabilities');
        properties.capabilities = await buildJsBookmarksCapabilities(dotNetObject.capabilities) as any;
    }
    if (hasValue(dotNetObject.defaultCreateOptions)) {
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        properties.defaultCreateOptions = await buildJsBookmarkOptions(dotNetObject.defaultCreateOptions, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.defaultEditOptions)) {
        let { buildJsBookmarkOptions } = await import('./bookmarkOptions');
        properties.defaultEditOptions = await buildJsBookmarkOptions(dotNetObject.defaultEditOptions, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.goToOverride)) {
        let { buildJsGoToOverride } = await import('./goToOverride');
        properties.goToOverride = buildJsGoToOverride(dotNetObject.goToOverride, viewId) as any;
    }

    let jsBookmarksViewModel = new BookmarksViewModel(properties);

    let { default: BookmarksViewModelWrapper } = await import('./bookmarksViewModel');
    let bookmarksViewModelWrapper = new BookmarksViewModelWrapper(jsBookmarksViewModel);
    bookmarksViewModelWrapper.geoBlazorId = dotNetObject.id;
    bookmarksViewModelWrapper.viewId = viewId;
    bookmarksViewModelWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = bookmarksViewModelWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBookmarksViewModel;
    
    return jsBookmarksViewModel;
}


export async function buildDotNetBookmarksViewModelGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBookmarksViewModel: any = {};
    
    if (hasValue(jsObject.activeBookmark)) {
        let { buildDotNetBookmark } = await import('./bookmark');
        dotNetBookmarksViewModel.activeBookmark = await buildDotNetBookmark(jsObject.activeBookmark);
    }
    
    if (hasValue(jsObject.bookmarks)) {
        let { buildDotNetBookmark } = await import('./bookmark');
        dotNetBookmarksViewModel.bookmarks = await Promise.all(jsObject.bookmarks.map(async i => await buildDotNetBookmark(i)));
    }
    
    if (hasValue(jsObject.capabilities)) {
        let { buildDotNetBookmarksCapabilities } = await import('./bookmarksCapabilities');
        dotNetBookmarksViewModel.capabilities = await buildDotNetBookmarksCapabilities(jsObject.capabilities);
    }
    
    if (hasValue(jsObject.defaultCreateOptions)) {
        let { buildDotNetBookmarkOptions } = await import('./bookmarkOptions');
        dotNetBookmarksViewModel.defaultCreateOptions = await buildDotNetBookmarkOptions(jsObject.defaultCreateOptions);
    }
    
    if (hasValue(jsObject.defaultEditOptions)) {
        let { buildDotNetBookmarkOptions } = await import('./bookmarkOptions');
        dotNetBookmarksViewModel.defaultEditOptions = await buildDotNetBookmarkOptions(jsObject.defaultEditOptions);
    }
    
    if (hasValue(jsObject.state)) {
        dotNetBookmarksViewModel.state = removeCircularReferences(jsObject.state);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBookmarksViewModel.id = geoBlazorId;
    }

    return dotNetBookmarksViewModel;
}

