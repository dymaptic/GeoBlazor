// override generated code in this file
import ILayersMixinGenerated from './iLayersMixin.gb';
import LayersMixin = __esri.LayersMixin;

export default class ILayersMixinWrapper extends ILayersMixinGenerated {

    constructor(component: LayersMixin) {
        super(component);
    }
    
}

export async function buildJsILayersMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsILayersMixinGenerated } = await import('./iLayersMixin.gb');
    return await buildJsILayersMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetILayersMixin(jsObject: any): Promise<any> {
    let { buildDotNetILayersMixinGenerated } = await import('./iLayersMixin.gb');
    return await buildDotNetILayersMixinGenerated(jsObject);
}
