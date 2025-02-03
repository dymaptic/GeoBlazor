import BaseTileLayerGenerated from './baseTileLayer.gb';
import BaseTileLayer from '@arcgis/core/layers/BaseTileLayer';
import {buildDotNetEffect} from './dotNetBuilder';
import {buildJsEffect} from './jsBuilder';
import {IPropertyWrapper} from './definitions';

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
export async function buildJsBaseTileLayer(dotNetObject: any): Promise<any> {
    let { buildJsBaseTileLayerGenerated } = await import('./baseTileLayer.gb');
    return await buildJsBaseTileLayerGenerated(dotNetObject);
}
export async function buildDotNetBaseTileLayer(jsObject: any): Promise<any> {
    let { buildDotNetBaseTileLayerGenerated } = await import('./baseTileLayer.gb');
    return await buildDotNetBaseTileLayerGenerated(jsObject);
}
