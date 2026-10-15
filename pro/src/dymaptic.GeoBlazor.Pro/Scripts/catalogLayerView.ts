import CatalogLayerView from "@arcgis/core/views/layers/CatalogLayerView";
import CatalogLayerViewGenerated from './catalogLayerView.gb';

export async function buildJsCatalogLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogLayerViewGenerated } = await import('./catalogLayerView.gb');
    return await buildJsCatalogLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogLayerViewGenerated } = await import('./catalogLayerView.gb');
    return await buildDotNetCatalogLayerViewGenerated(jsObject, layerId, viewId);
}


export default class CatalogLayerViewWrapper extends CatalogLayerViewGenerated {

    constructor(component: CatalogLayerView) {
        super(component);
    }
    
}

