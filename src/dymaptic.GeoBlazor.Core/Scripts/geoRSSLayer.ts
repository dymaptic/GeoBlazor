// override generated code in this file
import GeoRSSLayerGenerated from './geoRSSLayer.gb';
import GeoRSSLayer from '@arcgis/core/layers/GeoRSSLayer';
import {buildEncodedJson} from "./geoBlazorCore";

export default class GeoRSSLayerWrapper extends GeoRSSLayerGenerated {

    constructor(layer: GeoRSSLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetGeoRSSLayer(result, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }

    async getPointSymbol(): Promise<any> {
        switch (this.layer.pointSymbol?.type) {
            case 'picture-marker':
                let {buildDotNetPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
                return await buildDotNetPictureMarkerSymbol(this.layer.pointSymbol);
            case 'simple-marker':
                let {buildDotNetSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
                return await buildDotNetSimpleMarkerSymbol(this.layer.pointSymbol);
        }
    }

    async setPointSymbol(value: any): Promise<void> {
        switch (value.type) {
            case 'picture-marker':
                let {buildJsPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
                this.layer.pointSymbol = await buildJsPictureMarkerSymbol(value);
                break;
            case 'simple-marker':
                let {buildJsSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
                this.layer.pointSymbol = await buildJsSimpleMarkerSymbol(value);
                break;
        }
    }
}

export async function buildJsGeoRSSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeoRSSLayerGenerated} = await import('./geoRSSLayer.gb');
    return await buildJsGeoRSSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeoRSSLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetGeoRSSLayerGenerated} = await import('./geoRSSLayer.gb');
    return await buildDotNetGeoRSSLayerGenerated(jsObject, viewId);
}
