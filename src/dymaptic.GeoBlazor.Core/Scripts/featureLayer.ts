import FeatureLayerGenerated from './featureLayer.gb';
import CreatePopupTemplateOptions = __esri.CreatePopupTemplateOptions;
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Query from "@arcgis/core/rest/support/Query";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import {
    DotNetFeatureSet,
    DotNetGraphic,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetTopFeaturesQuery,
    DotNetField,
    DotNetDomain,
    DotNetFeatureLayer, IPropertyWrapper
} from "./definitions";
import {
    buildJsQuery,
    buildJsRelationshipQuery,
    buildJsTopFeaturesQuery,
    buildJsGraphic, 
    buildJsEffect
} from "./jsBuilder";
import {
    buildDotNetExtent,
    buildDotNetPopupTemplate,
    buildDotNetFields,
    buildDotNetDomain,
    buildDotNetFeatureType,
    buildDotNetEditsResult, 
    buildDotNetFeatureSet,
} from "./dotNetBuilder";
import {
    graphicsRefs,
    getGraphicsFromProtobufStream,
    hasValue,
    decodeProtobufGraphics,
    getProtobufGraphicStream,
    arcGisObjectRefs, lookupGraphicById
} from "./arcGisJsInterop";
import Graphic from "@arcgis/core/Graphic";

export default class FeatureLayerWrapper extends FeatureLayerGenerated {

    constructor(layer: FeatureLayer) {
        super(layer);
    }
    

    createPopupTemplate(options: CreatePopupTemplateOptions | null): DotNetPopupTemplate {
        let jsPopupTemplate = options === null
            ? this.layer.createPopupTemplate()
            : this.layer.createPopupTemplate(options);
        return buildDotNetPopupTemplate(jsPopupTemplate);
    }


    createQuery(): Query {
        return this.layer.createQuery();
    }

    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery = buildJsQuery(query);
        let result = await this.layer.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }

    async queryFeatures(query: DotNetQuery | null, options: any, dotNetRef: any, viewId: string | null, queryId: string):
        Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery: Query | undefined = undefined;

            if (this.hasValue(query)) {
                jsQuery = buildJsQuery(query as DotNetQuery);
            }

            let featureSet = await this.layer.queryFeatures(jsQuery, options);

            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, viewId);
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
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryFeatureCount(jsQuery, options);
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryObjectIds(jsQuery, options);
    }

    async queryRelatedFeatures(query: DotNetRelationshipQuery, options: any, dotNetRef: any, viewId: string | null, 
                               queryId: string): Promise<any | null> {
        try {
            let jsQuery = buildJsRelationshipQuery(query);
            let featureSetsDictionary = await this.layer.queryRelatedFeatures(jsQuery, options);
            let graphicsDictionary: any = {};
            for (let prop in featureSetsDictionary) {
                if (featureSetsDictionary.hasOwnProperty(prop)) {
                    let featureSet = featureSetsDictionary[prop] as FeatureSet;
                    let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, viewId);
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
        let jsQuery = buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeaturesCount(jsQuery, options);
    }


    async queryTopFeatures(query: DotNetTopFeaturesQuery, options: any, dotNetRef: any, viewId: string | null,
                           queryId: string): Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery = buildJsTopFeaturesQuery(query);
            let featureSet = await this.layer.queryTopFeatures(jsQuery, options);
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, this.geoBlazorId, viewId);
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
        let jsQuery = buildJsTopFeaturesQuery(query);
        return await this.layer.queryTopFeatureCount(jsQuery, options);
    }

    async queryTopObjectIds(query: DotNetTopFeaturesQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsTopFeaturesQuery(query);
        return await this.layer.queryTopObjectIds(jsQuery, options);
    }

    async queryTopFeaturesExtent(query: DotNetTopFeaturesQuery, options: any): Promise<any> {
        let jsQuery = buildJsTopFeaturesQuery(query);
        let result = await this.layer.queryTopFeaturesExtent(jsQuery, options);
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }
    
    async applyGraphicEditsFromStream(streamRef: any, editType: string, options: any, 
                               viewId: string, abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) {
            return;
        }
        let graphics = await getGraphicsFromProtobufStream(streamRef) as any[];
        return await this.applyGraphicEdits(graphics, editType, options, viewId, abortSignal);
    }
    
    async applyGraphicEditsSynchronously(graphicsArray: Uint8Array, editType: string, options: any, 
                                  viewId: string, abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) {
            return;
        }
        let graphics = decodeProtobufGraphics(graphicsArray);
        return await this.applyGraphicEdits(graphics, editType, options, viewId, abortSignal);
    }
    
    async applyGraphicEdits(graphics: any[], editType: string, options: any, viewId: string,
        abortSignal: AbortSignal): Promise<any> {
        let jsGraphics: Graphic[] = [];
        for (const g of graphics) {
            let jsGraphic = buildJsGraphic(g, this.geoBlazorId, viewId) as Graphic;
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
        return buildDotNetEditsResult(result, this.geoBlazorId);
    }
    
    async applyAttachmentEdits(edits: any, options: any, viewId: string,
                                abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) return;
        let addAttachments = edits.addAttachments?.map(e => {
            if (hasValue(e.feature)) {
                return {
                    feature: lookupGraphicById(e.feature.id, this.geoBlazorId, viewId),
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
                    feature: lookupGraphicById(e.feature.id, this.geoBlazorId, viewId),
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

        return buildDotNetEditsResult(result, this.geoBlazorId);
    }

    async getFeatureType(graphic: DotNetGraphic, viewId: string | null): Promise<any> {
        
        let feature = lookupGraphicById(graphic.id as string, this.geoBlazorId, viewId);

        let result = this.layer.getFeatureType(feature as Graphic);

        return buildDotNetFeatureType(result);
    }

    getField(fieldName: string): DotNetField | null {

        let result = this.layer.getField(fieldName);

        if (result != undefined) {
            let field = buildDotNetFields([result]);

            return field[0];
        }
        return null;
    }

    getFieldDomain(fieldName: string, graphic: DotNetGraphic): DotNetDomain | null {

        let options: any | undefined = undefined;
        if (hasValue(graphic)) {
            let featureGraphic = buildJsGraphic(graphic, this.geoBlazorId, null) as Graphic;
            options = {
                feature: featureGraphic
            };
        }
        let result = this.layer.getFieldDomain(fieldName, options);

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

    setEffect(dnEffect: any): void {
        this.layer.effect = buildJsEffect(dnEffect);
    }
    hasValue(prop: any): boolean {
        return prop !== undefined && prop !== null;
    }




}
export async function buildJsFeatureLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerGenerated } = await import('./featureLayer.gb');
    return await buildJsFeatureLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureLayer(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerGenerated } = await import('./featureLayer.gb');
    return await buildDotNetFeatureLayerGenerated(jsObject);
}
