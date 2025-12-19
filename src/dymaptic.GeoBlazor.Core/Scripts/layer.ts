// override generated code in this file
import {
    arcGisObjectRefs,
    hasValue,
    Pro,
    removeCircularReferences,
    esriConfig, jsObjectRefs, lookupGeoBlazorId
} from './geoBlazorCore';

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    if (hasValue(dotNetObject.id) && arcGisObjectRefs.hasOwnProperty(dotNetObject.id!)) {
        return arcGisObjectRefs[dotNetObject.id!];
    }

    if (hasValue(dotNetObject.excludeApiKey) && dotNetObject.excludeApiKey) {
        esriConfig.apiKey = null;
        // this will be re-added in GeoBlazor's `AuthenticationManager` on the next MapView.
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
        case 'pro-geojson':
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
            let {buildJsOpenStreetMapLayer} = await import('./openStreetMapLayer');
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
            let {buildJsWCSLayer} = await import('./wCSLayer');
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
        // case 'base-dynamic':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsBaseDynamicLayer} = await import('./baseDynamicLayer');
        //         return await buildJsBaseDynamicLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'base-elevation':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsBaseElevationLayer} = await import('./baseElevationLayer');
        //         return await buildJsBaseElevationLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'building-scene':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsBuildingSceneLayer} = await import('./buildingSceneLayer');
        //         return await buildJsBuildingSceneLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'catalog-dynamic-group':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsCatalogDynamicGroupLayer} = await import('./catalogDynamicGroupLayer');
                return await buildJsCatalogDynamicGroupLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'catalog-footprint':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsCatalogFootprintLayer} = await import('./catalogFootprintLayer');
                return await buildJsCatalogFootprintLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'catalog':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsCatalogLayer} = await import('./catalogLayer');
                return await buildJsCatalogLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        // case 'dimension':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsDimensionLayer} = await import('./dimensionLayer');
        //         return await buildJsDimensionLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'elevation':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsElevationLayer} = await import('./elevationLayer');
                return await buildJsElevationLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'group':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsGroupLayer} = await import('./groupLayer');
                return await buildJsGroupLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        // case 'integrated-mesh':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsIntegratedMeshLayer} = await import('./integratedMeshLayer');
        //         return await buildJsIntegratedMeshLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'integrated-mesh-3dtiles':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsIntegratedMesh3DTilesLayer} = await import('./integratedMesh3DTilesLayer');
        //         return await buildJsIntegratedMesh3DTilesLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph-sublayer':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsKnowledgeGraphSublayer} = await import('./knowledgeGraphSublayer');
        //         return await buildJsKnowledgeGraphSublayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsKnowledgeGraphLayer} = await import('./knowledgeGraphLayer');
        //         return await buildJsKnowledgeGraphLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'line-of-sight':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsLineOfSightLayer} = await import('./lineOfSightLayer');
        //         return await buildJsLineOfSightLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'map-notes':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsMapNotesLayer} = await import('./mapNotesLayer');
        //         return await buildJsMapNotesLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'media':
        //     if (!Pro) {
        //         let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //         return sanitizedLayer;
        //     }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsMediaLayer} = await import('./mediaLayer');
        //         return await buildJsMediaLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'ogc-feature':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsOGCFeatureLayer} = await import('./oGCFeatureLayer');
                return await buildJsOGCFeatureLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        // case 'oriented-imagery':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsOrientedImageryLayer} = await import('./orientedImageryLayer');
        //         return await buildJsOrientedImageryLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'point-cloud':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsPointCloudLayer} = await import('./pointCloudLayer');
        //         return await buildJsPointCloudLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'route':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsRouteLayer} = await import('./routeLayer');
        //         return await buildJsRouteLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'scene':
            if (!Pro) {
                let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
                return sanitizedLayer;
            }
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsSceneLayer} = await import('./sceneLayer');
                return await buildJsSceneLayer(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        // case 'stream':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsStreamLayer} = await import('./streamLayer');
        //         return await buildJsStreamLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'subtype-group':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsSubtypeGroupLayer} = await import('./subtypeGroupLayer');
        //         return await buildJsSubtypeGroupLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'video':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsVideoLayer} = await import('./videoLayer');
        //         return await buildJsVideoLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'voxel':
        //     if (!Pro) {
        //                 let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
        //                 return sanitizedLayer;
        //             }
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildJsVoxelLayer} = await import('./voxelLayer');
        //         return await buildJsVoxelLayer(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        default:
            let {id, dotNetComponentReference, ...sanitizedLayer} = dotNetObject;
            return sanitizedLayer;
    }
}

