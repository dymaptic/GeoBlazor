import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import Query from "@arcgis/core/rest/support/Query";
import {DotNetFeatureEffect, DotNetFeatureFilter, DotNetFeatureSet, DotNetGraphic, DotNetQuery} from "./definitions";
import {buildJsFeatureEffect, buildJsFeatureFilter, buildJsQuery} from "./jsBuilder";
import {blazorServer, dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import {
    buildDotNetFeatureSet,
    buildDotNetGeometry,
    buildDotNetGraphic,
    buildDotNetSpatialReference
} from "./dotNetBuilder";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import Handle = __esri.Handle;

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

    setFeatureEffect(dnfeatureEffect: DotNetFeatureEffect): void {
        this.featureLayerView.featureEffect = buildJsFeatureEffect(dnfeatureEffect) as FeatureEffect;
    }

    setFilter(dnDeatureFilter: DotNetFeatureFilter): void {
        this.featureLayerView.filter = buildJsFeatureFilter(dnDeatureFilter) as FeatureFilter;
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

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery = buildJsQuery(query);
            let featureSet = await this.featureLayerView.queryFeatures(jsQuery, options);
            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
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

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryObjectIds(jsQuery, options);
    }
}