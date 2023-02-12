import CreatePopupTemplateOptions = __esri.CreatePopupTemplateOptions;
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Query from "@arcgis/core/rest/support/Query";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import {
    DotNetExtent,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetTopFeaturesQuery
} from "./definitions";
import {buildJsQuery, buildJsRelationshipQuery, buildJsTopFeaturesQuery} from "./jsBuilder";
import {buildDotNetExtent, buildDotNetPopupTemplate} from "./dotNetBuilder";

export default class FeatureLayerWrapper {
    private layer: FeatureLayer;
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

    async queryFeatures(query: DotNetQuery, options: any): Promise<FeatureSet> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryFeatures(jsQuery, options);
    }

    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryFeatureCount(jsQuery, options);
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryObjectIds(jsQuery, options);
    }
    
    async queryRelatedFeatures(query: DotNetRelationshipQuery, options: any): Promise<FeatureSet> {
        let jsQuery = buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeatures(jsQuery, options);
    }
    
    async queryRelatedFeaturesCount(query: DotNetRelationshipQuery, options: any): Promise<number> {
        let jsQuery = buildJsRelationshipQuery(query);
        return await this.layer.queryRelatedFeaturesCount(jsQuery, options);
    }
    
    
    async queryTopFeatures(query: DotNetTopFeaturesQuery, options: any): Promise<FeatureSet> {
        try {
            let jsQuery = buildJsTopFeaturesQuery(query);
            return await this.layer.queryTopFeatures(jsQuery, options);
        }
        catch (error) {
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
}