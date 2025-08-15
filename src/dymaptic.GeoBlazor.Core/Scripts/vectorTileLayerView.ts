// override generated code in this file
import VectorTileLayerViewGenerated from './vectorTileLayerView.gb';
import VectorTileLayerView from '@arcgis/core/views/layers/VectorTileLayerView';

export default class VectorTileLayerViewWrapper extends VectorTileLayerViewGenerated {

    constructor(component: VectorTileLayerView) {
        super(component);
    }
    
}

export async function buildJsVectorTileLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerViewGenerated } = await import('./vectorTileLayerView.gb');
    return await buildJsVectorTileLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorTileLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileLayerViewGenerated } = await import('./vectorTileLayerView.gb');
    return await buildDotNetVectorTileLayerViewGenerated(jsObject, viewId);
}
