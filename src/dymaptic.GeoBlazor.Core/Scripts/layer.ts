// override generated code in this file
import LayerGenerated from './layer.gb';
import Layer from '@arcgis/core/layers/Layer';
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import MapImageLayer from "@arcgis/core/layers/MapImageLayer";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import TileLayer from "@arcgis/core/layers/TileLayer";

export default class LayerWrapper extends LayerGenerated {

    constructor(layer: Layer) {
        super(layer);
    }
    
}

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerGenerated } = await import('./layer.gb');
    return await buildJsLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (jsObject.type) {
        case 'feature':
            let { buildDotNetFeatureLayer } = await import('./featureLayer');
            return buildDotNetFeatureLayer(jsObject as FeatureLayer, layerId, viewId);
        case 'map-image':
            let { buildDotNetMapImageLayer } = await import('./mapImageLayer');
            return buildDotNetMapImageLayer(jsObject as MapImageLayer, layerId, viewId);
        case 'graphics':
            let { buildDotNetGraphicsLayer } = await import('./graphicsLayer');
            return buildDotNetGraphicsLayer(jsObject as GraphicsLayer);
        case 'tile':
            let { buildDotNetTileLayer } = await import('./tileLayer');
            return buildDotNetTileLayer(jsObject as TileLayer);
        default:

            let dotNetLayer: any = {
                title: jsObject.title,
                type: jsObject.type,
                listMode: jsObject.listMode,
                visible: jsObject.visible,
                opacity: jsObject.opacity
            }

            if (jsObject.fullExtent !== undefined && jsObject.fullExtent !== null) {
                dotNetLayer.fullExtent = buildDotNetExtent(layer.fullExtent) as DotNetExtent;
            }

            if (Object.values(arcGisObjectRefs).includes(layer)) {
                for (const k of Object.keys(arcGisObjectRefs)) {
                    if (arcGisObjectRefs[k] === layer) {
                        dotNetLayer.id = k;
                        break;
                    }
                }
            }
            return dotNetLayer;
    }
}
