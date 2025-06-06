// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import WFSLayer from '@arcgis/core/layers/WFSLayer';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, buildJsStreamReference, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class WFSLayerGenerated implements IPropertyWrapper {
    public layer: WFSLayer;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(layer: WFSLayer) {
        this.layer = layer;
    }
    
    // region methods
   
    unwrap() {
        return this.layer;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.displayFilterInfo)) {
            let { buildJsDisplayFilterInfo } = await import('./displayFilterInfo');
            this.layer.displayFilterInfo = await buildJsDisplayFilterInfo(dotNetObject.displayFilterInfo, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.effect)) {
            let { buildJsEffect } = await import('./effect');
            this.layer.effect = buildJsEffect(dotNetObject.effect) as any;
        }
        if (hasValue(dotNetObject.elevationInfo)) {
            let { buildJsWFSLayerElevationInfo } = await import('./wFSLayerElevationInfo');
            this.layer.elevationInfo = await buildJsWFSLayerElevationInfo(dotNetObject.elevationInfo) as any;
        }
        if (hasValue(dotNetObject.featureEffect)) {
            let { buildJsFeatureEffect } = await import('./featureEffect');
            this.layer.featureEffect = await buildJsFeatureEffect(dotNetObject.featureEffect, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.featureReduction)) {
            let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
            this.layer.featureReduction = await buildJsIFeatureReduction(dotNetObject.featureReduction, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.fields) && dotNetObject.fields.length > 0) {
            let { buildJsField } = await import('./field');
            this.layer.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
        }
        if (hasValue(dotNetObject.fullExtent)) {
            let { buildJsExtent } = await import('./extent');
            this.layer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
        }
        if (hasValue(dotNetObject.labelingInfo) && dotNetObject.labelingInfo.length > 0) {
            let { buildJsLabel } = await import('./label');
            this.layer.labelingInfo = await Promise.all(dotNetObject.labelingInfo.map(async i => await buildJsLabel(i, this.layerId, this.viewId))) as any;
        }
        if (hasValue(dotNetObject.orderBy) && dotNetObject.orderBy.length > 0) {
            let { buildJsOrderByInfo } = await import('./orderByInfo');
            this.layer.orderBy = await Promise.all(dotNetObject.orderBy.map(async i => await buildJsOrderByInfo(i, this.layerId, this.viewId))) as any;
        }
        if (hasValue(dotNetObject.popupTemplate)) {
            let { buildJsPopupTemplate } = await import('./popupTemplate');
            this.layer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.portalItem)) {
            let { buildJsPortalItem } = await import('./portalItem');
            this.layer.portalItem = await buildJsPortalItem(dotNetObject.portalItem, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.renderer)) {
            let { buildJsRenderer } = await import('./renderer');
            this.layer.renderer = await buildJsRenderer(dotNetObject.renderer, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.spatialReference)) {
            let { buildJsSpatialReference } = await import('./spatialReference');
            this.layer.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
        }
        if (hasValue(dotNetObject.trackInfo)) {
            let { buildJsTrackInfo } = await import('./trackInfo');
            this.layer.trackInfo = await buildJsTrackInfo(dotNetObject.trackInfo, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.visibilityTimeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.layer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
        }
        if (hasValue(dotNetObject.wfsCapabilities)) {
            let { buildJsWFSCapabilities } = await import('./wFSCapabilities');
            this.layer.wfsCapabilities = await buildJsWFSCapabilities(dotNetObject.wfsCapabilities) as any;
        }

        if (hasValue(dotNetObject.arcGISLayerId)) {
            this.layer.id = dotNetObject.arcGISLayerId;
        }
        if (hasValue(dotNetObject.blendMode)) {
            this.layer.blendMode = dotNetObject.blendMode;
        }
        if (hasValue(dotNetObject.copyright)) {
            this.layer.copyright = dotNetObject.copyright;
        }
        if (hasValue(dotNetObject.customParameters)) {
            this.layer.customParameters = dotNetObject.customParameters;
        }
        if (hasValue(dotNetObject.definitionExpression)) {
            this.layer.definitionExpression = dotNetObject.definitionExpression;
        }
        if (hasValue(dotNetObject.displayField)) {
            this.layer.displayField = dotNetObject.displayField;
        }
        if (hasValue(dotNetObject.displayFilterEnabled)) {
            this.layer.displayFilterEnabled = dotNetObject.displayFilterEnabled;
        }
        if (hasValue(dotNetObject.geometryType)) {
            this.layer.geometryType = dotNetObject.geometryType;
        }
        if (hasValue(dotNetObject.labelsVisible)) {
            this.layer.labelsVisible = dotNetObject.labelsVisible;
        }
        if (hasValue(dotNetObject.legendEnabled)) {
            this.layer.legendEnabled = dotNetObject.legendEnabled;
        }
        if (hasValue(dotNetObject.listMode)) {
            this.layer.listMode = dotNetObject.listMode;
        }
        if (hasValue(dotNetObject.maxPageCount)) {
            this.layer.maxPageCount = dotNetObject.maxPageCount;
        }
        if (hasValue(dotNetObject.maxRecordCount)) {
            this.layer.maxRecordCount = dotNetObject.maxRecordCount;
        }
        if (hasValue(dotNetObject.maxScale)) {
            this.layer.maxScale = dotNetObject.maxScale;
        }
        if (hasValue(dotNetObject.minScale)) {
            this.layer.minScale = dotNetObject.minScale;
        }
        if (hasValue(dotNetObject.name)) {
            this.layer.name = dotNetObject.name;
        }
        if (hasValue(dotNetObject.namespaceUri)) {
            this.layer.namespaceUri = dotNetObject.namespaceUri;
        }
        if (hasValue(dotNetObject.objectIdField)) {
            this.layer.objectIdField = dotNetObject.objectIdField;
        }
        if (hasValue(dotNetObject.opacity)) {
            this.layer.opacity = dotNetObject.opacity;
        }
        if (hasValue(dotNetObject.outFields) && dotNetObject.outFields.length > 0) {
            this.layer.outFields = dotNetObject.outFields;
        }
        if (hasValue(dotNetObject.persistenceEnabled)) {
            this.layer.persistenceEnabled = dotNetObject.persistenceEnabled;
        }
        if (hasValue(dotNetObject.popupEnabled)) {
            this.layer.popupEnabled = dotNetObject.popupEnabled;
        }
        if (hasValue(dotNetObject.refreshInterval)) {
            this.layer.refreshInterval = dotNetObject.refreshInterval;
        }
        if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
            this.layer.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
        }
        if (hasValue(dotNetObject.title)) {
            this.layer.title = dotNetObject.title;
        }
        if (hasValue(dotNetObject.url)) {
            this.layer.url = dotNetObject.url;
        }
        if (hasValue(dotNetObject.visible)) {
            this.layer.visible = dotNetObject.visible;
        }
    }
    
    async cancelLoad(): Promise<void> {
        this.layer.cancelLoad();
    }

    async createLayerView(view: any,
        options: any): Promise<any> {
        return await this.layer.createLayerView(view,
            options);
    }

    async createPopupTemplate(options: any): Promise<any> {
        return this.layer.createPopupTemplate(options);
    }

    async createQuery(): Promise<any> {
        return this.layer.createQuery();
    }

    async fetchAttributionData(): Promise<any> {
        let result = await this.layer.fetchAttributionData();
        
        return generateSerializableJson(result);
    }

    async getField(fieldName: any): Promise<any> {
        return this.layer.getField(fieldName);
    }

    async getFieldDomain(fieldName: any,
        options: any): Promise<any> {
        return this.layer.getFieldDomain(fieldName,
            options);
    }

    async isFulfilled(): Promise<any> {
        return this.layer.isFulfilled();
    }

    async isRejected(): Promise<any> {
        return this.layer.isRejected();
    }

    async isResolved(): Promise<any> {
        return this.layer.isResolved();
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        
        return generateSerializableJson(result);
    }

    async queryExtent(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.layer.queryExtent(jsQuery,
            options);
    }

    async queryFeatureCount(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.layer.queryFeatureCount(jsQuery,
            options);
    }

    async queryFeatures(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.layer.queryFeatures(jsQuery,
            options);
    }

    async queryObjectIds(query: any,
        options: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId) as any;
        return await this.layer.queryObjectIds(jsQuery,
            options);
    }

    async refresh(): Promise<void> {
        this.layer.refresh();
    }

    async when(callback: any,
        errback: any): Promise<any> {
        let result = await this.layer.when(callback,
            errback);
        
        return generateSerializableJson(result);
    }

    // region properties
    
    getArcGISLayerId(): any {
        if (!hasValue(this.layer.id)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.id);
    }
    
    setArcGISLayerId(value: any): void {
        this.layer.id = JSON.parse(value);
    }
    
    async getCapabilities(): Promise<any> {
        if (!hasValue(this.layer.capabilities)) {
            return null;
        }
        
        let { buildDotNetWFSLayerCapabilities } = await import('./wFSLayerCapabilities');
        return await buildDotNetWFSLayerCapabilities(this.layer.capabilities);
    }
    
    getCopyright(): any {
        if (!hasValue(this.layer.copyright)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.copyright);
    }
    
    setCopyright(value: any): void {
        this.layer.copyright = JSON.parse(value);
    }
    
    getDateFieldsTimeZone(): any {
        if (!hasValue(this.layer.dateFieldsTimeZone)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.dateFieldsTimeZone);
    }
    
    getDefinitionExpression(): any {
        if (!hasValue(this.layer.definitionExpression)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.definitionExpression);
    }
    
    setDefinitionExpression(value: any): void {
        this.layer.definitionExpression = JSON.parse(value);
    }
    
    getDisplayField(): any {
        if (!hasValue(this.layer.displayField)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.displayField);
    }
    
    setDisplayField(value: any): void {
        this.layer.displayField = JSON.parse(value);
    }
    
    async getDisplayFilterInfo(): Promise<any> {
        if (!hasValue(this.layer.displayFilterInfo)) {
            return null;
        }
        
        let { buildDotNetDisplayFilterInfo } = await import('./displayFilterInfo');
        return await buildDotNetDisplayFilterInfo(this.layer.displayFilterInfo);
    }
    
    async setDisplayFilterInfo(value: any): Promise<void> {
        let { buildJsDisplayFilterInfo } = await import('./displayFilterInfo');
        this.layer.displayFilterInfo = await  buildJsDisplayFilterInfo(value, this.layerId, this.viewId);
    }
    
    async getEffect(): Promise<any> {
        if (!hasValue(this.layer.effect)) {
            return null;
        }
        
        let { buildDotNetEffect } = await import('./effect');
        return buildDotNetEffect(this.layer.effect);
    }
    
    async setEffect(value: any): Promise<void> {
        let { buildJsEffect } = await import('./effect');
        this.layer.effect =  buildJsEffect(value);
    }
    
    async getElevationInfo(): Promise<any> {
        if (!hasValue(this.layer.elevationInfo)) {
            return null;
        }
        
        let { buildDotNetWFSLayerElevationInfo } = await import('./wFSLayerElevationInfo');
        return await buildDotNetWFSLayerElevationInfo(this.layer.elevationInfo);
    }
    
    async setElevationInfo(value: any): Promise<void> {
        let { buildJsWFSLayerElevationInfo } = await import('./wFSLayerElevationInfo');
        this.layer.elevationInfo = await  buildJsWFSLayerElevationInfo(value);
    }
    
    async getFeatureEffect(): Promise<any> {
        if (!hasValue(this.layer.featureEffect)) {
            return null;
        }
        
        let { buildDotNetFeatureEffect } = await import('./featureEffect');
        return await buildDotNetFeatureEffect(this.layer.featureEffect);
    }
    
    async setFeatureEffect(value: any): Promise<void> {
        let { buildJsFeatureEffect } = await import('./featureEffect');
        this.layer.featureEffect = await  buildJsFeatureEffect(value, this.layerId, this.viewId);
    }
    
    async getFields(): Promise<any> {
        if (!hasValue(this.layer.fields)) {
            return null;
        }
        
        let { buildDotNetField } = await import('./field');
        return this.layer.fields!.map(i => buildDotNetField(i));
    }
    
    async setFields(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.layer.fields = [];
        }
        let { buildJsField } = await import('./field');
        this.layer.fields = value.map(i => buildJsField(i)) as any;
    }
    
    async getFieldsIndex(): Promise<any> {
        if (!hasValue(this.layer.fieldsIndex)) {
            return null;
        }
        
        let { buildDotNetFieldsIndex } = await import('./fieldsIndex');
        return await buildDotNetFieldsIndex(this.layer.fieldsIndex);
    }
    
    async getFullExtent(): Promise<any> {
        if (!hasValue(this.layer.fullExtent)) {
            return null;
        }
        
        let { buildDotNetExtent } = await import('./extent');
        return buildDotNetExtent(this.layer.fullExtent);
    }
    
    async setFullExtent(value: any): Promise<void> {
        let { buildJsExtent } = await import('./extent');
        this.layer.fullExtent =  buildJsExtent(value);
    }
    
    async getLabelingInfo(): Promise<any> {
        if (!hasValue(this.layer.labelingInfo)) {
            return null;
        }
        
        let { buildDotNetLabel } = await import('./label');
        return await Promise.all(this.layer.labelingInfo!.map(async i => await buildDotNetLabel(i)));
    }
    
    async setLabelingInfo(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.layer.labelingInfo = [];
        }
        let { buildJsLabel } = await import('./label');
        this.layer.labelingInfo = await Promise.all(value.map(async i => await buildJsLabel(i, this.layerId, this.viewId))) as any;
    }
    
    getName(): any {
        if (!hasValue(this.layer.name)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.name);
    }
    
    setName(value: any): void {
        this.layer.name = JSON.parse(value);
    }
    
    getNamespaceUri(): any {
        if (!hasValue(this.layer.namespaceUri)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.namespaceUri);
    }
    
    setNamespaceUri(value: any): void {
        this.layer.namespaceUri = JSON.parse(value);
    }
    
    getObjectIdField(): any {
        if (!hasValue(this.layer.objectIdField)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.objectIdField);
    }
    
    setObjectIdField(value: any): void {
        this.layer.objectIdField = JSON.parse(value);
    }
    
    async getOrderBy(): Promise<any> {
        if (!hasValue(this.layer.orderBy)) {
            return null;
        }
        
        let { buildDotNetOrderByInfo } = await import('./orderByInfo');
        return await Promise.all(this.layer.orderBy!.map(async i => await buildDotNetOrderByInfo(i)));
    }
    
    async setOrderBy(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.layer.orderBy = [];
        }
        let { buildJsOrderByInfo } = await import('./orderByInfo');
        this.layer.orderBy = await Promise.all(value.map(async i => await buildJsOrderByInfo(i, this.layerId, this.viewId))) as any;
    }
    
    async getPopupTemplate(): Promise<any> {
        if (!hasValue(this.layer.popupTemplate)) {
            return null;
        }
        
        let { buildDotNetPopupTemplate } = await import('./popupTemplate');
        return await buildDotNetPopupTemplate(this.layer.popupTemplate);
    }
    
    async setPopupTemplate(value: any): Promise<void> {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        this.layer.popupTemplate =  buildJsPopupTemplate(value, this.layerId, this.viewId);
    }
    
    async getPortalItem(): Promise<any> {
        if (!hasValue(this.layer.portalItem)) {
            return null;
        }
        
        let { buildDotNetPortalItem } = await import('./portalItem');
        return await buildDotNetPortalItem(this.layer.portalItem);
    }
    
    async setPortalItem(value: any): Promise<void> {
        let { buildJsPortalItem } = await import('./portalItem');
        this.layer.portalItem = await  buildJsPortalItem(value, this.layerId, this.viewId);
    }
    
    async getRenderer(): Promise<any> {
        if (!hasValue(this.layer.renderer)) {
            return null;
        }
        
        let { buildDotNetRenderer } = await import('./renderer');
        return await buildDotNetRenderer(this.layer.renderer);
    }
    
    async setRenderer(value: any): Promise<void> {
        let { buildJsRenderer } = await import('./renderer');
        this.layer.renderer = await  buildJsRenderer(value, this.layerId, this.viewId);
    }
    
    async getSpatialReference(): Promise<any> {
        if (!hasValue(this.layer.spatialReference)) {
            return null;
        }
        
        let { buildDotNetSpatialReference } = await import('./spatialReference');
        return buildDotNetSpatialReference(this.layer.spatialReference);
    }
    
    getTitle(): any {
        if (!hasValue(this.layer.title)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.title);
    }
    
    setTitle(value: any): void {
        this.layer.title = JSON.parse(value);
    }
    
    async getTrackInfo(): Promise<any> {
        if (!hasValue(this.layer.trackInfo)) {
            return null;
        }
        
        let { buildDotNetTrackInfo } = await import('./trackInfo');
        return await buildDotNetTrackInfo(this.layer.trackInfo);
    }
    
    async setTrackInfo(value: any): Promise<void> {
        let { buildJsTrackInfo } = await import('./trackInfo');
        this.layer.trackInfo = await  buildJsTrackInfo(value, this.layerId, this.viewId);
    }
    
    getUrl(): any {
        if (!hasValue(this.layer.url)) {
            return null;
        }
        
        return generateSerializableJson(this.layer.url);
    }
    
    setUrl(value: any): void {
        this.layer.url = JSON.parse(value);
    }
    
    async getVisibilityTimeExtent(): Promise<any> {
        if (!hasValue(this.layer.visibilityTimeExtent)) {
            return null;
        }
        
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        return buildDotNetTimeExtent(this.layer.visibilityTimeExtent);
    }
    
    async setVisibilityTimeExtent(value: any): Promise<void> {
        let { buildJsTimeExtent } = await import('./timeExtent');
        this.layer.visibilityTimeExtent = await  buildJsTimeExtent(value);
    }
    
    async getWfsCapabilities(): Promise<any> {
        if (!hasValue(this.layer.wfsCapabilities)) {
            return null;
        }
        
        let { buildDotNetWFSCapabilities } = await import('./wFSCapabilities');
        return await buildDotNetWFSCapabilities(this.layer.wfsCapabilities);
    }
    
    async setWfsCapabilities(value: any): Promise<void> {
        let { buildJsWFSCapabilities } = await import('./wFSCapabilities');
        this.layer.wfsCapabilities = await  buildJsWFSCapabilities(value);
    }
    
    getProperty(prop: string): any {
        return this.layer[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.layer[prop] = value;
    }
}