export async function buildDotNetLayer(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    switch (jsObject.type) {
        case 'base-tile':
            let {buildDotNetBaseTileLayer} = await import('./baseTileLayer');
            return await buildDotNetBaseTileLayer(jsObject, viewId);
        case 'bing-maps':
            let {buildDotNetBingMapsLayer} = await import('./bingMapsLayer');
            return await buildDotNetBingMapsLayer(jsObject, viewId);
        case 'csv':
            let {buildDotNetCSVLayer} = await import('./cSVLayer');
            return await buildDotNetCSVLayer(jsObject, viewId);
        case 'feature':
            let {buildDotNetFeatureLayer} = await import('./featureLayer');
            return await buildDotNetFeatureLayer(jsObject, viewId);
        case 'geojson':
            let {buildDotNetGeoJSONLayer} = await import('./geoJSONLayer');
            return await buildDotNetGeoJSONLayer(jsObject, viewId);
        case 'geo-rss':
            let {buildDotNetGeoRSSLayer} = await import('./geoRSSLayer');
            return await buildDotNetGeoRSSLayer(jsObject, viewId);
        case 'graphics':
            let {buildDotNetGraphicsLayer} = await import('./graphicsLayer');
            return await buildDotNetGraphicsLayer(jsObject, viewId);
        case 'imagery':
            let {buildDotNetImageryLayer} = await import('./imageryLayer');
            return await buildDotNetImageryLayer(jsObject, viewId);
        case 'imagery-tile':
            let {buildDotNetImageryTileLayer} = await import('./imageryTileLayer');
            return await buildDotNetImageryTileLayer(jsObject, viewId);
        case 'kml':
            let {buildDotNetKMLLayer} = await import('./kMLLayer');
            return await buildDotNetKMLLayer(jsObject, viewId);
        case 'map-image':
            let {buildDotNetMapImageLayer} = await import('./mapImageLayer');
            return await buildDotNetMapImageLayer(jsObject, viewId);
        case 'open-street-map':
            let {buildDotNetOpenStreetMapLayer} = await import('./openStreetMapLayer');
            return await buildDotNetOpenStreetMapLayer(jsObject, viewId);
        case 'tile':
            let {buildDotNetTileLayer} = await import('./tileLayer');
            return await buildDotNetTileLayer(jsObject, viewId);
        case 'vector-tile':
            let {buildDotNetVectorTileLayer} = await import('./vectorTileLayer');
            return await buildDotNetVectorTileLayer(jsObject, viewId);
        case 'wcs':
            let {buildDotNetWCSLayer} = await import('./wCSLayer');
            return await buildDotNetWCSLayer(jsObject, viewId);
        case 'web-tile':
            let {buildDotNetWebTileLayer} = await import('./webTileLayer');
            return await buildDotNetWebTileLayer(jsObject, viewId);
        case 'wfs':
            let {buildDotNetWFSLayer} = await import('./wFSLayer');
            return await buildDotNetWFSLayer(jsObject, viewId);
        case 'wms':
            let {buildDotNetWMSLayer} = await import('./wMSLayer');
            return await buildDotNetWMSLayer(jsObject, viewId);
        case 'wmts':
            let {buildDotNetWMTSLayer} = await import('./wMTSLayer');
            return await buildDotNetWMTSLayer(jsObject, viewId);
        case 'unknown':
            let {buildDotNetUnknownLayer} = await import('./unknownLayer');
            return await buildDotNetUnknownLayer(jsObject, viewId);
        case 'unsupported':
            let {buildDotNetUnsupportedLayer} = await import('./unsupportedLayer');
            return await buildDotNetUnsupportedLayer(jsObject, viewId);
        // case 'base-dynamic':
        //    if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetBaseDynamicLayer} = await import('./baseDynamicLayer');
        //         return await buildDotNetBaseDynamicLayer(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'base-elevation':
        //    if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetBaseElevationLayer} = await import('./baseElevationLayer');
        //         return await buildDotNetBaseElevationLayer(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'building-scene':
        //    if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetBuildingSceneLayer} = await import('./buildingSceneLayer');
        //         return await buildDotNetBuildingSceneLayer(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'catalog-dynamic-group':
           if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogDynamicGroupLayer} = await import('./catalogDynamicGroupLayer');
                return await buildDotNetCatalogDynamicGroupLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        case 'catalog-footprint':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogFootprintLayer} = await import('./catalogFootprintLayer');
                return await buildDotNetCatalogFootprintLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        case 'catalog':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogLayer} = await import('./catalogLayer');
                return await buildDotNetCatalogLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        // case 'dimension':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetDimensionLayer} = await import('./dimensionLayer');
        //         return await buildDotNetDimensionLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'elevation':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetElevationLayer} = await import('./elevationLayer');
                return await buildDotNetElevationLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        case 'group':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetGroupLayer} = await import('./groupLayer');
                return await buildDotNetGroupLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        // case 'integrated-mesh':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetIntegratedMeshLayer} = await import('./integratedMeshLayer');
        //         return await buildDotNetIntegratedMeshLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'integrated-mesh-3dtiles':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetIntegratedMesh3DTilesLayer} = await import('./integratedMesh3DTilesLayer');
        //         return await buildDotNetIntegratedMesh3DTilesLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph-sublayer':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetKnowledgeGraphSublayer} = await import('./knowledgeGraphSublayer');
        //         return await buildDotNetKnowledgeGraphSublayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetKnowledgeGraphLayer} = await import('./knowledgeGraphLayer');
        //         return await buildDotNetKnowledgeGraphLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'line-of-sight':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetLineOfSightLayer} = await import('./lineOfSightLayer');
        //         return await buildDotNetLineOfSightLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'map-notes':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetMapNotesLayer} = await import('./mapNotesLayer');
        //         return await buildDotNetMapNotesLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'media':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetMediaLayer} = await import('./mediaLayer');
        //         return await buildDotNetMediaLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'ogc-feature':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetOGCFeatureLayer} = await import('./oGCFeatureLayer');
                return await buildDotNetOGCFeatureLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        // case 'oriented-imagery':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetOrientedImageryLayer} = await import('./orientedImageryLayer');
        //         return await buildDotNetOrientedImageryLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'point-cloud':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetPointCloudLayer} = await import('./pointCloudLayer');
        //         return await buildDotNetPointCloudLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'route':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetRouteLayer} = await import('./routeLayer');
        //         return await buildDotNetRouteLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'scene':
            if (!Pro) return removeCircularReferences(jsObject);
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetSceneLayer} = await import('./sceneLayer');
                return await buildDotNetSceneLayer(jsObject, viewId);
            } catch (e) {
                throw e;
            }
        // case 'stream':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetStreamLayer} = await import('./streamLayer');
        //         return await buildDotNetStreamLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'subtype-group':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetSubtypeGroupLayer} = await import('./subtypeGroupLayer');
        //         return await buildDotNetSubtypeGroupLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'video':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetVideoLayer} = await import('./videoLayer');
        //         return await buildDotNetVideoLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'voxel':
        //  if (!Pro) return removeCircularReferences(jsObject);
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetVoxelLayer} = await import('./voxelLayer');
        //         return await buildDotNetVoxelLayer(jsObject, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        default:
            return removeCircularReferences(jsObject);
    }
}

