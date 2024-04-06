import BaseTileLayer from "@arcgis/core/layers/BaseTileLayer";
import {buildDotNetEffect} from "./dotNetBuilder";
import {buildJsEffect} from "./jsBuilder";
import {IPropertyWrapper} from "./definitions";

export default class BaseTileLayerWrapper implements IPropertyWrapper {
    public layer: BaseTileLayer;

    constructor(btLayer: BaseTileLayer) {
        this.layer = btLayer;
    }

    unwrap() {
        return this.layer;
    }
    getTileBounds(level: number, row: number, col: number): any {
        return this.layer.getTileBounds(level, row, col);
    }
    
    setEffect(effect: any) {
        this.layer.effect = buildJsEffect(effect);
    }

    setProperty(prop: string, value: any): void {
        this.layer[prop] = value;
    }
}