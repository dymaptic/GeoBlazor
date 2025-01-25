// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import Portal from '@arcgis/core/portal/Portal';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class PortalGenerated implements IPropertyWrapper {
    public component: Portal;

    constructor(component: Portal) {
        this.component = component;
        // set all properties from component
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    
    async createElevationLayers(): Promise<any> {
        let result = await this.component.createElevationLayers();
        return await createGeoBlazorObject(result);
    }

    async fetchBasemaps(basemapGalleryGroupQuery: any,
        options: any): Promise<any> {
        let result = await this.component.fetchBasemaps(basemapGalleryGroupQuery,
            options);
        return await createGeoBlazorObject(result);
    }

    async fetchCategorySchema(options: any): Promise<any> {
        return await this.component.fetchCategorySchema(options);
    }

    async fetchFeaturedGroups(options: any): Promise<any> {
        let result = await this.component.fetchFeaturedGroups(options);
        return await createGeoBlazorObject(result);
    }

    async fetchRegions(options: any): Promise<any> {
        return await this.component.fetchRegions(options);
    }

    async fetchSettings(options: any): Promise<any> {
        return await this.component.fetchSettings(options);
    }

    async queryGroups(queryParams: any,
        options: any): Promise<any> {
        let result = await this.component.queryGroups(queryParams,
            options);
        return await createGeoBlazorObject(result);
    }

    async queryItems(queryParams: any,
        options: any): Promise<any> {
        let result = await this.component.queryItems(queryParams,
            options);
        return await createGeoBlazorObject(result);
    }

    async queryUsers(queryParams: any,
        options: any): Promise<any> {
        let result = await this.component.queryUsers(queryParams,
            options);
        return await createGeoBlazorObject(result);
    }

    // region properties
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
    
    addToProperty(prop: string, value: any): void {
        if (Array.isArray(value)) {
            this.component[prop].addMany(value);
        } else {
            this.component[prop].add(value);
        }
    }
    
    removeFromProperty(prop: string, value: any): any {
        if (Array.isArray(value)) {
            this.component[prop].removeMany(value);
        } else {
            this.component[prop].remove(value);
        }
    }
}
