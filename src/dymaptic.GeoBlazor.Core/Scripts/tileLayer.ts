// override generated code in this file
import TileLayerGenerated from './tileLayer.gb';
import TileLayer from '@arcgis/core/layers/TileLayer';

export default class TileLayerWrapper extends TileLayerGenerated {

    constructor(layer: TileLayer) {
        super(layer);
    }

}

export async function buildJsTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileLayerGenerated} = await import('./tileLayer.gb');
    return await buildJsTileLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetTileLayerGenerated} = await import('./tileLayer.gb');
    return await buildDotNetTileLayerGenerated(jsObject, layerId, viewId);
}
