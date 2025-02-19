// override generated code in this file
import IOpenStreetMapLayerGenerated from './iOpenStreetMapLayer.gb';
import OpenStreetMapLayer from '@arcgis/core/layers/OpenStreetMapLayer';

export default class IOpenStreetMapLayerWrapper extends IOpenStreetMapLayerGenerated {

    constructor(layer: OpenStreetMapLayer) {
        super(layer);
    }
    
}

export async function buildJsIOpenStreetMapLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIOpenStreetMapLayerGenerated } = await import('./iOpenStreetMapLayer.gb');
    return await buildJsIOpenStreetMapLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIOpenStreetMapLayer(jsObject: any): Promise<any> {
    let { buildDotNetIOpenStreetMapLayerGenerated } = await import('./iOpenStreetMapLayer.gb');
    return await buildDotNetIOpenStreetMapLayerGenerated(jsObject);
}
