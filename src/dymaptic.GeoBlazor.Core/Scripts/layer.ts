// override generated code in this file
import { arcGisObjectRefs, hasValue } from './arcGisJsInterop';

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (hasValue(layerId) && arcGisObjectRefs.hasOwnProperty(layerId!)) {
        return arcGisObjectRefs[layerId!];
    }
    
    switch (dotNetObject.type) {
        case 'base-tile':
            let { buildJsBaseTileLayer } = await import('./baseTileLayer');
            return await buildJsBaseTileLayer(dotNetObject, layerId, viewId);
        case 'bing-maps':
            let { buildJsBingMapsLayer } = await import('./bingMapsLayer');
            return await buildJsBingMapsLayer(dotNetObject, layerId, viewId);
        case 'csv':
            let { buildJsCSVLayer } = await import('./cSVLayer');
            return await buildJsCSVLayer(dotNetObject, layerId, viewId);
        case 'feature':
            let { buildJsFeatureLayer } = await import('./featureLayer');
            return await buildJsFeatureLayer(dotNetObject, layerId, viewId);
        case 'geojson':
            let { buildJsGeoJSONLayer } = await import('./geoJSONLayer');
            return await buildJsGeoJSONLayer(dotNetObject, layerId, viewId);
        case 'geo-rss':
            let { buildJsGeoRSSLayer } = await import('./geoRSSLayer');
            return await buildJsGeoRSSLayer(dotNetObject, layerId, viewId);
        case 'graphics':
            let { buildJsGraphicsLayer } = await import('./graphicsLayer');
            return await buildJsGraphicsLayer(dotNetObject, layerId, viewId);
        case 'imagery':
            let { buildJsImageryLayer } = await import('./imageryLayer');
            return await buildJsImageryLayer(dotNetObject, layerId, viewId);
        case 'kml':
            let { buildJsKMLLayer } = await import('./kMLLayer');
            return await buildJsKMLLayer(dotNetObject, layerId, viewId);
        case 'map-image':
            let { buildJsMapImageLayer } = await import('./mapImageLayer');
            return await buildJsMapImageLayer(dotNetObject, layerId, viewId);
        // case 'open-street-map':
        //     let { buildJsOpenStreetMapsLayer } = await import('./openStreetMapLayer');
        //     return await buildJsOpenStreetMapsLayer(dotNetObject, layerId, viewId);
        case 'tile':
            let { buildJsTileLayer } = await import('./tileLayer');
            return await buildJsTileLayer(dotNetObject, layerId, viewId);
        case 'vector-tile':
            let { buildJsVectorTileLayer } = await import('./vectorTileLayer');
            return await buildJsVectorTileLayer(dotNetObject, layerId, viewId);
        // case 'wcs':
        //     let { buildJsWCSLayer } = await import('./wCSLayer');
        //    return await buildJsWCSLayer(dotNetObject, layerId, viewId);
        case 'web-tile':
            let { buildJsWebTileLayer } = await import('./webTileLayer');
            return await buildJsWebTileLayer(dotNetObject, layerId, viewId);
        default:
            throw new Error(`Unsupported layer type: ${dotNetObject.type}`);
    }
}     

export async function buildDotNetLayer(jsObject: any): Promise<any> {
    switch (jsObject.type) {
        case 'base-tile':
            let { buildDotNetBaseTileLayer } = await import('./baseTileLayer');
            return await buildDotNetBaseTileLayer(jsObject);
        case 'bing-maps':
            let { buildDotNetBingMapsLayer } = await import('./bingMapsLayer');
            return await buildDotNetBingMapsLayer(jsObject);
        case 'csv':
            let { buildDotNetCSVLayer } = await import('./cSVLayer');
            return await buildDotNetCSVLayer(jsObject);
        case 'feature':
            let { buildDotNetFeatureLayer } = await import('./featureLayer');
            return await buildDotNetFeatureLayer(jsObject);
        case 'geojson':
            let { buildDotNetGeoJSONLayer } = await import('./geoJSONLayer');
            return await buildDotNetGeoJSONLayer(jsObject);
        case 'geo-rss':
            let { buildDotNetGeoRSSLayer } = await import('./geoRSSLayer');
            return await buildDotNetGeoRSSLayer(jsObject);
        case 'graphics':
            let { buildDotNetGraphicsLayer } = await import('./graphicsLayer');
            return await buildDotNetGraphicsLayer(jsObject);
        case 'imagery':
            let { buildDotNetImageryLayer } = await import('./imageryLayer');
            return await buildDotNetImageryLayer(jsObject);
        case 'kml':
            let { buildDotNetKMLLayer } = await import('./kMLLayer');
            return await buildDotNetKMLLayer(jsObject);
        case 'map-image':
            let { buildDotNetMapImageLayer } = await import('./mapImageLayer');
            return await buildDotNetMapImageLayer(jsObject);
        // case 'open-street-map':
        //     let { buildDotNetOpenStreetMapsLayer } = await import('./openStreetMapLayer');
        //     return await buildDotNetOpenStreetMapLayer(jsObject);
        case 'tile':
            let { buildDotNetTileLayer } = await import('./tileLayer');
            return await buildDotNetTileLayer(jsObject);
        case 'vector-tile':
            let { buildDotNetVectorTileLayer } = await import('./vectorTileLayer');
            return await buildDotNetVectorTileLayer(jsObject);
        // case 'wcs':
        //     let { buildWCSLayer } = await import('./wCSLayer');
        //     return await buildWCSLayer(jsObject);
        case 'web-tile':
            let { buildDotNetWebTileLayer } = await import('./webTileLayer');
            return await buildDotNetWebTileLayer(jsObject);
        default:
            throw new Error(`Unsupported layer type: ${jsObject.type}`);
    }
}
