import FeatureLayer from '@arcgis/core/layers/FeatureLayer';
import FeatureLayerGenerated from './featureLayer.gb';
import Query from "@arcgis/core/rest/support/Query";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import {
    DotNetDomain,
    DotNetFeatureLayer,
    DotNetFeatureSet,
    DotNetField,
    DotNetGraphic,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetTopFeaturesQuery
} from "./definitions";
import {
    decodeProtobufGraphics,
    getGraphicsFromProtobufStream,
    getProtobufGraphicStream,
    hasValue,
    lookupJsGraphicById
} from "./arcGisJsInterop";
import Graphic from "@arcgis/core/Graphic";
import {buildDotNetPopupTemplate} from './popupTemplate';
import CreatePopupTemplateOptions = __esri.CreatePopupTemplateOptions;

export default class FeatureLayerWrapper extends FeatureLayerGenerated {

    constructor(layer: FeatureLayer) {
        super(layer);
    }


    async createPopupTemplate(options: CreatePopupTemplateOptions | null): Promise<DotNetPopupTemplate> {
        let jsPopupTemplate = options === null
            ? this.layer.createPopupTemplate()
            : this.layer.createPopupTemplate(options);
        return await buildDotNetPopupTemplate(jsPopupTemplate);
    }


    createQuery(): Query {
        return this.layer.createQuery();
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let { buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        let {buildDotNetExtent} = await import('./extent');
        let result = await this.layer.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }

    async queryFeatures(query: DotNetQuery | null, options: any, dotNetRef: any, queryId: string):
        Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery: Query | undefined = undefined;

            if (this.hasValue(query)) {
                let { buildJsQuery} = await import('./query');
                jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
            }

            let featureSet = await this.layer.queryFeatures(jsQuery, options);

            let {buildDotNetFeatureSet} = await import('./featureSet');
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
            if (dotNetFeatureSet.features.length > 0) {
                let graphics = getProtobufGraphicStream(dotNetFeatureSet.features, this.layer);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesStreamCallback', graphics, queryId);
                dotNetFeatureSet.features = [];
            }

            return dotNetFeatureSet;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let { buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        return await this.layer.queryFeatureCount(jsQuery, options);
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let { buildJsQuery} = await import('./query');
        let jsQuery = await buildJsQuery(query, this.layerId, this.viewId);
        return await this.layer.queryObjectIds(jsQuery, options);
    }

    async queryRelatedFeatures(query: DotNetRelationshipQuery, options: any, dotNetRef: any,
                               queryId: string): Promise<any | null> {
        try {
            let { buildJsRelationshipQuery} = await import('./relationshipQuery');
            let jsQuery = await buildJsRelationshipQuery(query);
            let featureSetsDictionary = await this.layer.queryRelatedFeatures(jsQuery, options);
            let graphicsDictionary: any = {};
            let {buildDotNetFeatureSet} = await import('./featureSet');
            for (let prop in featureSetsDictionary) {
                if (featureSetsDictionary.hasOwnProperty(prop)) {
                    let featureSet = featureSetsDictionary[prop] as FeatureSet;
                    let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
                    if (dotNetFeatureSet.features.length > 0) {
                        let graphics = getProtobufGraphicStream(dotNetFeatureSet.features, this.layer);
                        await dotNetRef.invokeMethodAsync('OnQueryRelatedFeaturesStreamCallback', graphics, queryId, prop);
                        dotNetFeatureSet.features = [];
                    }
                    graphicsDictionary[prop] = dotNetFeatureSet;
                }
            }
            return graphicsDictionary;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryRelatedFeaturesCount(query: DotNetRelationshipQuery, options: any): Promise<number> {
        let { buildJsRelationshipQuery} = await import('./relationshipQuery');
        let jsQuery = await buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeaturesCount(jsQuery, options);
    }


    async queryTopFeatures(query: DotNetTopFeaturesQuery, options: any, dotNetRef: any,
                           queryId: string): Promise<DotNetFeatureSet | null> {
        try {
            let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
            let jsQuery = await buildJsTopFeaturesQuery(query, this.layerId, this.viewId);
            let featureSet = await this.layer.queryTopFeatures(jsQuery, options);
            let {buildDotNetFeatureSet} = await import('./featureSet');
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
            if (dotNetFeatureSet.features.length > 0) {
                let graphics = getProtobufGraphicStream(dotNetFeatureSet.features, this.layer);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesStreamCallback', graphics, queryId);
                dotNetFeatureSet.features = [];
            }
            return dotNetFeatureSet;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryTopFeatureCount(query: DotNetTopFeaturesQuery, options: any): Promise<number> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query, this.layerId, this.viewId);
        return await this.layer.queryTopFeatureCount(jsQuery, options);
    }

    async queryTopObjectIds(query: DotNetTopFeaturesQuery, options: any): Promise<number[]> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query, this.layerId, this.viewId);
        return await this.layer.queryTopObjectIds(jsQuery, options);
    }

    async queryTopFeaturesExtent(query: DotNetTopFeaturesQuery, options: any): Promise<any> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query, this.layerId, this.viewId);
        let result = await this.layer.queryTopFeaturesExtent(jsQuery, options);
        let {buildDotNetExtent} = await import('./extent');
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }

    async applyGraphicEditsFromStream(streamRef: any, editType: string, options: any,
                                      abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) {
            return;
        }
        let graphics = await getGraphicsFromProtobufStream(streamRef) as any[];
        let result = await this.applyGraphicEdits(graphics, editType, options, abortSignal);
        return result;
    }

    async applyGraphicEditsSynchronously(graphicsArray: Uint8Array, editType: string, options: any, 
                                         abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) {
            return;
        }
        let graphics = decodeProtobufGraphics(graphicsArray);
        let result = await this.applyGraphicEdits(graphics, editType, options, abortSignal);
        return result;
    }

    async applyGraphicEdits(graphics: any[], editType: string, options: any, abortSignal: AbortSignal): Promise<any> {
        let jsGraphics: Graphic[] = [];
        let {buildJsGraphic} = await import('./graphic');
        for (const g of graphics) {
            let jsGraphic = buildJsGraphic(g) as Graphic;
            jsGraphics.push(jsGraphic);
        }
        if (abortSignal.aborted) {
            return;
        }
        let featureEdits = {};
        switch (editType) {
            case 'add':
                featureEdits['addFeatures'] = jsGraphics;
                break;
            case 'update':
                featureEdits['updateFeatures'] = jsGraphics;
                break;
            case 'delete':
                featureEdits['deleteFeatures'] = jsGraphics;
                break;
        }
        let result: __esri.EditsResult;
        if (hasValue(options)) {
            result = await this.layer.applyEdits(featureEdits, options);
        } else {
            result = await this.layer.applyEdits(featureEdits);
        }
        if (abortSignal.aborted) return;
        let {buildDotNetEditsResult} = await import('./editsResult');
        return buildDotNetEditsResult(result, this.geoBlazorId as string);
    }

    async applyAttachmentEdits(edits: any, options: any, abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) return;
        let addAttachments = edits.addAttachments?.map(e => {
            if (hasValue(e.feature)) {
                return {
                    feature: lookupJsGraphicById(e.feature.id, this.geoBlazorId, this.viewId),
                    attachment: e.attachment
                }
            } else {
                return {
                    feature: e.objectId ?? e.globalId,
                    attachment: e.attachment
                }
            }
        });
        let updateAttachments = edits.updateAttachments?.map(e => {
            if (hasValue(e.feature)) {
                return {
                    feature: lookupJsGraphicById(e.feature.id, this.geoBlazorId, this.viewId),
                    attachment: e.attachment
                }
            } else {
                return {
                    feature: e.objectId ?? e.globalId,
                    attachment: e.attachment
                }
            }
        });
        let jsEdits = {
            addAttachments: addAttachments,
            updateAttachments: updateAttachments,
            deleteAttachments: edits.deleteAttachments
        };
        let result: __esri.EditsResult;
        if (options !== null) {
            result = await this.layer.applyEdits(jsEdits, options);
        } else {
            result = await this.layer.applyEdits(jsEdits);
        }
        if (abortSignal.aborted) return;

        let {buildDotNetEditsResult} = await import('./editsResult');
        return buildDotNetEditsResult(result, this.geoBlazorId as string);
    }

    async getFeatureReduction(): Promise<any> {
        try {
            let jsFeatureReduction = this.layer.featureReduction;
            let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
            return await buildDotNetIFeatureReduction(jsFeatureReduction);
        } catch (error) {
            throw new Error("Available only in GeoBlazor Pro. " + error);
        }
    }

    async setFeatureReduction(featureReduction: any) {
        let { buildJsIFeatureReduction } = await import('./iFeatureReduction');
        let jsFeatureReduction = await buildJsIFeatureReduction(featureReduction, this.layerId, this.viewId);
        this.layer.featureReduction = jsFeatureReduction;
    }

    async getFeatureType(graphic: DotNetGraphic): Promise<any> {

        let feature = lookupJsGraphicById(graphic.id as string, this.geoBlazorId, this.viewId);

        let result = this.layer.getFeatureType(feature as Graphic);

        let {buildDotNetFeatureType} = await import('./featureType');
        return buildDotNetFeatureType(result);
    }
    
    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }

    async getTemplates(): Promise<any> {
        if (!hasValue(this.layer.templates)) {
            return null;
        }

        let { buildDotNetIFeatureTemplate } = await import('./iFeatureTemplate');
        return await Promise.all(this.layer.templates.map(async i => await buildDotNetIFeatureTemplate(i)));
    }

    async setTemplates(value: any): Promise<void> {
        let { buildJsIFeatureTemplate } = await import('./iFeatureTemplate');
        this.layer.templates = await Promise.all(value.map(async i => await buildJsIFeatureTemplate(i, this.layerId, this.viewId))) as any;
    }

    async getField(fieldName: string): Promise<DotNetField | null> {

        let result = this.layer.getField(fieldName);

        if (result != undefined) {
            let {buildDotNetField} = await import('./field');
            let field = await buildDotNetField(result);
            return field;
        }
        return null;
    }

    async getFieldDomain(fieldName: string, graphic: DotNetGraphic): Promise<DotNetDomain | null> {

        let options: any | undefined = undefined;
        let {buildJsGraphic} = await import('./graphic');
        if (hasValue(graphic)) {
            let featureGraphic = buildJsGraphic(graphic) as Graphic;
            options = {
                feature: featureGraphic
            };
        }
        let result = this.layer.getFieldDomain(fieldName, options);

        let {buildDotNetDomain} = await import('./domain');
        return buildDotNetDomain(result);
    }

    getCapabilities() {
        return this.layer.capabilities;
    }

    async clone(): Promise<DotNetFeatureLayer> {

        let result = this.layer.clone();

        return await buildDotNetFeatureLayer(result);
    }

    refresh() {

        this.layer.refresh();
    }

    async setEffect(dnEffect: any): Promise<void> {
        let {buildJsEffect} = await import('./effect');
        this.layer.effect = buildJsEffect(dnEffect);
    }

    hasValue(prop: any): boolean {
        return prop !== undefined && prop !== null;
    }


}

export async function buildJsFeatureLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureLayerGenerated} = await import('./featureLayer.gb');
    let jsFeatureLayer = await buildJsFeatureLayerGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.geometryType) && hasValue(dotNetObject.source)) {
        jsFeatureLayer.geometryType = dotNetObject.geometryType;
    }
    
    // bug is erasing the end of some urls from properties
    if (hasValue(dotNetObject.url)) {
        jsFeatureLayer.url = dotNetObject.url;
    }

    return jsFeatureLayer;
}


export async function buildDotNetFeatureLayer(jsObject: any): Promise<any> {
    let {buildDotNetFeatureLayerGenerated} = await import('./featureLayer.gb');
    return await buildDotNetFeatureLayerGenerated(jsObject);
}
