// override generated code in this file
import {arcGisObjectRefs, hasValue} from './arcGisJsInterop';

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (hasValue(layerId) && arcGisObjectRefs.hasOwnProperty(layerId!)) {
        return arcGisObjectRefs[layerId!];
    }

    switch (dotNetObject.type) {
        case 'base-tile':
            let {buildJsBaseTileLayer} = await import('./baseTileLayer');
            return await buildJsBaseTileLayer(dotNetObject, layerId, viewId);
        case 'bing-maps':
            let {buildJsBingMapsLayer} = await import('./bingMapsLayer');
            return await buildJsBingMapsLayer(dotNetObject, layerId, viewId);
        case 'csv':
            let {buildJsCSVLayer} = await import('./cSVLayer');
            return await buildJsCSVLayer(dotNetObject, layerId, viewId);
        case 'feature':
            let {buildJsFeatureLayer} = await import('./featureLayer');
            return await buildJsFeatureLayer(dotNetObject, layerId, viewId);
        case 'geojson':
            let {buildJsGeoJSONLayer} = await import('./geoJSONLayer');
            return await buildJsGeoJSONLayer(dotNetObject, layerId, viewId);
        case 'geo-rss':
            let {buildJsGeoRSSLayer} = await import('./geoRSSLayer');
            return await buildJsGeoRSSLayer(dotNetObject, layerId, viewId);
        case 'graphics':
            let {buildJsGraphicsLayer} = await import('./graphicsLayer');
            return await buildJsGraphicsLayer(dotNetObject, layerId, viewId);
        case 'imagery':
            let {buildJsImageryLayer} = await import('./imageryLayer');
            return await buildJsImageryLayer(dotNetObject, layerId, viewId);
        case 'imagery-tile':
            let {buildJsImageryTileLayer} = await import('./imageryTileLayer');
            return await buildJsImageryTileLayer(dotNetObject, layerId, viewId);
        case 'kml':
            let {buildJsKMLLayer} = await import('./kMLLayer');
            return await buildJsKMLLayer(dotNetObject, layerId, viewId);
        case 'map-image':
            let {buildJsMapImageLayer} = await import('./mapImageLayer');
            return await buildJsMapImageLayer(dotNetObject, layerId, viewId);
        case 'open-street-map':
            let { buildJsOpenStreetMapLayer } = await import('./openStreetMapLayer');
            return await buildJsOpenStreetMapLayer(dotNetObject, layerId, viewId);
        case 'tile':
            let {buildJsTileLayer} = await import('./tileLayer');
            return await buildJsTileLayer(dotNetObject, layerId, viewId);
        case 'unknown':
            let {buildJsUnknownLayer} = await import('./unknownLayer');
            return await buildJsUnknownLayer(dotNetObject, layerId, viewId);
        case 'unsupported':
            let {buildJsUnsupportedLayer} = await import('./unsupportedLayer');
            return await buildJsUnsupportedLayer(dotNetObject, layerId, viewId);
        case 'vector-tile':
            let {buildJsVectorTileLayer} = await import('./vectorTileLayer');
            return await buildJsVectorTileLayer(dotNetObject, layerId, viewId);
        case 'wcs':
            let { buildJsWCSLayer } = await import('./wCSLayer');
           return await buildJsWCSLayer(dotNetObject, layerId, viewId);
        case 'web-tile':
            let {buildJsWebTileLayer} = await import('./webTileLayer');
            return await buildJsWebTileLayer(dotNetObject, layerId, viewId);
       case 'wfs':
            let {buildJsWFSLayer} = await import('./wFSLayer');
            return await buildJsWFSLayer(dotNetObject, layerId, viewId);
        case 'wms':
            let {buildJsWMSLayer} = await import('./wMSLayer');
            return await buildJsWMSLayer(dotNetObject, layerId, viewId);
        case 'wmts':
            let {buildJsWMTSLayer} = await import('./wMTSLayer');
            return await buildJsWMTSLayer(dotNetObject, layerId, viewId);
        case 'base-dynamic':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsBaseDynamicLayer} = await import('./baseDynamicLayer');
            return await buildJsBaseDynamicLayer(dotNetObject, layerId, viewId);
        case 'base-elevation':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsBaseElevationLayer} = await import('./baseElevationLayer');
            return await buildJsBaseElevationLayer(dotNetObject, layerId, viewId);
        case 'building-scene':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsBuildingSceneLayer} = await import('./buildingSceneLayer');
            return await buildJsBuildingSceneLayer(dotNetObject, layerId, viewId);
        case 'catalog-dynamic-group':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsCatalogDynamicGroupLayer} = await import('./catalogDynamicGroupLayer');
            return await buildJsCatalogDynamicGroupLayer(dotNetObject, layerId, viewId);
        case 'catalog-footprint':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsCatalogFootprintLayer} = await import('./catalogFootprintLayer');
            return await buildJsCatalogFootprintLayer(dotNetObject, layerId, viewId);
        case 'catalog':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsCatalogLayer} = await import('./catalogLayer');
            return await buildJsCatalogLayer(dotNetObject, layerId, viewId);
        case 'dimension':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsDimensionLayer} = await import('./dimensionLayer');
            return await buildJsDimensionLayer(dotNetObject, layerId, viewId);
        case 'elevation':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsElevationLayer} = await import('./elevationLayer');
            return await buildJsElevationLayer(dotNetObject, layerId, viewId);
        case 'group':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsGroupLayer} = await import('./groupLayer');
            return await buildJsGroupLayer(dotNetObject, layerId, viewId);
        case 'integrated-mesh':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsIntegratedMeshLayer} = await import('./integratedMeshLayer');
            return await buildJsIntegratedMeshLayer(dotNetObject, layerId, viewId);
        case 'integrated-mesh-3dtiles':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsIntegratedMesh3DTilesLayer} = await import('./integratedMesh3DTilesLayer');
            return await buildJsIntegratedMesh3DTilesLayer(dotNetObject, layerId, viewId);
        case 'knowledge-graph-sublayer':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsKnowledgeGraphSublayer} = await import('./knowledgeGraphSublayer');
            return await buildJsKnowledgeGraphSublayer(dotNetObject, layerId, viewId);
        case 'knowledge-graph':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsKnowledgeGraphLayer} = await import('./knowledgeGraphLayer');
            return await buildJsKnowledgeGraphLayer(dotNetObject, layerId, viewId);
        case 'line-of-sight':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsLineOfSightLayer} = await import('./lineOfSightLayer');
            return await buildJsLineOfSightLayer(dotNetObject, layerId, viewId);
        case 'map-notes':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsMapNotesLayer} = await import('./mapNotesLayer');
            return await buildJsMapNotesLayer(dotNetObject, layerId, viewId);
        case 'media':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsMediaLayer} = await import('./mediaLayer');
            return await buildJsMediaLayer(dotNetObject, layerId, viewId);
        case 'ogc-feature':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsOGCFeatureLayer} = await import('./oGCFeatureLayer');
            return await buildJsOGCFeatureLayer(dotNetObject, layerId, viewId);
        case 'oriented-imagery':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsOrientedImageryLayer} = await import('./orientedImageryLayer');
            return await buildJsOrientedImageryLayer(dotNetObject, layerId, viewId);
        case 'point-cloud':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsPointCloudLayer} = await import('./pointCloudLayer');
            return await buildJsPointCloudLayer(dotNetObject, layerId, viewId);
        case 'route':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsRouteLayer} = await import('./routeLayer');
            return await buildJsRouteLayer(dotNetObject, layerId, viewId);
        case 'scene':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsSceneLayer} = await import('./sceneLayer');
            return await buildJsSceneLayer(dotNetObject, layerId, viewId);
        case 'stream':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsStreamLayer} = await import('./streamLayer');
            return await buildJsStreamLayer(dotNetObject, layerId, viewId);
        case 'subtype-group':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsSubtypeGroupLayer} = await import('./subtypeGroupLayer');
            return await buildJsSubtypeGroupLayer(dotNetObject, layerId, viewId);
        case 'video':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsVideoLayer} = await import('./videoLayer');
            return await buildJsVideoLayer(dotNetObject, layerId, viewId);
        case 'voxel':
            // @ts-ignore GeoBlazor Pro only
            let {buildJsVoxelLayer} = await import('./voxelLayer');
            return await buildJsVoxelLayer(dotNetObject, layerId, viewId);
        default:
            let { id, dotNetComponentReference, ...sanitizedLayer } = dotNetObject;
            return sanitizedLayer;
    }
}

