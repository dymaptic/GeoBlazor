// override generated code in this file
import ImageryLayerGenerated from './imageryLayer.gb';
import ImageryLayer from '@arcgis/core/layers/ImageryLayer';
import {buildEncodedJson, hasValue} from "./geoBlazorCore";
import Query from "@arcgis/core/rest/support/Query";

export default class ImageryLayerWrapper extends ImageryLayerGenerated {

    constructor(layer: ImageryLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetImageryLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }

    async queryObjectIds(query: any,
                         requestOptions: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryObjectIds(jsQuery,
            requestOptions);
    }

    async queryRasterCount(query: any,
                           requestOptions: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryRasterCount(jsQuery,
            requestOptions);
    }

    async queryRasters(query: any,
                       requestOptions: any): Promise<any> {
        let jsQuery: Query | null = null;
        if (hasValue(query)) {
            let { buildJsQuery} = await import('./query');
            jsQuery = buildJsQuery(query) as Query;
        }
        return await this.layer.queryRasters(jsQuery,
            requestOptions);
    }
}

export async function buildJsImageryLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerGenerated} = await import('./imageryLayer.gb');
    let jsObject = await buildJsImageryLayerGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        jsObject.renderer = await buildJsImageryRenderer(dotNetObject.renderer, layerId, viewId);
    }
    
    return jsObject;
}

export async function buildDotNetImageryLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetImageryLayerGenerated} = await import('./imageryLayer.gb');
    let dnObject = await buildDotNetImageryLayerGenerated(jsObject, viewId);
    
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetImageryRenderer} = await import('./imageryRenderer');
        dnObject.renderer = await buildDotNetImageryRenderer(jsObject.renderer, viewId);
    }
    
    return dnObject;
}
