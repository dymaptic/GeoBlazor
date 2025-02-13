// override generated code in this file
import LayerGenerated from './layer.gb';
import Layer from '@arcgis/core/layers/Layer';
import { arcGisObjectRefs } from './arcGisJsInterop';

export default class LayerWrapper extends LayerGenerated {

    constructor(layer: Layer) {
        super(layer);
    }
    
}

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject.type) {
        case 'base-tile':
            let { buildJsBaseTileLayer } = await import('./baseTileLayer');
            return buildJsBaseTileLayer(dotNetObject, layerId, viewId);
        case 'bing-maps':
            let { buildJsBingMapsLayer } = await import('./bingMapsLayer');
            return buildJsBingMapsLayer(dotNetObject, layerId, viewId);
        case 'csv':
            let { buildJsCSVLayer } = await import('./cSVLayer');
            return buildJsCSVLayer(dotNetObject, layerId, viewId);
        case 'feature':
            let { buildJsFeatureLayer } = await import('./featureLayer');
            return buildJsFeatureLayer(dotNetObject, layerId, viewId);
        case 'geojson':
            let { buildJsGeoJSONLayer } = await import('./geoJSONLayer');
            return buildJsGeoJSONLayer(dotNetObject, layerId, viewId);
        case 'geo-rss':
            let { buildJsGeoRSSLayer } = await import('./geoRSSLayer');
            return buildJsGeoRSSLayer(dotNetObject, layerId, viewId);
        case 'graphics':
            let { buildJsGraphicsLayer } = await import('./graphicsLayer');
            return buildJsGraphicsLayer(dotNetObject, layerId, viewId);
        case 'imagery':
            let { buildJsImageryLayer } = await import('./imageryLayer');
            return buildJsImageryLayer(dotNetObject, layerId, viewId);
        case 'kml':
            let { buildJsKMLLayer } = await import('./kMLLayer');
            return buildJsKMLLayer(dotNetObject, layerId, viewId);
        case 'map-image':
            let { buildJsMapImageLayer } = await import('./mapImageLayer');
            return buildJsMapImageLayer(dotNetObject, layerId, viewId);
        // case 'open-street-map':
        //     let { buildJsOpenStreetMapsLayer } = await import('./openStreetMapLayer');
        //     return buildJsOpenStreetMapsLayer(dotNetObject, layerId, viewId);
        case 'tile':
            let { buildJsTileLayer } = await import('./tileLayer');
            return buildJsTileLayer(dotNetObject, layerId, viewId);
        case 'vector-tile':
            let { buildJsVectorTileLayer } = await import('./vectorTileLayer');
            return buildJsVectorTileLayer(dotNetObject, layerId, viewId);
        // case 'wcs':
        //     let { buildJsWCSLayer } = await import('./wCSLayer');
        //    return buildJsWCSLayer(dotNetObject, layerId, viewId);
        case 'web-tile':
            let { buildJsWebTileLayer } = await import('./webTileLayer');
            return buildJsWebTileLayer(dotNetObject, layerId, viewId);
        default:
            throw new Error(`Unsupported layer type: ${dotNetObject.type}`);
    }
}     

export async function buildDotNetLayer(jsObject: any): Promise<any> {
    switch (jsObject.type) {
        case 'base-tile':
            let { buildDotNetBaseTileLayer } = await import('./baseTileLayer');
            return buildDotNetBaseTileLayer(jsObject);
        case 'bing-maps':
            let { buildDotNetBingMapsLayer } = await import('./bingMapsLayer');
            return buildDotNetBingMapsLayer(jsObject);
        case 'csv':
            let { buildDotNetCSVLayer } = await import('./cSVLayer');
            return buildDotNetCSVLayer(jsObject);
        case 'feature':
            let { buildDotNetFeatureLayer } = await import('./featureLayer');
            return buildDotNetFeatureLayer(jsObject);
        case 'geojson':
            let { buildDotNetGeoJSONLayer } = await import('./geoJSONLayer');
            return buildDotNetGeoJSONLayer(jsObject);
        case 'geo-rss':
            let { buildDotNetGeoRSSLayer } = await import('./geoRSSLayer');
            return buildDotNetGeoRSSLayer(jsObject);
        case 'graphics':
            let { buildDotNetGraphicsLayer } = await import('./graphicsLayer');
            return buildDotNetGraphicsLayer(jsObject);
        case 'imagery':
            let { buildDotNetImageryLayer } = await import('./imageryLayer');
            return buildDotNetImageryLayer(jsObject);
        case 'kml':
            let { buildDotNetKMLLayer } = await import('./kMLLayer');
            return buildDotNetKMLLayer(jsObject);
        case 'map-image':
            let { buildDotNetMapImageLayer } = await import('./mapImageLayer');
            return buildDotNetMapImageLayer(jsObject);
        // case 'open-street-map':
        //     let { buildDotNetOpenStreetMapsLayer } = await import('./openStreetMapLayer');
        //     return buildDotNetOpenStreetMapLayer(jsObject);
        case 'tile':
            let { buildDotNetTileLayer } = await import('./tileLayer');
            return buildDotNetTileLayer(jsObject);
        case 'vector-tile':
            let { buildDotNetVectorTileLayer } = await import('./vectorTileLayer');
            return buildDotNetVectorTileLayer(jsObject);
        // case 'wcs':
        //     let { buildWCSLayer } = await import('./wCSLayer');
        //     return buildWCSLayer(jsObject);
        case 'web-tile':
            let { buildDotNetWebTileLayer } = await import('./webTileLayer');
            return buildDotNetWebTileLayer(jsObject);
        default:
            throw new Error(`Unsupported layer type: ${jsObject.type}`);
    }
}
