// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file

import {
    buildJsPortalFolder
} from './jsBuilder.gb';
import {
    buildJsPortalItem
} from './jsBuilder';

import PortalUser from '@arcgis/core/portal/PortalUser';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class PortalUserGenerated implements IPropertyWrapper {
    public component: PortalUser;

    constructor(component: PortalUser) {
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
    
    async addItem(item: any,
        data: any,
        folder: any): Promise<any> {
        let jsItem = await buildJsPortalItem(item) as any;
        let result = await this.component.addItem(jsItem,
            data,
            folder);
        return await createGeoBlazorObject(result);
    }

    async deleteItem(item: any,
        permanentDelete: any): Promise<any> {
        let jsItem = await buildJsPortalItem(item) as any;
        return await this.component.deleteItem(jsItem,
            permanentDelete);
    }

    async deleteItems(items: any,
        permanentDelete: any): Promise<any> {
        let jsItems = await buildJsPortalItem(items) as any;
        let result = await this.component.deleteItems(jsItems,
            permanentDelete);
        return await createGeoBlazorObject(result);
    }

    async fetchFolders(): Promise<any> {
        let result = await this.component.fetchFolders();
        return await createGeoBlazorObject(result);
    }

    async fetchGroups(): Promise<any> {
        let result = await this.component.fetchGroups();
        return await createGeoBlazorObject(result);
    }

    async fetchItems(folder: any,
        inRecycleBin: any,
        includeSubfolderItems: any,
        num: any,
        sortField: any,
        sortOrder: any,
        start: any): Promise<any> {
        let jsFolder = await buildJsPortalFolder(folder) as any;
        let result = await this.component.fetchItems(jsFolder,
            inRecycleBin,
            includeSubfolderItems,
            num,
            sortField,
            sortOrder,
            start);
        return await createGeoBlazorObject(result);
    }

    async fetchTags(): Promise<any> {
        return await this.component.fetchTags();
    }

    async getThumbnailUrl(width: any): Promise<any> {
        return this.component.getThumbnailUrl(width);
    }

    async queryFavorites(queryParams: any): Promise<any> {
        let result = await this.component.queryFavorites(queryParams);
        return await createGeoBlazorObject(result);
    }

    async restoreItem(item: any,
        folder: any): Promise<any> {
        let jsItem = await buildJsPortalItem(item) as any;
        let jsFolder = await buildJsPortalFolder(folder) as any;
        return await this.component.restoreItem(jsItem,
            jsFolder);
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
