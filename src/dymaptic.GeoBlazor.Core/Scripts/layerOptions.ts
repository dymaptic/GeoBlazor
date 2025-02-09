// override generated code in this file
import LayerOptionsGenerated from './layerOptions.gb';
import LayerOptions from '@arcgis/core/popup/LayerOptions';

export default class LayerOptionsWrapper extends LayerOptionsGenerated {

    constructor(component: LayerOptions) {
        super(component);
    }
    
}              
export async function buildJsLayerOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerOptionsGenerated } = await import('./layerOptions.gb');
    return await buildJsLayerOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLayerOptions(jsObject: any): Promise<any> {
    let { buildDotNetLayerOptionsGenerated } = await import('./layerOptions.gb');
    return await buildDotNetLayerOptionsGenerated(jsObject);
}
