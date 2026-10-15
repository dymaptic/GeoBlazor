import CatalogDynamicGroupLayerView from '@arcgis/core/views/layers/CatalogDynamicGroupLayerView';
import CatalogDynamicGroupLayerViewGenerated from "./catalogDynamicGroupLayerView.gb";
export async function buildJsCatalogDynamicGroupLayerView(dotNetObject: any): Promise<any> {
    let { buildJsCatalogDynamicGroupLayerViewGenerated } = await import('./catalogDynamicGroupLayerView.gb');
    return await buildJsCatalogDynamicGroupLayerViewGenerated(dotNetObject);
}     

export async function buildDotNetCatalogDynamicGroupLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogDynamicGroupLayerViewGenerated } = await import('./catalogDynamicGroupLayerView.gb');
    return await buildDotNetCatalogDynamicGroupLayerViewGenerated(jsObject, layerId, viewId);
}


export default class CatalogDynamicGroupLayerViewWrapper extends CatalogDynamicGroupLayerViewGenerated {

    constructor(component: CatalogDynamicGroupLayerView) {
        super(component);
    }
    
}

