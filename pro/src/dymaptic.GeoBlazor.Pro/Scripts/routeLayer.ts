// override generated code in this file
import RouteLayerGenerated from './routeLayer.gb';
import RouteLayer from '@arcgis/core/layers/RouteLayer';

export default class RouteLayerWrapper extends RouteLayerGenerated {

    constructor(layer: RouteLayer) {
        super(layer);
    }
    
}

export async function buildJsRouteLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteLayerGenerated } = await import('./routeLayer.gb');
    return await buildJsRouteLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRouteLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRouteLayerGenerated } = await import('./routeLayer.gb');
    return await buildDotNetRouteLayerGenerated(jsObject, layerId, viewId);
}
