import FeatureLayerView from "@arcgis/core/views/layers/FeatureLayerView";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import Query from "@arcgis/core/rest/support/Query";
import {DotNetFeatureSet, DotNetGraphic, DotNetQuery} from "./definitions";
import {buildJsQuery} from "./jsBuilder";
import {blazorServer, dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import Handle = __esri.Handle;
import {buildDotNetGeometry, buildDotNetGraphic, buildDotNetSpatialReference} from "./dotNetBuilder";

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

    async queryFeatures(query: DotNetQuery, options: any, dotNetRef: any, viewId: string | null)
        : Promise<DotNetFeatureSet | null> {
        try {
            let jsQuery = buildJsQuery(query);
            let featureSet = await this.featureLayerView.queryFeatures(jsQuery, options);
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

    async queryObjectIds(query: DotNetQuery, options: any): Promise<number[]> {
        let jsQuery = buildJsQuery(query);
        return await this.featureLayerView.queryObjectIds(jsQuery, options);
    }
}