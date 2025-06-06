// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import BasemapGalleryViewModel from '@arcgis/core/widgets/BasemapGallery/BasemapGalleryViewModel';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class BasemapGalleryViewModelGenerated implements IPropertyWrapper {
    public component: BasemapGalleryViewModel;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: BasemapGalleryViewModel) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.activeBasemap)) {
            let { buildJsBasemap } = await import('./basemap');
            this.component.activeBasemap = await buildJsBasemap(dotNetObject.activeBasemap, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.source)) {
            let { buildJsIBasemapGalleryWidgetSource } = await import('./iBasemapGalleryWidgetSource');
            this.component.source = await buildJsIBasemapGalleryWidgetSource(dotNetObject.source, this.layerId, this.viewId) as any;
        }

    }
    
    async basemapEquals(basemap1: any,
        basemap2: any): Promise<any> {
        let { buildJsBasemap } = await import('./basemap');
        let jsBasemap1 = await buildJsBasemap(basemap1, this.layerId, this.viewId) as any;
        let jsBasemap2 = await buildJsBasemap(basemap2, this.layerId, this.viewId) as any;
        return this.component.basemapEquals(jsBasemap1,
            jsBasemap2);
    }

    // region properties
    
    async getActiveBasemap(): Promise<any> {
        if (!hasValue(this.component.activeBasemap)) {
            return null;
        }
        
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.component.activeBasemap);
    }
    
    async setActiveBasemap(value: any): Promise<void> {
        let { buildJsBasemap } = await import('./basemap');
        this.component.activeBasemap = await  buildJsBasemap(value, this.layerId, this.viewId);
    }
    
    async getItems(): Promise<any> {
        if (!hasValue(this.component.items)) {
            return null;
        }
        
        let { buildDotNetBasemapGalleryItem } = await import('./basemapGalleryItem');
        return await Promise.all(this.component.items!.map(async i => await buildDotNetBasemapGalleryItem(i)));
    }
    
    async getSource(): Promise<any> {
        if (!hasValue(this.component.source)) {
            return null;
        }
        
        let { buildDotNetIBasemapGalleryWidgetSource } = await import('./iBasemapGalleryWidgetSource');
        return await buildDotNetIBasemapGalleryWidgetSource(this.component.source);
    }
    
    async setSource(value: any): Promise<void> {
        let { buildJsIBasemapGalleryWidgetSource } = await import('./iBasemapGalleryWidgetSource');
        this.component.source = await  buildJsIBasemapGalleryWidgetSource(value, this.layerId, this.viewId);
    }
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsBasemapGalleryViewModelGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(viewId)) {
        properties.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.activeBasemap)) {
        let { buildJsBasemap } = await import('./basemap');
        properties.activeBasemap = await buildJsBasemap(dotNetObject.activeBasemap, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.source)) {
        let { buildJsIBasemapGalleryWidgetSource } = await import('./iBasemapGalleryWidgetSource');
        properties.source = await buildJsIBasemapGalleryWidgetSource(dotNetObject.source, layerId, viewId) as any;
    }

    let jsBasemapGalleryViewModel = new BasemapGalleryViewModel(properties);

    let { default: BasemapGalleryViewModelWrapper } = await import('./basemapGalleryViewModel');
    let basemapGalleryViewModelWrapper = new BasemapGalleryViewModelWrapper(jsBasemapGalleryViewModel);
    basemapGalleryViewModelWrapper.geoBlazorId = dotNetObject.id;
    basemapGalleryViewModelWrapper.viewId = viewId;
    basemapGalleryViewModelWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = basemapGalleryViewModelWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBasemapGalleryViewModel;
    
    return jsBasemapGalleryViewModel;
}


export async function buildDotNetBasemapGalleryViewModelGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBasemapGalleryViewModel: any = {};
    
    if (hasValue(jsObject.items)) {
        let { buildDotNetBasemapGalleryItem } = await import('./basemapGalleryItem');
        dotNetBasemapGalleryViewModel.items = await Promise.all(jsObject.items.map(async i => await buildDotNetBasemapGalleryItem(i)));
    }
    
    if (hasValue(jsObject.activeBasemapIndex)) {
        dotNetBasemapGalleryViewModel.activeBasemapIndex = jsObject.activeBasemapIndex;
    }
    
    if (hasValue(jsObject.state)) {
        dotNetBasemapGalleryViewModel.state = removeCircularReferences(jsObject.state);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBasemapGalleryViewModel.id = geoBlazorId;
    }

    return dotNetBasemapGalleryViewModel;
}

