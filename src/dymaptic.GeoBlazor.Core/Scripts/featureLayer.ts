import CreatePopupTemplateOptions = __esri.CreatePopupTemplateOptions;
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Query from "@arcgis/core/rest/support/Query";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import {
    DotNetApplyEdits,
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
    buildJsApplyEdits,
    buildJsQuery,
    buildJsRelationshipQuery,
    buildJsTopFeaturesQuery,
    buildJsPortalItem,
    buildJsGraphic, buildJsEffect, buildJsAttachmentEdit
} from "./jsBuilder";
import {
    buildDotNetExtent,
    buildDotNetGeometry,
    buildDotNetGraphic,
    buildDotNetPopupTemplate,
    buildDotNetSpatialReference,
    buildDotNetFields,
    buildDotNetFeatureLayer,
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
    getProtobufGraphicStream
} from "./arcGisJsInterop";
import Graphic from "@arcgis/core/Graphic";

export default class FeatureLayerWrapper implements IPropertyWrapper {
    public layer: FeatureLayer;

    constructor(layer: FeatureLayer) {
        this.layer = layer;
        // set all properties from layer
        for (let prop in layer) {
            if (layer.hasOwnProperty(prop)) {
                this[prop] = layer[prop];
            }
        }
    }
    
    unwrap() {
        return this.layer;
    }

    createPopupTemplate(options: CreatePopupTemplateOptions | null): DotNetPopupTemplate {
        let jsPopupTemplate = options === null
            ? this.layer.createPopupTemplate()
            : this.layer.createPopupTemplate(options);
        return buildDotNetPopupTemplate(jsPopupTemplate);
    }

    async load(options: AbortSignal): Promise<void> {
        await this.layer.load(options);
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

            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
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
                    let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
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
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
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
        let result = await this.applyGraphicEdits(graphics, editType, options, viewId, abortSignal);
        return result;
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
            let jsGraphic = buildJsGraphic(g, viewId) as Graphic;
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
        (async () => {
            for (let i = 0; i < jsGraphics.length; i++) {
                let graphic = jsGraphics[i];
                let graphicObject = graphics[i];
                graphicsRefs[graphicObject.id] = graphic;
            }
        })();
        let dnResult = buildDotNetEditsResult(result);
        return dnResult;
    }
    
    async applyAttachmentEdits(edits: any, options: any, viewId: string,
                                abortSignal: AbortSignal): Promise<any> {
        if (abortSignal.aborted) return;
        let addAttachments = edits.addAttachments?.map(e => {
            if (hasValue(e.feature)) {
                return {
                    feature: graphicsRefs[e.feature],
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
                    feature: graphicsRefs[e.feature],
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

        let dnResult = buildDotNetEditsResult(result);
        return dnResult;
    }

    async getFeatureType(graphic: DotNetGraphic): Promise<any> {

        let feature = graphicsRefs[graphic.id as string] as Graphic;

        let result = this.layer.getFeatureType(feature);

        return buildDotNetFeatureType(result);
    }

    async getField(fieldName: string): Promise<DotNetField | null> {

        let result = await this.layer.getField(fieldName);

        if (result != undefined) {
            let field = buildDotNetFields([result]);

            return field[0];
        }
        return null;
    }

    async getFieldDomain(fieldName: string, graphic: DotNetGraphic): Promise<DotNetDomain | null> {

        let options: any | undefined = undefined;
        if (graphic != null && graphic != undefined) {
            let featureGraphic = buildJsGraphic(graphic, null) as Graphic;
            options = {
                feature: featureGraphic
            };
        }
        let result = await this.layer.getFieldDomain(fieldName, options);

        let domain = buildDotNetDomain(result);

        return domain;
    }

    getCapabilities() {
        return this.layer.capabilities;
    }

    async clone(): Promise<DotNetFeatureLayer> {

        let result = await this.layer.clone();

        return buildDotNetFeatureLayer(result);
    }

    async refresh(): Promise<DotNetFeatureLayer> {

        await this.layer.refresh();

        return buildDotNetFeatureLayer(this.layer);
    }

    setEffect(dnEffect: any): void {
        let jsEffect = buildJsEffect(dnEffect);
        this.layer.effect = jsEffect;
    }
    hasValue(prop: any): boolean {
        return prop !== undefined && prop !== null;
    }

    setProperty(prop: string, value: any): void {
        this.layer[prop] = value;
    }

    getProperty(prop: string) {
        return this.layer[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].addMany(value);
        } else {
            this.layer[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].removeMany(value);
        } else {
            this.layer[prop].remove(value);
        }
    }
}
