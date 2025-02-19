// override generated code in this file
import IPortalLayerGenerated from './iPortalLayer.gb';
import PortalLayer = __esri.PortalLayer;

export default class IPortalLayerWrapper extends IPortalLayerGenerated {

    constructor(layer: PortalLayer) {
        super(layer);
    }
    
}

export async function buildJsIPortalLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildJsIPortalLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPortalLayer(jsObject: any): Promise<any> {
    let { buildDotNetIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildDotNetIPortalLayerGenerated(jsObject);
}
