// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import VectorTileLayer from '@arcgis/core/layers/VectorTileLayer';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class VectorTileLayerGenerated implements IPropertyWrapper {
    public layer: VectorTileLayer;

    constructor(layer: VectorTileLayer) {
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

    async deleteStyleLayer(layerId: any): Promise<void> {
        this.layer.deleteStyleLayer(layerId);
    }

    async fetchAttributionData(): Promise<any> {
        return await this.layer.fetchAttributionData();
    }

    async getLayoutProperties(layerId: any): Promise<any> {
        return this.layer.getLayoutProperties(layerId);
    }

    async getPaintProperties(layerId: any): Promise<any> {
        return this.layer.getPaintProperties(layerId);
    }

    async getStyleLayer(layerId: any): Promise<any> {
        return this.layer.getStyleLayer(layerId);
    }

    async getStyleLayerId(index: any): Promise<any> {
        return this.layer.getStyleLayerId(index);
    }

    async getStyleLayerIndex(layerId: any): Promise<any> {
        return this.layer.getStyleLayerIndex(layerId);
    }

    async getStyleLayerVisibility(layerId: any): Promise<any> {
        return this.layer.getStyleLayerVisibility(layerId);
    }

    async loadStyle(style: any,
        options: any): Promise<any> {
        return await this.layer.loadStyle(style,
            options);
    }

    async setLayoutProperties(layerId: any,
        layout: any): Promise<void> {
        this.layer.setLayoutProperties(layerId,
            layout);
    }

    async setPaintProperties(layerId: any,
        painter: any): Promise<void> {
        this.layer.setPaintProperties(layerId,
            painter);
    }

    async setSpriteSource(spriteSourceInfo: any): Promise<any> {
        let result = await this.layer.setSpriteSource(spriteSourceInfo);
        return await createGeoBlazorObject(result);
    }

    async setStyleLayer(layer: any,
        index: any): Promise<void> {
        this.layer.setStyleLayer(layer,
            index);
    }

    async setStyleLayerVisibility(layerId: any,
        visibility: any): Promise<void> {
        this.layer.setStyleLayerVisibility(layerId,
            visibility);
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
