// override generated code in this file
import MapImageLayerGenerated from './mapImageLayer.gb';
import MapImageLayer from '@arcgis/core/layers/MapImageLayer';
import {buildEncodedJson, hasValue} from './arcGisJsInterop';

export default class MapImageLayerWrapper extends MapImageLayerGenerated {

    constructor(layer: MapImageLayer) {
        super(layer);
    }

    async fetchImage(extent: any,
                     width: any,
                     height: any,
                     options: any): Promise<any> {
        let {buildJsExtent} = await import('./extent');
        let jsExtent = buildJsExtent(extent) as any;

        let image = await this.layer.fetchImage(jsExtent,
            width,
            height,
            options);

        if (!hasValue(image)) {
            return null;
        }
        return await DotNet.createJSObjectReference(image);
    }

    async fetchImageAsString(extent: any,
                             width: any,
                             height: any,
                             options: any): Promise<any> {
        let {buildJsExtent} = await import('./extent');
        let jsExtent = buildJsExtent(extent) as any;

        let image = await this.layer.fetchImage(jsExtent,
            width,
            height,
            options);

        if (!hasValue(image)) {
            return null;
        }
        return image.outerHTML;
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetMapImageLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsMapImageLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapImageLayerGenerated} = await import('./mapImageLayer.gb');
    return await buildJsMapImageLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapImageLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetMapImageLayerGenerated} = await import('./mapImageLayer.gb');
    return await buildDotNetMapImageLayerGenerated(jsObject, viewId);
}
