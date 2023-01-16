import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import Query from "@arcgis/core/rest/support/Query";
import Handle = __esri.Handle;
import {DotNetQuery} from "./definitions";
import {buildJsQuery} from "./jsBuilder";

export default class FeatureLayerViewWrapper {
    private featureLayerView: FeatureLayerView;
    
    constructor(featureLayerView: FeatureLayerView) {
        this.featureLayerView = featureLayerView;
        // set all properties from featureLayerView
        for (let prop in featureLayerView) {
            if (featureLayerView.hasOwnProperty(prop)) {
                this[prop] = featureLayerView[prop];
            }
        }
    }
    
    setFeatureEffect(featureEffect: FeatureEffect): void {
        this.featureLayerView.featureEffect = featureEffect;
    }
    
    setFilter(filter: any): void {
        this.featureLayerView.filter = filter;
    }
    
    setMaximumNumberOfFeatures(maximumNumberOfFeatures: number): void {
        this.featureLayerView.maximumNumberOfFeatures = maximumNumberOfFeatures;
    }
    
    createAggregateQuery(): Query {
        return this.featureLayerView.createAggregateQuery();
    }
    
    createQuery(): Query {
        return this.featureLayerView.createQuery();
    }
    
    highlight(target: any): Handle {
        return this.featureLayerView.highlight(target);
    }
    
    async queryExtent(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery = buildJsQuery(query);
        let result = await this.featureLayerView.queryExtent(jsQuery, options);
        return {
            count: result.count,
            extent: result.extent
        };
    }
    
    async queryFeatureCount(query: DotNetQuery, options: any): Promise<number> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryFeatureCount(jsQuery, options);
    }
    
    async queryFeatures(query: DotNetQuery, options: any): Promise<any> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryFeatures(jsQuery, options);
    }
    
    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryObjectIds(jsQuery, options);
    }
}