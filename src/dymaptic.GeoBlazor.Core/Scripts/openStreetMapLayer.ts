// override generated code in this file
import OpenStreetMapLayerGenerated from './openStreetMapLayer.gb';
import OpenStreetMapLayer from '@arcgis/core/layers/OpenStreetMapLayer';

export default class OpenStreetMapLayerWrapper extends OpenStreetMapLayerGenerated {

    constructor(layer: OpenStreetMapLayer) {
        super(layer);
    }
    
}

export async function buildJsOpenStreetMapLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpenStreetMapLayerGenerated } = await import('./openStreetMapLayer.gb');
    return await buildJsOpenStreetMapLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpenStreetMapLayer(jsObject: any): Promise<any> {
    let { buildDotNetOpenStreetMapLayerGenerated } = await import('./openStreetMapLayer.gb');
    return await buildDotNetOpenStreetMapLayerGenerated(jsObject);
}