export async function buildJsLayerWrapper(jsLayer: any): Promise<any> {
    if (!hasValue(jsLayer)) {
        return null;
    }

    let geoBlazorId = lookupGeoBlazorId(jsLayer);
    if (hasValue(geoBlazorId) && jsObjectRefs.hasOwnProperty(geoBlazorId!)) {
        return jsObjectRefs[geoBlazorId!];
    }

    switch (jsLayer.type) {
        case 'base-tile':
            let {default: BaseTileLayerWrapper} = await import('./baseTileLayer');
            return new BaseTileLayerWrapper(jsLayer);
        case 'bing-maps':
            let {default: BingMapsLayerWrapper} = await import('./bingMapsLayer');
            return new BingMapsLayerWrapper(jsLayer);
        case 'csv':
            let {default: CSVLayerWrapper} = await import('./cSVLayer');
            return new CSVLayerWrapper(jsLayer);
        case 'feature':
            let {default: FeatureLayerWrapper} = await import('./featureLayer');
            return new FeatureLayerWrapper(jsLayer);
        case 'geojson':
            let {default: GeoJSONLayerWrapper} = await import('./geoJSONLayer');
            return new GeoJSONLayerWrapper(jsLayer);
        case 'geo-rss':
            let {default: GeoRSSLayerWrapper} = await import('./geoRSSLayer');
            return new GeoRSSLayerWrapper(jsLayer);
        case 'graphics':
            let {default: GraphicsLayerWrapper} = await import('./graphicsLayer');
            return new GraphicsLayerWrapper(jsLayer);
        case 'imagery':
            let {default: ImageryLayerWrapper} = await import('./imageryLayer');
            return new ImageryLayerWrapper(jsLayer);
        case 'imagery-tile':
            let {default: ImageryTileLayerWrapper} = await import('./imageryTileLayer');
            return new ImageryTileLayerWrapper(jsLayer);
        case 'kml':
            let {default: KMLLayerWrapper} = await import('./kMLLayer');
            return new KMLLayerWrapper(jsLayer);
        case 'map-image':
            let {default: MapImageLayerWrapper} = await import('./mapImageLayer');
            return new MapImageLayerWrapper(jsLayer);
        case 'open-street-map':
            let {default: OpenStreetMapLayerWrapper} = await import('./openStreetMapLayer');
            return new OpenStreetMapLayerWrapper(jsLayer);
        case 'tile':
            let {default: TileLayerWrapper} = await import('./tileLayer');
            return new TileLayerWrapper(jsLayer);
        case 'vector-tile':
            let {default: VectorTileLayerWrapper} = await import('./vectorTileLayer');
            return new VectorTileLayerWrapper(jsLayer);
        case 'wcs':
            let {default: WCSLayerWrapper} = await import('./wCSLayer');
            return new WCSLayerWrapper(jsLayer);
        case 'web-tile':
            let {default: WebTileLayerWrapper} = await import('./webTileLayer');
            return new WebTileLayerWrapper(jsLayer);
        case 'wfs':
            let {default: WFSLayerWrapper} = await import('./wFSLayer');
            return new WFSLayerWrapper(jsLayer);
        case 'wms':
            let {default: WMSLayerWrapper} = await import('./wMSLayer');
            return new WMSLayerWrapper(jsLayer);
        case 'wmts':
            let {default: WMTSLayerWrapper} = await import('./wMTSLayer');
            return new WMTSLayerWrapper(jsLayer);
        case 'unknown':
            let {default: UnknownLayerWrapper} = await import('./unknownLayer');
            return new UnknownLayerWrapper(jsLayer);
        case 'unsupported':
            let {default: UnsupportedLayerWrapper} = await import('./unsupportedLayer');
            return new UnsupportedLayerWrapper(jsLayer);
        // case 'base-dynamic':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: BaseDynamicLayerWrapper } = await import('./baseDynamicLayer');
        //         return new BaseDynamicLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'base-elevation':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: BaseElevationLayerWrapper } = await import('./baseElevationLayer');
        //         return new BaseElevationLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'building-scene':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: BuildingSceneLayerWrapper } = await import('./buildingSceneLayer');
        //         return new BuildingSceneLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'catalog-dynamic-group':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: CatalogDynamicGroupLayerWrapper} = await import('./catalogDynamicGroupLayer');
                return new CatalogDynamicGroupLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        case 'catalog-footprint':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: CatalogFootprintLayerWrapper} = await import('./catalogFootprintLayer');
                return new CatalogFootprintLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        case 'catalog':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: CatalogLayerWrapper} = await import('./catalogLayer');
                return new CatalogLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        // case 'dimension':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: DimensionLayerWrapper } = await import('./dimensionLayer');
        //         return new DimensionLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'elevation':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: ElevationLayerWrapper} = await import('./elevationLayer');
                return new ElevationLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        case 'group':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: GroupLayerWrapper} = await import('./groupLayer');
                return new GroupLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        // case 'integrated-mesh':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: IntegratedMeshLayerWrapper } = await import('./integratedMeshLayer');
        //         return new IntegratedMeshLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'integrated-mesh-3dtiles':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: IntegratedMesh3DTilesLayerWrapper } = await import('./integratedMesh3DTilesLayer');
        //         return new IntegratedMesh3DTilesLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph-sublayer':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: KnowledgeGraphSublayerWrapper } = await import('./knowledgeGraphSublayer');
        //         return new KnowledgeGraphSublayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'knowledge-graph':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: KnowledgeGraphLayerWrapper } = await import('./knowledgeGraphLayer');
        //         return new KnowledgeGraphLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'line-of-sight':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: LineOfSightLayerWrapper } = await import('./lineOfSightLayer');
        //         return new LineOfSightLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'map-notes':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: MapNotesLayerWrapper } = await import('./mapNotesLayer');
        //         return new MapNotesLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'media':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: MediaLayerWrapper } = await import('./mediaLayer');
        //         return new MediaLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'ogc-feature':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: OGCFeatureLayerWrapper} = await import('./oGCFeatureLayer');
                return new OGCFeatureLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        // case 'oriented-imagery':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: OrientedImageryLayerWrapper } = await import('./orientedImageryLayer');
        //         return new OrientedImageryLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'point-cloud':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: PointCloudLayerWrapper } = await import('./pointCloudLayer');
        //         return new PointCloudLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'route':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: RouteLayerWrapper } = await import('./routeLayer');
        //         return new RouteLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        case 'scene':
            if (!Pro) return jsLayer;
            try {
                // @ts-ignore GeoBlazor Pro only
                let {default: SceneLayerWrapper} = await import('./sceneLayer');
                return new SceneLayerWrapper(jsLayer);
            } catch (e) {
                throw e;
            }
        // case 'stream':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: StreamLayerWrapper } = await import('./streamLayer');
        //         return new StreamLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'subtype-group':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: SubtypeGroupLayerWrapper } = await import('./subtypeGroupLayer');
        //         return new SubtypeGroupLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'video':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: VideoLayerWrapper } = await import('./videoLayer');
        //         return new VideoLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'voxel':
        //    if (!Pro) return jsLayer;
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {default: VoxelLayerWrapper } = await import('./voxelLayer');
        //         return new VoxelLayerWrapper(jsLayer);
        //     } catch (e) {
        //         throw e;
        //     }
        default:
            // return the layer itself
            return jsLayer;
    }
}
