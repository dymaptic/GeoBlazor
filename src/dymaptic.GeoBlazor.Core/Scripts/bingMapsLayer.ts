import BingMapsLayerGenerated from './bingMapsLayer.gb';
import BingMapsLayer from "@arcgis/core/layers/BingMapsLayer";
import BaseTileLayerWrapper from "./baseTileLayer";
import {buildJsEffect} from "./jsBuilder";
import {buildDotNetEffect, buildDotNetTileInfo} from "./dotNetBuilder";

export default class BingMapsLayerWrapper extends BingMapsLayerGenerated {
    
    constructor(layer: BingMapsLayer) {
        super(layer);
    }
    
    getBingLogo() {
        return this.layer.bingLogo;
    }
    
    getCopyright() {
        return this.layer.copyright;
    }
    
    hasAttributionData() {
        return this.layer.hasAttributionData;
    }
    
    getTileInfo() {
        return buildDotNetTileInfo(this.layer.tileInfo);
    }
}
