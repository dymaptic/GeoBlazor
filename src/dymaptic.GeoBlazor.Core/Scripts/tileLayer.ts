// override generated code in this file
import TileLayerGenerated from './tileLayer.gb';
import TileLayer from '@arcgis/core/layers/TileLayer';
import {hasValue} from "./arcGisJsInterop";

export default class TileLayerWrapper extends TileLayerGenerated {

    constructor(layer: TileLayer) {
        super(layer);
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

export async function buildDotNetTileLayer(jsObject: any): Promise<any> {
    let {buildDotNetTileLayerGenerated} = await import('./tileLayer.gb');
    return await buildDotNetTileLayerGenerated(jsObject);
}
