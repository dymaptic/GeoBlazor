// override generated code in this file
import CatalogDynamicGroupLayerGenerated from './catalogDynamicGroupLayer.gb';
import CatalogDynamicGroupLayer from '@arcgis/core/layers/catalog/CatalogDynamicGroupLayer';

export default class CatalogDynamicGroupLayerWrapper extends CatalogDynamicGroupLayerGenerated {

    constructor(layer: CatalogDynamicGroupLayer) {
        super(layer);
    }
    
}

export async function buildJsCatalogDynamicGroupLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogDynamicGroupLayerGenerated } = await import('./catalogDynamicGroupLayer.gb');
    return await buildJsCatalogDynamicGroupLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogDynamicGroupLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogDynamicGroupLayerGenerated } = await import('./catalogDynamicGroupLayer.gb');
    return await buildDotNetCatalogDynamicGroupLayerGenerated(jsObject, viewId);
}
