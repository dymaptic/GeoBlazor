import CreatePopupTemplateOptions = __esri.CreatePopupTemplateOptions;
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Query from "@arcgis/core/rest/support/Query";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import {DotNetExtent, DotNetPopupTemplate, DotNetQuery} from "./definitions";
import {buildJsQuery} from "./jsBuilder";
import {buildDotNetExtent, buildDotNetPopupTemplate} from "./dotNetBuilder";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import MapView from "@arcgis/core/views/MapView";

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
    
    async load(abortSignal: AbortSignal): Promise<void> {
        await this.layer.load(abortSignal);
    }

    createQuery(): Query {
        return this.layer.createQuery();
    }

    async queryExtent(query: DotNetQuery, abortSignal: AbortSignal): Promise<any> {
        let jsQuery = buildJsQuery(query);
        let result = await this.layer.queryExtent(jsQuery, abortSignal);
        return {
            count: result.count,
            extent: buildDotNetExtent(result.extent)
        };
    }

    async queryFeatures(query: DotNetQuery, abortSignal: AbortSignal): Promise<FeatureSet> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryFeatures(jsQuery, abortSignal);
    }

    async queryFeatureCount(query: DotNetQuery, abortSignal: AbortSignal): Promise<number> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryFeatureCount(jsQuery, abortSignal);
    }

    async queryObjectIds(query: DotNetQuery, abortSignal: AbortSignal): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryObjectIds(jsQuery, abortSignal);
    }
    
    async queryRelatedFeatures(query: DotNetQuery, abortSignal: AbortSignal): Promise<FeatureSet> {
        let jsQuery = buildJsQuery(query);
        return await this.layer.queryRelatedFeatures(jsQuery, abortSignal);
    }
}