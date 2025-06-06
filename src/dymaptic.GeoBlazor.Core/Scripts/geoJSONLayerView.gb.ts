// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import GeoJSONLayerView = __esri.GeoJSONLayerView;
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, Pro, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class GeoJSONLayerViewGenerated implements IPropertyWrapper {
    public component: GeoJSONLayerView;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: GeoJSONLayerView) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.featureEffect)) {
            let { buildJsFeatureEffect } = await import('./featureEffect');
            this.component.featureEffect = await buildJsFeatureEffect(dotNetObject.featureEffect, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.filter)) {
            let { buildJsFeatureFilter } = await import('./featureFilter');
            this.component.filter = await buildJsFeatureFilter(dotNetObject.filter, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.highlightOptions)) {
            let { buildJsHighlightOptions } = await import('./highlightOptions');
            this.component.highlightOptions = await buildJsHighlightOptions(dotNetObject.highlightOptions) as any;
        }

        if (hasValue(dotNetObject.maximumNumberOfFeatures)) {
            this.component.maximumNumberOfFeatures = dotNetObject.maximumNumberOfFeatures;
        }
        if (hasValue(dotNetObject.maximumNumberOfFeaturesExceeded)) {
            this.component.maximumNumberOfFeaturesExceeded = dotNetObject.maximumNumberOfFeaturesExceeded;
        }
        if (hasValue(dotNetObject.visible)) {
            this.component.visible = dotNetObject.visible;
        }
    }
    
    async createAggregateQuery(): Promise<any> {
        return this.component.createAggregateQuery();
    }

    async createQuery(): Promise<any> {
        return this.component.createQuery();
    }

    async highlight(target: any,
        options: any): Promise<any> {
        let jsTarget: any;
        if (!Pro) {
            jsTarget = null;
        } else {
            try {
                // @ts-ignore GeoBlazor Pro only
                let { buildJsGraphic } = await import('./graphic');
                jsTarget = buildJsGraphic(target) as any;
            } catch (e) {
                console.error(`Pro functionality not available in GeoBlazor Core. ${e}`);
                jsTarget = null;
            }
        }
        return this.component.highlight(jsTarget,
            options);
    }

    async isFulfilled(): Promise<any> {
        return this.component.isFulfilled();
    }

    async isRejected(): Promise<any> {
        return this.component.isRejected();
    }

    async isResolved(): Promise<any> {
        return this.component.isResolved();
    }

    async queryAggregates(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.component.queryAggregates(jsQuery,
            options);
    }

    async queryAttributeBins(binsQuery: any,
        options: any): Promise<any> {
        return await this.component.queryAttributeBins(binsQuery,
            options);
    }

    async queryExtent(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.component.queryExtent(jsQuery,
            options);
    }

    async queryFeatureCount(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.component.queryFeatureCount(jsQuery,
            options);
    }

    async queryFeatures(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.component.queryFeatures(jsQuery,
            options);
    }

    async queryObjectIds(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.component.queryObjectIds(jsQuery,
            options);
    }

    async when(callback: any,
        errback: any): Promise<any> {
        let result = await this.component.when(callback,
            errback);
        
        return generateSerializableJson(result);
    }

    // region properties
    
    async getFeatureEffect(): Promise<any> {
        if (!hasValue(this.component.featureEffect)) {
            return null;
        }
        
        let { buildDotNetFeatureEffect } = await import('./featureEffect');
        return await buildDotNetFeatureEffect(this.component.featureEffect);
    }
    
    async setFeatureEffect(value: any): Promise<void> {
        let { buildJsFeatureEffect } = await import('./featureEffect');
        this.component.featureEffect = await  buildJsFeatureEffect(value, this.layerId, this.viewId);
    }
    
    async getFilter(): Promise<any> {
        if (!hasValue(this.component.filter)) {
            return null;
        }
        
        let { buildDotNetFeatureFilter } = await import('./featureFilter');
        return await buildDotNetFeatureFilter(this.component.filter);
    }
    
    async setFilter(value: any): Promise<void> {
        let { buildJsFeatureFilter } = await import('./featureFilter');
        this.component.filter = await  buildJsFeatureFilter(value, this.layerId, this.viewId);
    }
    
    async getHighlightOptions(): Promise<any> {
        if (!hasValue(this.component.highlightOptions)) {
            return null;
        }
        
        let { buildDotNetHighlightOptions } = await import('./highlightOptions');
        return await buildDotNetHighlightOptions(this.component.highlightOptions);
    }
    
    async setHighlightOptions(value: any): Promise<void> {
        let { buildJsHighlightOptions } = await import('./highlightOptions');
        this.component.highlightOptions = await  buildJsHighlightOptions(value);
    }
    
    async getLayer(): Promise<any> {
        if (!hasValue(this.component.layer)) {
            return null;
        }
        
        let { buildDotNetLayer } = await import('./layer');
        return await buildDotNetLayer(this.component.layer);
    }
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsGeoJSONLayerViewGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsGeoJSONLayerView: any = {};
    if (hasValue(dotNetObject.featureEffect)) {
        let { buildJsFeatureEffect } = await import('./featureEffect');
        jsGeoJSONLayerView.featureEffect = await buildJsFeatureEffect(dotNetObject.featureEffect, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.filter)) {
        let { buildJsFeatureFilter } = await import('./featureFilter');
        jsGeoJSONLayerView.filter = await buildJsFeatureFilter(dotNetObject.filter, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.highlightOptions)) {
        let { buildJsHighlightOptions } = await import('./highlightOptions');
        jsGeoJSONLayerView.highlightOptions = await buildJsHighlightOptions(dotNetObject.highlightOptions) as any;
    }

    if (hasValue(dotNetObject.maximumNumberOfFeatures)) {
        jsGeoJSONLayerView.maximumNumberOfFeatures = dotNetObject.maximumNumberOfFeatures;
    }
    if (hasValue(dotNetObject.maximumNumberOfFeaturesExceeded)) {
        jsGeoJSONLayerView.maximumNumberOfFeaturesExceeded = dotNetObject.maximumNumberOfFeaturesExceeded;
    }
    if (hasValue(dotNetObject.visible)) {
        jsGeoJSONLayerView.visible = dotNetObject.visible;
    }

    let { default: GeoJSONLayerViewWrapper } = await import('./geoJSONLayerView');
    let geoJSONLayerViewWrapper = new GeoJSONLayerViewWrapper(jsGeoJSONLayerView);
    geoJSONLayerViewWrapper.geoBlazorId = dotNetObject.id;
    geoJSONLayerViewWrapper.viewId = viewId;
    geoJSONLayerViewWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = geoJSONLayerViewWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGeoJSONLayerView;
    
    return jsGeoJSONLayerView;
}


export async function buildDotNetGeoJSONLayerViewGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetGeoJSONLayerView: any = {};
    
    if (hasValue(jsObject.featureEffect)) {
        let { buildDotNetFeatureEffect } = await import('./featureEffect');
        dotNetGeoJSONLayerView.featureEffect = await buildDotNetFeatureEffect(jsObject.featureEffect);
    }
    
    if (hasValue(jsObject.filter)) {
        let { buildDotNetFeatureFilter } = await import('./featureFilter');
        dotNetGeoJSONLayerView.filter = await buildDotNetFeatureFilter(jsObject.filter);
    }
    
    if (hasValue(jsObject.highlightOptions)) {
        let { buildDotNetHighlightOptions } = await import('./highlightOptions');
        dotNetGeoJSONLayerView.highlightOptions = await buildDotNetHighlightOptions(jsObject.highlightOptions);
    }
    
    if (hasValue(jsObject.availableFields)) {
        dotNetGeoJSONLayerView.availableFields = jsObject.availableFields;
    }
    
    if (hasValue(jsObject.dataUpdating)) {
        dotNetGeoJSONLayerView.dataUpdating = jsObject.dataUpdating;
    }
    
    if (hasValue(jsObject.hasAllFeatures)) {
        dotNetGeoJSONLayerView.hasAllFeatures = jsObject.hasAllFeatures;
    }
    
    if (hasValue(jsObject.hasAllFeaturesInView)) {
        dotNetGeoJSONLayerView.hasAllFeaturesInView = jsObject.hasAllFeaturesInView;
    }
    
    if (hasValue(jsObject.hasFullGeometries)) {
        dotNetGeoJSONLayerView.hasFullGeometries = jsObject.hasFullGeometries;
    }
    
    if (hasValue(jsObject.maximumNumberOfFeatures)) {
        dotNetGeoJSONLayerView.maximumNumberOfFeatures = jsObject.maximumNumberOfFeatures;
    }
    
    if (hasValue(jsObject.maximumNumberOfFeaturesExceeded)) {
        dotNetGeoJSONLayerView.maximumNumberOfFeaturesExceeded = jsObject.maximumNumberOfFeaturesExceeded;
    }
    
    if (hasValue(jsObject.spatialReferenceSupported)) {
        dotNetGeoJSONLayerView.spatialReferenceSupported = jsObject.spatialReferenceSupported;
    }
    
    if (hasValue(jsObject.suspended)) {
        dotNetGeoJSONLayerView.suspended = jsObject.suspended;
    }
    
    if (hasValue(jsObject.updating)) {
        dotNetGeoJSONLayerView.updating = jsObject.updating;
    }
    
    if (hasValue(jsObject.visible)) {
        dotNetGeoJSONLayerView.visible = jsObject.visible;
    }
    
    if (hasValue(jsObject.visibleAtCurrentScale)) {
        dotNetGeoJSONLayerView.visibleAtCurrentScale = jsObject.visibleAtCurrentScale;
    }
    
    if (hasValue(jsObject.visibleAtCurrentTimeExtent)) {
        dotNetGeoJSONLayerView.visibleAtCurrentTimeExtent = jsObject.visibleAtCurrentTimeExtent;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetGeoJSONLayerView.id = geoBlazorId;
    }

    return dotNetGeoJSONLayerView;
}

