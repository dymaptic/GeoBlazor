import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import Query from "@arcgis/core/rest/support/Query";
import {
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetFeatureSet,
    DotNetGraphic,
    DotNetQuery,
    IPropertyWrapper
} from "./definitions";
import {buildJsFeatureEffect, buildJsFeatureFilter, buildJsQuery} from "./jsBuilder";
import {blazorServer, dotNetRefs, getProtobufGraphicStream, graphicsRefs, hasValue} from "./arcGisJsInterop";
import {
    buildDotNetFeatureSet,
    buildDotNetGeometry,
    buildDotNetGraphic,
    buildDotNetSpatialReference
} from "./dotNetBuilder";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import Handle = __esri.Handle;

export default class FeatureLayerViewWrapper implements IPropertyWrapper {
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

    unwrap() {
        return this.featureLayerView;
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

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null, queryId: string)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery: Query | undefined = undefined;

            if (hasValue(query)) {
                jsQuery = buildJsQuery(query as DotNetQuery);
            }

            let featureSet = await this.featureLayerView.queryFeatures(jsQuery, options);

            let dotNetFeatureSet = await buildDotNetFeatureSet(featureSet, viewId);
            if (dotNetFeatureSet.features.length > 0) {
                let graphics = getProtobufGraphicStream(dotNetFeatureSet.features);
                await dotNetRef.invokeMethodAsync('OnQueryFeaturesStreamCallback', graphics, queryId);
                dotNetFeatureSet.features = [];
            }

            return dotNetFeatureSet;
        } catch (error) {
            console.debug(error);
            throw error;
        }
    }

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryObjectIds(jsQuery, options);
    }

    setProperty(prop: string, value: any): void {
        this.featureLayerView[prop] = value;
    }
}