// override generated code in this file
import TileLayerGenerated from './tileLayer.gb';
import TileLayer from '@arcgis/core/layers/TileLayer';
import {buildEncodedJson, hasValue} from "./geoBlazorCore";

export default class TileLayerWrapper extends TileLayerGenerated {

    constructor(layer: TileLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        return await buildDotNetTileLayer(result, this.viewId);
    }
}

export async function buildJsTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileLayerGenerated} = await import('./tileLayer.gb');
    let jsObject = await buildJsTileLayerGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.url)) {
        jsObject.url = dotNetObject.url;
    }
    
    return jsObject;
}

export async function buildDotNetTileLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetTileLayerGenerated} = await import('./tileLayer.gb');
    return await buildDotNetTileLayerGenerated(jsObject, viewId);
}
