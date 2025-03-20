// override generated code in this file
import MapImageLayerGenerated from './mapImageLayer.gb';
import MapImageLayer from '@arcgis/core/layers/MapImageLayer';

export default class MapImageLayerWrapper extends MapImageLayerGenerated {

    constructor(layer: MapImageLayer) {
        super(layer);
    }

}

export async function buildJsMapImageLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapImageLayerGenerated} = await import('./mapImageLayer.gb');
    return await buildJsMapImageLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapImageLayer(jsObject: any): Promise<any> {
    let {buildDotNetMapImageLayerGenerated} = await import('./mapImageLayer.gb');
    return await buildDotNetMapImageLayerGenerated(jsObject);
}
