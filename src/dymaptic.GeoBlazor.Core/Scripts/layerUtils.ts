// override generated code in this file
import LayerUtilsGenerated from './layerUtils.gb';
import layerUtils = __esri.layerUtils;

export default class LayerUtilsWrapper extends LayerUtilsGenerated {

    constructor(component: layerUtils) {
        super(component);
    }
    
}

export async function buildJsLayerUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerUtilsGenerated } = await import('./layerUtils.gb');
    return await buildJsLayerUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerUtils(jsObject: any): Promise<any> {
    let { buildDotNetLayerUtilsGenerated } = await import('./layerUtils.gb');
    return await buildDotNetLayerUtilsGenerated(jsObject);
}
