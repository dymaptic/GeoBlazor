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

    getProperty(prop: string) {
        return this.layer[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].addMany(value);
        } else {
            this.layer[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.layer[prop].removeMany(value);
        } else {
            this.layer[prop].remove(value);
        }
    }
}