export async function buildDotNetLayer(jsObject: any): Promise<any> {
    switch (jsObject.type) {
        case 'base-tile':
            let {buildDotNetBaseTileLayer} = await import('./baseTileLayer');
            return await buildDotNetBaseTileLayer(jsObject);
        case 'bing-maps':
            let {buildDotNetBingMapsLayer} = await import('./bingMapsLayer');
            return await buildDotNetBingMapsLayer(jsObject);
        case 'csv':
            let {buildDotNetCSVLayer} = await import('./cSVLayer');
            return await buildDotNetCSVLayer(jsObject);
        case 'feature':
            let {buildDotNetFeatureLayer} = await import('./featureLayer');
            return await buildDotNetFeatureLayer(jsObject);
        case 'geojson':
            let {buildDotNetGeoJSONLayer} = await import('./geoJSONLayer');
            return await buildDotNetGeoJSONLayer(jsObject);
        case 'geo-rss':
            let {buildDotNetGeoRSSLayer} = await import('./geoRSSLayer');
            return await buildDotNetGeoRSSLayer(jsObject);
        case 'graphics':
            let {buildDotNetGraphicsLayer} = await import('./graphicsLayer');
            return await buildDotNetGraphicsLayer(jsObject);
        case 'imagery':
            let {buildDotNetImageryLayer} = await import('./imageryLayer');
            return await buildDotNetImageryLayer(jsObject);
        case 'imagery-tile':
            let {buildDotNetImageryTileLayer} = await import('./imageryTileLayer');
            return await buildDotNetImageryTileLayer(jsObject);
        case 'kml':
            let {buildDotNetKMLLayer} = await import('./kMLLayer');
            return await buildDotNetKMLLayer(jsObject);
        case 'map-image':
            let {buildDotNetMapImageLayer} = await import('./mapImageLayer');
            return await buildDotNetMapImageLayer(jsObject);
        case 'open-street-map':
            let { buildDotNetOpenStreetMapLayer } = await import('./openStreetMapLayer');
            return await buildDotNetOpenStreetMapLayer(jsObject);
        case 'tile':
            let {buildDotNetTileLayer} = await import('./tileLayer');
            return await buildDotNetTileLayer(jsObject);
        case 'vector-tile':
            let {buildDotNetVectorTileLayer} = await import('./vectorTileLayer');
            return await buildDotNetVectorTileLayer(jsObject);
        case 'wcs':
            let { buildDotNetWCSLayer } = await import('./wCSLayer');
            return await buildDotNetWCSLayer(jsObject);
        case 'web-tile':
            let {buildDotNetWebTileLayer} = await import('./webTileLayer');
            return await buildDotNetWebTileLayer(jsObject);
        case 'wfs':
            let {buildDotNetWFSLayer} = await import('./wFSLayer');
            return await buildDotNetWFSLayer(jsObject);
        case 'wms':
            let {buildDotNetWMSLayer} = await import('./wMSLayer');
            return await buildDotNetWMSLayer(jsObject);
        case 'wmts':
            let {buildDotNetWMTSLayer} = await import('./wMTSLayer');
            return await buildDotNetWMTSLayer(jsObject);
        case 'base-dynamic':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetBaseDynamicLayer} = await import('./baseDynamicLayer');
            return await buildDotNetBaseDynamicLayer(jsObject);
        case 'base-elevation':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetBaseElevationLayer} = await import('./baseElevationLayer');
            return await buildDotNetBaseElevationLayer(jsObject);
        case 'building-scene':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetBuildingSceneLayer} = await import('./buildingSceneLayer');
            return await buildDotNetBuildingSceneLayer(jsObject);
        case 'catalog-dynamic-group':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetCatalogDynamicGroupLayer} = await import('./catalogDynamicGroupLayer');
            return await buildDotNetCatalogDynamicGroupLayer(jsObject);
        case 'catalog-footprint':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetCatalogFootprintLayer} = await import('./catalogFootprintLayer');
            return await buildDotNetCatalogFootprintLayer(jsObject);
        case 'catalog':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetCatalogLayer} = await import('./catalogLayer');
            return await buildDotNetCatalogLayer(jsObject);
        case 'dimension':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetDimensionLayer} = await import('./dimensionLayer');
            return await buildDotNetDimensionLayer(jsObject);
        case 'elevation':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetElevationLayer} = await import('./elevationLayer');
            return await buildDotNetElevationLayer(jsObject);
        case 'group':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetGroupLayer} = await import('./groupLayer');
            return await buildDotNetGroupLayer(jsObject);
        case 'integrated-mesh':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetIntegratedMeshLayer} = await import('./integratedMeshLayer');
            return await buildDotNetIntegratedMeshLayer(jsObject);
        case 'integrated-mesh-3dtiles':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetIntegratedMesh3DTilesLayer} = await import('./integratedMesh3DTilesLayer');
            return await buildDotNetIntegratedMesh3DTilesLayer(jsObject);
        case 'knowledge-graph-sublayer':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetKnowledgeGraphSublayer} = await import('./knowledgeGraphSublayer');
            return await buildDotNetKnowledgeGraphSublayer(jsObject);
        case 'knowledge-graph':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetKnowledgeGraphLayer} = await import('./knowledgeGraphLayer');
            return await buildDotNetKnowledgeGraphLayer(jsObject);
        case 'line-of-sight':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetLineOfSightLayer} = await import('./lineOfSightLayer');
            return await buildDotNetLineOfSightLayer(jsObject);
        case 'map-notes':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetMapNotesLayer} = await import('./mapNotesLayer');
            return await buildDotNetMapNotesLayer(jsObject);
        case 'media':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetMediaLayer} = await import('./mediaLayer');
            return await buildDotNetMediaLayer(jsObject);
        case 'ogc-feature':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetOGCFeatureLayer} = await import('./oGCFeatureLayer');
            return await buildDotNetOGCFeatureLayer(jsObject);
        case 'oriented-imagery':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetOrientedImageryLayer} = await import('./orientedImageryLayer');
            return await buildDotNetOrientedImageryLayer(jsObject);
        case 'point-cloud':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetPointCloudLayer} = await import('./pointCloudLayer');
            return await buildDotNetPointCloudLayer(jsObject);
        case 'route':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetRouteLayer} = await import('./routeLayer');
            return await buildDotNetRouteLayer(jsObject);
        case 'scene':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetSceneLayer} = await import('./sceneLayer');
            return await buildDotNetSceneLayer(jsObject);
        case 'stream':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetStreamLayer} = await import('./streamLayer');
            return await buildDotNetStreamLayer(jsObject);
        case 'subtype-group':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetSubtypeGroupLayer} = await import('./subtypeGroupLayer');
            return await buildDotNetSubtypeGroupLayer(jsObject);
        case 'unknown':
            let {buildDotNetUnknownLayer} = await import('./unknownLayer');
            return await buildDotNetUnknownLayer(jsObject);
        case 'unsupported':
            let {buildDotNetUnsupportedLayer} = await import('./unsupportedLayer');
            return await buildDotNetUnsupportedLayer(jsObject);
        case 'video':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetVideoLayer} = await import('./videoLayer');
            return await buildDotNetVideoLayer(jsObject);
        case 'voxel':
            // @ts-ignore GeoBlazor Pro only
            let {buildDotNetVoxelLayer} = await import('./voxelLayer');
            return await buildDotNetVoxelLayer(jsObject);
        default:
            let seenObjects = new WeakMap();
            let jsonSanitizedObject = JSON.stringify(jsObject, function (key, value) {
                if (typeof value === 'object' && value !== null) {
                    if (seenObjects.has(value)) {
                        console.warn(`Circular reference in serializing layer type ${jsObject.type} detected at path: ${key}, value: ${value}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                if (key.startsWith('_')) {
                    return undefined;
                }
                return value;
            });
            return JSON.parse(jsonSanitizedObject);
    }
}
