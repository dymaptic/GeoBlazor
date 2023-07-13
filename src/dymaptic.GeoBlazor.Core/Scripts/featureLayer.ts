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
    DotNetTopFeaturesQuery
} from "./definitions";
import {buildJsApplyEdits, buildJsQuery, buildJsRelationshipQuery, buildJsTopFeaturesQuery} from "./jsBuilder";
import {
    buildDotNetExtent,
    buildDotNetGeometry,
    buildDotNetGraphic,
    buildDotNetPopupTemplate,
    buildDotNetSpatialReference
} from "./dotNetBuilder";
import {blazorServer, dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import Graphic from "@arcgis/core/Graphic";

export default class FeatureLayerWrapper {
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

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery = buildJsQuery(query);
            let featureSet = await this.layer.queryFeatures(jsQuery, options);
            let dotNetFeatureSet : DotNetFeatureSet = {
                features: [],
                displayFieldName: featureSet.displayFieldName,
                exceededTransferLimit: featureSet.exceededTransferLimit,
                fields: featureSet.fields,
                geometryType: featureSet.geometryType,
                queryGeometry: buildDotNetGeometry(featureSet.queryGeometry),
                spatialReference: buildDotNetSpatialReference(featureSet.spatialReference)
            };
            let graphics : DotNetGraphic[] = [];
            for (let i = 0; i < featureSet.features.length; i++) {
                let feature = featureSet.features[i];
                let graphic : DotNetGraphic = buildDotNetGraphic(feature) as DotNetGraphic;
                if (viewId !== undefined && viewId !== null) {
                    graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
                    graphicsRefs[graphic.id as string] = feature;
                }
                graphics.push(graphic);
            }
            dotNetFeatureSet.features = graphics;
            if (!blazorServer || dotNetRef === undefined || dotNetRef === null) {
                return dotNetFeatureSet;
            }
            let jsonSet = JSON.stringify(dotNetFeatureSet);
            let chunkSize = 1000;
            let chunks = Math.ceil(jsonSet.length / chunkSize);
            for (let i = 0; i < chunks; i++) {
                let chunk = jsonSet.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesCreateChunk', chunk, i);
            }
            return null;
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

    async queryRelatedFeatures(query: DotNetRelationshipQuery, options: any, dotNetRef: any, viewId: string | null)
        : Promise<any | null> {
        try {
            let jsQuery = buildJsRelationshipQuery(query);
            let featureSetsDictionary = await this.layer.queryRelatedFeatures(jsQuery, options);
            let graphicsDictionary : any = {};
            for (let prop in featureSetsDictionary) {
                if (featureSetsDictionary.hasOwnProperty(prop)) {
                    let featureSet = featureSetsDictionary[prop] as FeatureSet;
                    let dotNetFeatureSet : DotNetFeatureSet = {
                        features: [],
                        displayFieldName: featureSet.displayFieldName,
                        exceededTransferLimit: featureSet.exceededTransferLimit,
                        fields: featureSet.fields,
                        geometryType: featureSet.geometryType,
                        queryGeometry: buildDotNetGeometry(featureSet.queryGeometry),
                        spatialReference: buildDotNetSpatialReference(featureSet.spatialReference)
                    };
                    let graphics : DotNetGraphic[] = [];
                    for (let i = 0; i < featureSet.features.length; i++) {
                        let feature = featureSet.features[i];
                        let graphic : DotNetGraphic = buildDotNetGraphic(feature) as DotNetGraphic;
                        if (viewId !== undefined && viewId !== null) {
                            graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
                            graphicsRefs[graphic.id as string] = feature;
                        }
                        graphics.push(graphic);
                    }
                    dotNetFeatureSet.features = graphics;
                    graphicsDictionary[prop] = dotNetFeatureSet;
                }
            }
            if (!blazorServer) {
                return graphicsDictionary;
            }
            let jsonSet = JSON.stringify(graphicsDictionary);
            let chunkSize = 1000;
            let chunks = Math.ceil(jsonSet.length / chunkSize);
            for (let i = 0; i < chunks; i++) {
                let chunk = jsonSet.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesCreateChunk', chunk, i);
            }
            return null;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryRelatedFeaturesCount(query: DotNetRelationshipQuery, options: any): Promise<number> {
        let jsQuery = buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeaturesCount(jsQuery, options);
    }


    async queryTopFeatures(query: DotNetTopFeaturesQuery, options: any, dotNetRef: any, viewId: string | null)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery = buildJsTopFeaturesQuery(query);
            let featureSet = await this.layer.queryTopFeatures(jsQuery, options);
            let dotNetFeatureSet : DotNetFeatureSet = {
                features: [],
                displayFieldName: featureSet.displayFieldName,
                exceededTransferLimit: featureSet.exceededTransferLimit,
                fields: featureSet.fields,
                geometryType: featureSet.geometryType,
                queryGeometry: buildDotNetGeometry(featureSet.queryGeometry),
                spatialReference: buildDotNetSpatialReference(featureSet.spatialReference)
            };
            let graphics : DotNetGraphic[] = [];
            for (let i = 0; i < featureSet.features.length; i++) {
                let feature = featureSet.features[i];
                let graphic : DotNetGraphic = buildDotNetGraphic(feature) as DotNetGraphic;
                if (viewId !== undefined && viewId !== null) {
                    graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
                    graphicsRefs[graphic.id as string] = feature;
                }
                graphics.push(graphic);
            }
            dotNetFeatureSet.features = graphics;
            if (!blazorServer) {
                return dotNetFeatureSet;
            }
            let jsonSet = JSON.stringify(dotNetFeatureSet);
            let chunkSize = 1000;
            let chunks = Math.ceil(jsonSet.length / chunkSize);
            for (let i = 0; i < chunks; i++) {
                let chunk = jsonSet.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesCreateChunk', chunk, i);
            }
            return null;
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
    
    async applyEdits(edits: DotNetApplyEdits, options: any, viewId: string): Promise<any> {
        let jsEdits = buildJsApplyEdits(edits, viewId);
        let result;
        if (options !== null) {
            result = await this.layer.applyEdits(jsEdits, options);
        } else {
            result = await this.layer.applyEdits(jsEdits);
        }
        
        return result;
    }
}