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
    buildEncodedJson,
    decodeProtobufGraphics,
    getGraphicsFromProtobufStream,
    getProtobufGraphicStream,
    hasValue,
    lookupJsGraphicById
} from './geoBlazorCore';
import Graphic from "@arcgis/core/Graphic";
import {buildDotNetPopupTemplate} from './popupTemplate';
import {buildJsGraphic} from "./graphic";
import {buildDotNetQuery} from "./query";
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


    async createQuery(): Promise<DotNetQuery> {
        let jsQuery = this.layer.createQuery();
        return await buildDotNetQuery(jsQuery, this.viewId);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetFeatureLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        let {buildDotNetExtent} = await import('./extent');
        let result = await this.layer.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }

    async queryFeatures(query: DotNetQuery | null, signal: AbortSignal):
        Promise<DotNetFeatureSet | null> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }

        let featureSet = await this.layer.queryFeatures(jsQuery, { signal: signal });

        let {buildDotNetFeatureSet} = await import('./featureSet');
        return await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryFeatureCount(jsQuery, options);
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        let result = await this.layer.queryObjectIds(jsQuery, options);
        return result as number[];
    }

    async queryRelatedFeatures(query: DotNetRelationshipQuery, signal: AbortSignal): Promise<any | null> {
        let { buildJsRelationshipQuery} = await import('./relationshipQuery');
        let jsQuery = await buildJsRelationshipQuery(query);
        let featureSetsDictionary = await this.layer.queryRelatedFeatures(jsQuery, { signal: signal });
        let graphicsDictionary: any = {};
        let {buildDotNetFeatureSet} = await import('./featureSet');
        for (let prop in featureSetsDictionary) {
            if (featureSetsDictionary.hasOwnProperty(prop)) {
                let featureSet = featureSetsDictionary[prop] as FeatureSet;
                graphicsDictionary[prop] = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
            }
        }
        return graphicsDictionary;
    }

    async queryRelatedFeaturesCount(query: DotNetRelationshipQuery, options: any): Promise<number> {
        let { buildJsRelationshipQuery} = await import('./relationshipQuery');
        let jsQuery = await buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeaturesCount(jsQuery, options);
    }


    async queryTopFeatures(query: DotNetTopFeaturesQuery, signal: AbortSignal): Promise<DotNetFeatureSet | null> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query);
        let featureSet = await this.layer.queryTopFeatures(jsQuery, { signal: signal });
        let {buildDotNetFeatureSet} = await import('./featureSet');
        return await buildDotNetFeatureSet(featureSet, this.geoBlazorId, this.viewId);
    }

    async queryTopFeatureCount(query: DotNetTopFeaturesQuery, options: any): Promise<number> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query);
        return await this.layer.queryTopFeatureCount(jsQuery, options);
    }

    async queryTopObjectIds(query: DotNetTopFeaturesQuery, options: any): Promise<number[]> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query);
        return await this.layer.queryTopObjectIds(jsQuery, options);
    }

    async queryTopFeaturesExtent(query: DotNetTopFeaturesQuery, options: any): Promise<any> {
        let { buildJsTopFeaturesQuery} = await import('./topFeaturesQuery');
        let jsQuery = await buildJsTopFeaturesQuery(query);
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
        if (editType === 'add' || editType === 'update') {
            // add needs built, update needs property checking
            for (const g of graphics) {
                let jsGraphic = buildJsGraphic(g) as Graphic;
                jsGraphics.push(jsGraphic);
            }
        } else {
            // delete can just be looked up if they exist
            for (const g of graphics) {
                let jsGraphic = lookupJsGraphicById(g.id, g.layerId, g.viewId)
                    ?? buildJsGraphic(g) as Graphic;
                jsGraphics.push(jsGraphic);
            }
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
        return buildDotNetEditsResult(result, this.geoBlazorId as string, this.viewId);
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
        return buildDotNetEditsResult(result, this.geoBlazorId as string, this.viewId);
    }

    async getFeatureReduction(): Promise<any> {
        try {
            let jsFeatureReduction = this.layer.featureReduction;
            let { buildDotNetIFeatureReduction } = await import('./iFeatureReduction');
            return await buildDotNetIFeatureReduction(jsFeatureReduction, this.viewId);
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
        return await Promise.all(this.layer.templates!.map(async i => await buildDotNetIFeatureTemplate(i)));
    }

    async setTemplates(value: any): Promise<void> {
        let { buildJsIFeatureTemplate } = await import('./iFeatureTemplate');
        this.layer.templates = await Promise.all(value.map(async i => await buildJsIFeatureTemplate(i))) as any;
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

        return await buildDotNetFeatureLayer(result, this.viewId);
    }

    async refresh() {

        this.layer.refresh();
        return await buildDotNetFeatureLayer(this.layer, this.viewId);
    }

    async setEffect(dnEffect: any): Promise<void> {
        let {buildJsEffect} = await import('./effect');
        this.layer.effect = buildJsEffect(dnEffect);
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

    if (hasValue(dotNetObject.source)) {
        jsFeatureLayer.source = dotNetObject.source.map(i => buildJsGraphic(i)) as any;
    }

    if (!hasValue(jsFeatureLayer.spatialReference)) {
        jsFeatureLayer.spatialReference = {wkid: 4326};
    }

    return jsFeatureLayer;
}


export async function buildDotNetFeatureLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetFeatureLayerGenerated} = await import('./featureLayer.gb');
    return await buildDotNetFeatureLayerGenerated(jsObject, viewId);
}
