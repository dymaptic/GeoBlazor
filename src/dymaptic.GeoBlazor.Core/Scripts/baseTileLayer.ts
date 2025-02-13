import BaseTileLayerGenerated from './baseTileLayer.gb';
import BaseTileLayer from '@arcgis/core/layers/BaseTileLayer';
import {buildJsEffect} from './jsBuilder';

export default class BaseTileLayerWrapper extends BaseTileLayerGenerated {

    constructor(layer: BaseTileLayer) {
        super(layer);
    }

    getTileBounds(level: number, row: number, col: number): any {
        return this.layer.getTileBounds(level, row, col);
    }
    
    setEffect(effect: any) {
        this.layer.effect = buildJsEffect(effect);
    }
    
}
export async function buildJsBaseTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseTileLayerGenerated } = await import('./baseTileLayer.gb');
    return await buildJsBaseTileLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBaseTileLayer(jsObject: any): Promise<any> {
    let { buildDotNetBaseTileLayerGenerated } = await import('./baseTileLayer.gb');
    return await buildDotNetBaseTileLayerGenerated(jsObject);
}
