// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import CSVLayer from '@arcgis/core/layers/CSVLayer';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class CSVLayerGenerated implements IPropertyWrapper {
    public layer: CSVLayer;

    constructor(layer: CSVLayer) {
        this.layer = layer;
        // set all properties from layer
        for (let prop in layer) {
            if (layer.hasOwnProperty(prop)) {
                this[prop] = layer[prop];
            }
        }
    }
    
    // region methods
   
    unwrap() {
        return this.layer;
    }
    
    async load(options: AbortSignal): Promise<void> {
        await this.layer.load(options);
    }

    async createLayerView(view: any,
        options: any): Promise<any> {
        let result = await this.layer.createLayerView(view,
            options);
        return await createGeoBlazorObject(result);
    }

    async createPopupTemplate(options: any): Promise<any> {
        let result = this.layer.createPopupTemplate(options);
        return await createGeoBlazorObject(result);
    }

    async createQuery(): Promise<any> {
        let result = this.layer.createQuery();
        return await createGeoBlazorObject(result);
    }

    async fetchAttributionData(): Promise<any> {
        return await this.layer.fetchAttributionData();
    }

    async getField(fieldName: any): Promise<any> {
        let result = this.layer.getField(fieldName);
        return await createGeoBlazorObject(result);
    }

    async getFieldDomain(fieldName: any,
        options: any): Promise<any> {
        let result = this.layer.getFieldDomain(fieldName,
            options);
        return await createGeoBlazorObject(result);
    }

    async queryExtent(query: any,
        options: any): Promise<any> {
        let result = await this.layer.queryExtent(query,
            options);
        return await createGeoBlazorObject(result);
    }

    async queryFeatureCount(query: any,
        options: any): Promise<any> {
        return await this.layer.queryFeatureCount(query,
            options);
    }

    async queryFeatures(query: any,
        options: any): Promise<any> {
        let result = await this.layer.queryFeatures(query,
            options);
        return await createGeoBlazorObject(result);
    }

    async queryObjectIds(query: any,
        options: any): Promise<any> {
        return await this.layer.queryObjectIds(query,
            options);
    }

    async refresh(): Promise<void> {
        this.layer.refresh();
    }

    // region properties
    
    getProperty(prop: string): any {
        return this.layer[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.layer[prop] = value;
    }
    
    addToProperty(prop: string, value: any): void {
        if (Array.isArray(value)) {
            this.layer[prop].addMany(value);
        } else {
            this.layer[prop].add(value);
        }
    }
    
    removeFromProperty(prop: string, value: any): any {
        if (Array.isArray(value)) {
            this.layer[prop].removeMany(value);
        } else {
            this.layer[prop].remove(value);
        }
    }
}
