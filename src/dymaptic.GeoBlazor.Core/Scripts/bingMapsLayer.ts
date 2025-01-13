import BingMapsLayer from "@arcgis/core/layers/BingMapsLayer";
import BaseTileLayerWrapper from "./baseTileLayer";
import {buildJsEffect} from "./jsBuilder";
import {buildDotNetEffect, buildDotNetTileInfo} from "./dotNetBuilder";

export default class BingMapsLayerWrapper extends BaseTileLayerWrapper {
    public layer: BingMapsLayer;
    
    constructor(layer: BingMapsLayer) {
        super(layer);
        this.layer = layer;
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