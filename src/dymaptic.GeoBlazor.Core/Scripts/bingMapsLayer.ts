import BingMapsLayerGenerated from './bingMapsLayer.gb';
import BingMapsLayer from "@arcgis/core/layers/BingMapsLayer";

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
    
    async getTileInfo() {
        let { buildDotNetTileInfo } = await import('./tileInfo');
        return buildDotNetTileInfo(this.layer.tileInfo);
    }
}

export async function buildJsBingMapsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBingMapsLayerGenerated } = await import('./bingMapsLayer.gb');
    return await buildJsBingMapsLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBingMapsLayer(jsObject: any): Promise<any> {
    let { buildDotNetBingMapsLayerGenerated } = await import('./bingMapsLayer.gb');
    return await buildDotNetBingMapsLayerGenerated(jsObject);
}
