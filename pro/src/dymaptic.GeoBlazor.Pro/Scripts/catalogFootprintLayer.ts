import CatalogFootprintLayer from '@arcgis/core/layers/catalog/CatalogFootprintLayer';
// override generated code in this file
import CatalogFootprintLayerGenerated from './catalogFootprintLayer.gb';
import {buildEncodedJson} from "./geoBlazorCore";

export default class CatalogFootprintLayerWrapper extends CatalogFootprintLayerGenerated {

    constructor(layer: CatalogFootprintLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        let dotNetLayer = await buildDotNetCatalogFootprintLayer(result, this.layerId, this.viewId);
        return buildEncodedJson(dotNetLayer);
    }
}

export async function buildJsCatalogFootprintLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogFootprintLayerGenerated } = await import('./catalogFootprintLayer.gb');
    return await buildJsCatalogFootprintLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogFootprintLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogFootprintLayerGenerated } = await import('./catalogFootprintLayer.gb');
    return await buildDotNetCatalogFootprintLayerGenerated(jsObject, layerId, viewId);
}
