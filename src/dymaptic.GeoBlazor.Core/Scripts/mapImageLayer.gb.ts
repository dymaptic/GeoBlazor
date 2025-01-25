// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file

import {
    buildJsExtent
} from './jsBuilder';

import MapImageLayer from '@arcgis/core/layers/MapImageLayer';
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class MapImageLayerGenerated implements IPropertyWrapper {
    public layer: MapImageLayer;

    constructor(layer: MapImageLayer) {
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

    async createExportImageParameters(extent: any,
        width: any,
        height: any,
        options: any): Promise<any> {
        let jsExtent = await buildJsExtent(extent) as any;
        return this.layer.createExportImageParameters(jsExtent,
            width,
            height,
            options);
    }

    async createLayerView(view: any,
        options: any): Promise<any> {
        let result = await this.layer.createLayerView(view,
            options);
        return await createGeoBlazorObject(result);
    }

    async createServiceSublayers(): Promise<any> {
        let result = this.layer.createServiceSublayers();
        return await createGeoBlazorObject(result);
    }

    async fetchAttributionData(): Promise<any> {
        return await this.layer.fetchAttributionData();
    }

    async fetchImage(extent: any,
        width: any,
        height: any,
        options: any): Promise<any> {
        let jsExtent = await buildJsExtent(extent) as any;
        return await this.layer.fetchImage(jsExtent,
            width,
            height,
            options);
    }

    async findSublayerById(id: any): Promise<any> {
        let result = this.layer.findSublayerById(id);
        return await createGeoBlazorObject(result);
    }

    async loadAll(): Promise<any> {
        let result = await this.layer.loadAll();
        return await createGeoBlazorObject(result);
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
