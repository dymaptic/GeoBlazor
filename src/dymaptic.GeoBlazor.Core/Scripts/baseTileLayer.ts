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