export async function buildJsWFSLayerGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.displayFilterInfo)) {
        let { buildJsDisplayFilterInfo } = await import('./displayFilterInfo');
        properties.displayFilterInfo = await buildJsDisplayFilterInfo(dotNetObject.displayFilterInfo, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.effect)) {
        let { buildJsEffect } = await import('./effect');
        properties.effect = buildJsEffect(dotNetObject.effect) as any;
    }
    if (hasValue(dotNetObject.elevationInfo)) {
        let { buildJsWFSLayerElevationInfo } = await import('./wFSLayerElevationInfo');
        properties.elevationInfo = await buildJsWFSLayerElevationInfo(dotNetObject.elevationInfo) as any;
    }
    if (hasValue(dotNetObject.featureEffect)) {
        let { buildJsFeatureEffect } = await import('./featureEffect');
        properties.featureEffect = await buildJsFeatureEffect(dotNetObject.featureEffect, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.featureReduction)) {
        let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
        properties.featureReduction = await buildJsIFeatureReduction(dotNetObject.featureReduction, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.fields) && dotNetObject.fields.length > 0) {
        let { buildJsField } = await import('./field');
        properties.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        let { buildJsExtent } = await import('./extent');
        properties.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.labelingInfo) && dotNetObject.labelingInfo.length > 0) {
        let { buildJsLabel } = await import('./label');
        properties.labelingInfo = await Promise.all(dotNetObject.labelingInfo.map(async i => await buildJsLabel(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.orderBy) && dotNetObject.orderBy.length > 0) {
        let { buildJsOrderByInfo } = await import('./orderByInfo');
        properties.orderBy = await Promise.all(dotNetObject.orderBy.map(async i => await buildJsOrderByInfo(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        properties.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        let { buildJsPortalItem } = await import('./portalItem');
        properties.portalItem = await buildJsPortalItem(dotNetObject.portalItem, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        let { buildJsRenderer } = await import('./renderer');
        properties.renderer = await buildJsRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        let { buildJsSpatialReference } = await import('./spatialReference');
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
    }
    if (hasValue(dotNetObject.trackInfo)) {
        let { buildJsTrackInfo } = await import('./trackInfo');
        properties.trackInfo = await buildJsTrackInfo(dotNetObject.trackInfo, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }

    if (hasValue(dotNetObject.arcGISLayerId)) {
        properties.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        properties.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        properties.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        properties.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.definitionExpression)) {
        properties.definitionExpression = dotNetObject.definitionExpression;
    }
    if (hasValue(dotNetObject.displayField)) {
        properties.displayField = dotNetObject.displayField;
    }
    if (hasValue(dotNetObject.displayFilterEnabled)) {
        properties.displayFilterEnabled = dotNetObject.displayFilterEnabled;
    }
    if (hasValue(dotNetObject.geometryType)) {
        properties.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.labelsVisible)) {
        properties.labelsVisible = dotNetObject.labelsVisible;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        properties.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        properties.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxPageCount)) {
        properties.maxPageCount = dotNetObject.maxPageCount;
    }
    if (hasValue(dotNetObject.maxRecordCount)) {
        properties.maxRecordCount = dotNetObject.maxRecordCount;
    }
    if (hasValue(dotNetObject.maxScale)) {
        properties.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        properties.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.namespaceUri)) {
        properties.namespaceUri = dotNetObject.namespaceUri;
    }
    if (hasValue(dotNetObject.objectIdField)) {
        properties.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.opacity)) {
        properties.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.outFields) && dotNetObject.outFields.length > 0) {
        properties.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        properties.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        properties.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        properties.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
        properties.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        properties.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    let jsWFSLayer = new WFSLayer(properties);
    if (hasValue(dotNetObject.hasCreateListener) && dotNetObject.hasCreateListener) {
        jsWFSLayer.on('layerview-create', async (evt: any) => {
            let { buildDotNetLayerViewCreateEvent } = await import('./layerViewCreateEvent');
            let dnEvent = await buildDotNetLayerViewCreateEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsCreate', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasCreateErrorListener) && dotNetObject.hasCreateErrorListener) {
        jsWFSLayer.on('layerview-create-error', async (evt: any) => {
            let { buildDotNetLayerViewCreateErrorEvent } = await import('./layerViewCreateErrorEvent');
            let dnEvent = await buildDotNetLayerViewCreateErrorEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsCreateError', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasDestroyListener) && dotNetObject.hasDestroyListener) {
        jsWFSLayer.on('layerview-destroy', async (evt: any) => {
            let { buildDotNetLayerViewDestroyEvent } = await import('./layerViewDestroyEvent');
            let dnEvent = await buildDotNetLayerViewDestroyEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsDestroy', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasRefreshListener) && dotNetObject.hasRefreshListener) {
        jsWFSLayer.on('refresh', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', streamRef);
        });
    }
    

    let { default: WFSLayerWrapper } = await import('./wFSLayer');
    let wFSLayerWrapper = new WFSLayerWrapper(jsWFSLayer);
    wFSLayerWrapper.geoBlazorId = dotNetObject.id;
    wFSLayerWrapper.viewId = viewId;
    wFSLayerWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = wFSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWFSLayer;
    
    try {
        let jsObjectRef = DotNet.createJSObjectReference(wFSLayerWrapper);
        let { buildDotNetWFSLayer } = await import('./wFSLayer');
        let dnInstantiatedObject = await buildDotNetWFSLayer(jsWFSLayer);

        let dnStream = buildJsStreamReference(dnInstantiatedObject);
        await dotNetObject.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated', 
            jsObjectRef, dnStream);
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WFSLayer', e);
    }
    
    return jsWFSLayer;
}


export async function buildDotNetWFSLayerGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetWFSLayer: any = {};
    
    if (hasValue(jsObject.capabilities)) {
        let { buildDotNetWFSLayerCapabilities } = await import('./wFSLayerCapabilities');
        dotNetWFSLayer.capabilities = await buildDotNetWFSLayerCapabilities(jsObject.capabilities);
    }
    
    if (hasValue(jsObject.displayFilterInfo)) {
        let { buildDotNetDisplayFilterInfo } = await import('./displayFilterInfo');
        dotNetWFSLayer.displayFilterInfo = await buildDotNetDisplayFilterInfo(jsObject.displayFilterInfo);
    }
    
    if (hasValue(jsObject.effect)) {
        let { buildDotNetEffect } = await import('./effect');
        dotNetWFSLayer.effect = buildDotNetEffect(jsObject.effect);
    }
    
    if (hasValue(jsObject.elevationInfo)) {
        let { buildDotNetWFSLayerElevationInfo } = await import('./wFSLayerElevationInfo');
        dotNetWFSLayer.elevationInfo = await buildDotNetWFSLayerElevationInfo(jsObject.elevationInfo);
    }
    
    if (hasValue(jsObject.featureEffect)) {
        let { buildDotNetFeatureEffect } = await import('./featureEffect');
        dotNetWFSLayer.featureEffect = await buildDotNetFeatureEffect(jsObject.featureEffect);
    }
    
    if (hasValue(jsObject.featureReduction)) {
        let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
        dotNetWFSLayer.featureReduction = await buildDotNetIFeatureReduction(jsObject.featureReduction);
    }
    
    if (hasValue(jsObject.fields)) {
        let { buildDotNetField } = await import('./field');
        dotNetWFSLayer.fields = jsObject.fields.map(i => buildDotNetField(i));
    }
    
    if (hasValue(jsObject.fieldsIndex)) {
        let { buildDotNetFieldsIndex } = await import('./fieldsIndex');
        dotNetWFSLayer.fieldsIndex = await buildDotNetFieldsIndex(jsObject.fieldsIndex);
    }
    
    if (hasValue(jsObject.fullExtent)) {
        let { buildDotNetExtent } = await import('./extent');
        dotNetWFSLayer.fullExtent = buildDotNetExtent(jsObject.fullExtent);
    }
    
    if (hasValue(jsObject.labelingInfo)) {
        let { buildDotNetLabel } = await import('./label');
        dotNetWFSLayer.labelingInfo = await Promise.all(jsObject.labelingInfo.map(async i => await buildDotNetLabel(i)));
    }
    
    if (hasValue(jsObject.orderBy)) {
        let { buildDotNetOrderByInfo } = await import('./orderByInfo');
        dotNetWFSLayer.orderBy = await Promise.all(jsObject.orderBy.map(async i => await buildDotNetOrderByInfo(i)));
    }
    
    if (hasValue(jsObject.popupTemplate)) {
        let { buildDotNetPopupTemplate } = await import('./popupTemplate');
        dotNetWFSLayer.popupTemplate = await buildDotNetPopupTemplate(jsObject.popupTemplate);
    }
    
    if (hasValue(jsObject.portalItem)) {
        let { buildDotNetPortalItem } = await import('./portalItem');
        dotNetWFSLayer.portalItem = await buildDotNetPortalItem(jsObject.portalItem);
    }
    
    if (hasValue(jsObject.renderer)) {
        let { buildDotNetRenderer } = await import('./renderer');
        dotNetWFSLayer.renderer = await buildDotNetRenderer(jsObject.renderer);
    }
    
    if (hasValue(jsObject.spatialReference)) {
        let { buildDotNetSpatialReference } = await import('./spatialReference');
        dotNetWFSLayer.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }
    
    if (hasValue(jsObject.trackInfo)) {
        let { buildDotNetTrackInfo } = await import('./trackInfo');
        dotNetWFSLayer.trackInfo = await buildDotNetTrackInfo(jsObject.trackInfo);
    }
    
    if (hasValue(jsObject.visibilityTimeExtent)) {
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        dotNetWFSLayer.visibilityTimeExtent = buildDotNetTimeExtent(jsObject.visibilityTimeExtent);
    }
    
    if (hasValue(jsObject.id)) {
        dotNetWFSLayer.arcGISLayerId = jsObject.id;
    }
    
    if (hasValue(jsObject.blendMode)) {
        dotNetWFSLayer.blendMode = removeCircularReferences(jsObject.blendMode);
    }
    
    if (hasValue(jsObject.copyright)) {
        dotNetWFSLayer.copyright = jsObject.copyright;
    }
    
    if (hasValue(jsObject.customParameters)) {
        dotNetWFSLayer.customParameters = removeCircularReferences(jsObject.customParameters);
    }
    
    if (hasValue(jsObject.dateFieldsTimeZone)) {
        dotNetWFSLayer.dateFieldsTimeZone = jsObject.dateFieldsTimeZone;
    }
    
    if (hasValue(jsObject.definitionExpression)) {
        dotNetWFSLayer.definitionExpression = jsObject.definitionExpression;
    }
    
    if (hasValue(jsObject.displayField)) {
        dotNetWFSLayer.displayField = jsObject.displayField;
    }
    
    if (hasValue(jsObject.displayFilterEnabled)) {
        dotNetWFSLayer.displayFilterEnabled = jsObject.displayFilterEnabled;
    }
    
    if (hasValue(jsObject.geometryType)) {
        dotNetWFSLayer.geometryType = removeCircularReferences(jsObject.geometryType);
    }
    
    if (hasValue(jsObject.labelsVisible)) {
        dotNetWFSLayer.labelsVisible = jsObject.labelsVisible;
    }
    
    if (hasValue(jsObject.legendEnabled)) {
        dotNetWFSLayer.legendEnabled = jsObject.legendEnabled;
    }
    
    if (hasValue(jsObject.listMode)) {
        dotNetWFSLayer.listMode = removeCircularReferences(jsObject.listMode);
    }
    
    if (hasValue(jsObject.loaded)) {
        dotNetWFSLayer.loaded = jsObject.loaded;
    }
    
    if (hasValue(jsObject.maxPageCount)) {
        dotNetWFSLayer.maxPageCount = jsObject.maxPageCount;
    }
    
    if (hasValue(jsObject.maxRecordCount)) {
        dotNetWFSLayer.maxRecordCount = jsObject.maxRecordCount;
    }
    
    if (hasValue(jsObject.maxScale)) {
        dotNetWFSLayer.maxScale = jsObject.maxScale;
    }
    
    if (hasValue(jsObject.minScale)) {
        dotNetWFSLayer.minScale = jsObject.minScale;
    }
    
    if (hasValue(jsObject.name)) {
        dotNetWFSLayer.name = jsObject.name;
    }
    
    if (hasValue(jsObject.namespaceUri)) {
        dotNetWFSLayer.namespaceUri = jsObject.namespaceUri;
    }
    
    if (hasValue(jsObject.objectIdField)) {
        dotNetWFSLayer.objectIdField = jsObject.objectIdField;
    }
    
    if (hasValue(jsObject.opacity)) {
        dotNetWFSLayer.opacity = jsObject.opacity;
    }
    
    if (hasValue(jsObject.outFields)) {
        dotNetWFSLayer.outFields = jsObject.outFields;
    }
    
    if (hasValue(jsObject.persistenceEnabled)) {
        dotNetWFSLayer.persistenceEnabled = jsObject.persistenceEnabled;
    }
    
    if (hasValue(jsObject.popupEnabled)) {
        dotNetWFSLayer.popupEnabled = jsObject.popupEnabled;
    }
    
    if (hasValue(jsObject.refreshInterval)) {
        dotNetWFSLayer.refreshInterval = jsObject.refreshInterval;
    }
    
    if (hasValue(jsObject.screenSizePerspectiveEnabled)) {
        dotNetWFSLayer.screenSizePerspectiveEnabled = jsObject.screenSizePerspectiveEnabled;
    }
    
    if (hasValue(jsObject.title)) {
        dotNetWFSLayer.title = jsObject.title;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetWFSLayer.type = removeCircularReferences(jsObject.type);
    }
    
    if (hasValue(jsObject.url)) {
        dotNetWFSLayer.url = jsObject.url;
    }
    
    if (hasValue(jsObject.visible)) {
        dotNetWFSLayer.visible = jsObject.visible;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetWFSLayer.id = geoBlazorId;
    }

    return dotNetWFSLayer;
}

