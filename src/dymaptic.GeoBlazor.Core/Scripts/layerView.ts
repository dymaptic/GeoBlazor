// override generated code in this file
import LayerViewGenerated from './layerView.gb';
import LayerView from '@arcgis/core/views/layers/LayerView';

export default class LayerViewWrapper extends LayerViewGenerated {

    constructor(component: LayerView) {
        super(component);
    }
    
}              
export async function buildJsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerViewGenerated } = await import('./layerView.gb');
    return await buildJsLayerViewGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLayerView(jsObject: any): Promise<any> {
    let { buildDotNetLayerViewGenerated } = await import('./layerView.gb');
    let result = await buildDotNetLayerViewGenerated(jsObject);
    result.type = jsObject.layer.type;
}
