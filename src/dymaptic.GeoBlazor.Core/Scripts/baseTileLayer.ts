import BaseTileLayerGenerated from './baseTileLayer.gb';
import BaseTileLayer from '@arcgis/core/layers/BaseTileLayer';

export default class BaseTileLayerWrapper extends BaseTileLayerGenerated {

    constructor(layer: BaseTileLayer) {
        super(layer);
    }

    getTileBounds(level: number, row: number, col: number): any {
        return this.layer.getTileBounds(level, row, col);
    }

    async setEffect(effect: any) {
        let {buildJsEffect} = await import('./effect');
        this.layer.effect = buildJsEffect(effect);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.layer.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsBaseTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseTileLayerGenerated} = await import('./baseTileLayer.gb');
    return await buildJsBaseTileLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseTileLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBaseTileLayerGenerated} = await import('./baseTileLayer.gb');
    return await buildDotNetBaseTileLayerGenerated(jsObject, viewId);
}
