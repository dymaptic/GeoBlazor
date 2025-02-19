// override generated code in this file
import LayerOriginUtilsGenerated from './layerOriginUtils.gb';
import layerOriginUtils = __esri.layerOriginUtils;

export default class LayerOriginUtilsWrapper extends LayerOriginUtilsGenerated {

    constructor(component: layerOriginUtils) {
        super(component);
    }
    
}

export async function buildJsLayerOriginUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerOriginUtilsGenerated } = await import('./layerOriginUtils.gb');
    return await buildJsLayerOriginUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerOriginUtils(jsObject: any): Promise<any> {
    let { buildDotNetLayerOriginUtilsGenerated } = await import('./layerOriginUtils.gb');
    return await buildDotNetLayerOriginUtilsGenerated(jsObject);
}
