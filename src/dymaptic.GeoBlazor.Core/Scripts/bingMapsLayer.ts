import BingMapsLayer from '@arcgis/core/layers/BingMapsLayer';
import BingMapsLayerGenerated from './bingMapsLayer.gb';
import {buildEncodedJson} from "./geoBlazorCore";

export default class BingMapsLayerWrapper extends BingMapsLayerGenerated {

    constructor(layer: BingMapsLayer) {
        super(layer);
    }

    getBingLogo() {
        return this.layer.bingLogo;
    }

    getCopyright() {
        return this.layer.copyright;
    }

    hasAttributionData() {
        return this.layer.hasAttributionData;
    }

    async getTileInfo() {
        let {buildDotNetTileInfo} = await import('./tileInfo');
        return buildDotNetTileInfo(this.layer.tileInfo, this.layerId, this.viewId);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetBingMapsLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsBingMapsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBingMapsLayerGenerated} = await import('./bingMapsLayer.gb');
    return await buildJsBingMapsLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBingMapsLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBingMapsLayerGenerated} = await import('./bingMapsLayer.gb');
    return await buildDotNetBingMapsLayerGenerated(jsObject, layerId, viewId);
}
