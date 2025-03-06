// override generated code in this file
import GraphicsLayerGenerated from './graphicsLayer.gb';
import GraphicsLayer from '@arcgis/core/layers/GraphicsLayer';

export default class GraphicsLayerWrapper extends GraphicsLayerGenerated {

    constructor(layer: GraphicsLayer) {
        super(layer);
    }

}

export async function buildJsGraphicsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGraphicsLayerGenerated} = await import('./graphicsLayer.gb');
    return await buildJsGraphicsLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGraphicsLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetGraphicsLayerGenerated} = await import('./graphicsLayer.gb');
    return await buildDotNetGraphicsLayerGenerated(jsObject, layerId, viewId);
}
