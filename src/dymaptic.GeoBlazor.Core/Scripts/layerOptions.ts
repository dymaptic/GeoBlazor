// override generated code in this file
import LayerOptionsGenerated from './layerOptions.gb';
import LayerOptions from '@arcgis/core/popup/LayerOptions';

export default class LayerOptionsWrapper extends LayerOptionsGenerated {

    constructor(component: LayerOptions) {
        super(component);
    }
    
}              
export async function buildJsLayerOptions(dotNetObject: any): Promise<any> {
    let { buildJsLayerOptionsGenerated } = await import('./layerOptions.gb');
    return await buildJsLayerOptionsGenerated(dotNetObject);
}
export async function buildDotNetLayerOptions(jsObject: any): Promise<any> {
    let { buildDotNetLayerOptionsGenerated } = await import('./layerOptions.gb');
    return await buildDotNetLayerOptionsGenerated(jsObject);
}
