// override generated code in this file
import LayerFromPortalItemParamsGenerated from './layerFromPortalItemParams.gb';
import LayerFromPortalItemParams = __esri.LayerFromPortalItemParams;

export default class LayerFromPortalItemParamsWrapper extends LayerFromPortalItemParamsGenerated {

    constructor(component: LayerFromPortalItemParams) {
        super(component);
    }
    
}              
export async function buildJsLayerFromPortalItemParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerFromPortalItemParamsGenerated } = await import('./layerFromPortalItemParams.gb');
    return await buildJsLayerFromPortalItemParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLayerFromPortalItemParams(jsObject: any): Promise<any> {
    let { buildDotNetLayerFromPortalItemParamsGenerated } = await import('./layerFromPortalItemParams.gb');
    return await buildDotNetLayerFromPortalItemParamsGenerated(jsObject);
}
