// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import WebTileLayer from '@arcgis/core/layers/WebTileLayer';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class WebTileLayerGenerated implements IPropertyWrapper {
    public layer: WebTileLayer;

    constructor(layer: WebTileLayer) {
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

    async fetchAttributionData(): Promise<any> {
        return await this.layer.fetchAttributionData();
    }

    async fetchTile(level: any,
        row: any,
        col: any,
        options: any): Promise<any> {
        return await this.layer.fetchTile(level,
            row,
            col,
            options);
    }

    async getTileUrl(level: any,
        row: any,
        col: any): Promise<any> {
        return this.layer.getTileUrl(level,
            row,
            col);
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
