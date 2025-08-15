import {arcGisObjectRefs, dotNetRefs, hasValue, lookupGeoBlazorId, sanitize} from "./arcGisJsInterop";

export async function buildJsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject?.layer)) {
        return null;
    }

    switch (dotNetObject.layer.type) {
        case 'csv':
            let {buildJsCSVLayerView} = await import('./cSVLayerView');
            return await buildJsCSVLayerView(dotNetObject, layerId, viewId);
        case 'feature':
            let {buildJsFeatureLayerView} = await import('./featureLayerView');
            return await buildJsFeatureLayerView(dotNetObject, layerId, viewId);
        case 'geojson':
            let {buildJsGeoJSONLayerView} = await import('./geoJSONLayerView');
            return await buildJsGeoJSONLayerView(dotNetObject, layerId, viewId);
        case 'geo-rss':
            let {buildJsGeoRSSLayerView} = await import('./geoRSSLayerView');
            return await buildJsGeoRSSLayerView(dotNetObject, layerId, viewId);
        case 'graphics':
            let {buildJsGraphicsLayerView} = await import('./graphicsLayerView');
            return await buildJsGraphicsLayerView(dotNetObject, layerId, viewId);
        case 'imagery':
            let {buildJsImageryLayerView} = await import('./imageryLayerView');
            return await buildJsImageryLayerView(dotNetObject, layerId, viewId);
        case 'kml':
            let {buildJsKMLLayerView} = await import('./kMLLayerView');
            return await buildJsKMLLayerView(dotNetObject, layerId, viewId);
        case 'wfs':
            let {buildJsWFSLayerView} = await import('./wFSLayerView');
            return await buildJsWFSLayerView(dotNetObject, layerId, viewId);
        // case 'building-scene':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsBuildingSceneLayerView} = await import('./buildingSceneLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsBuildingSceneLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'catalog':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsCatalogLayerView} = await import('./catalogLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsCatalogLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'catalog-dynamic-group':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsCatalogDynamicGroupLayerView} = await import('./catalogDynamicGroupLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsCatalogDynamicGroupLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'catalog-footprint':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsCatalogFootprintLayerView} = await import('./catalogFootprintLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsCatalogFootprintLayerView(dotNetObject);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'dimension':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsDimensionLayerView} = await import('./dimensionLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsDimensionLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'media':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsMediaLayerView} = await import('./mediaLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsMediaLayerView(dotNetObject);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'ogc-feature':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsOGCFeatureLayerView} = await import('./oGCFeatureLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsOGCFeatureLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'point-cloud':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsPointCloudLayerView} = await import('./pointCloudLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsPointCloudLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'scene':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsSceneLayerView} = await import('./sceneLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsSceneLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        // case 'stream':
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {buildJsStreamLayerView} = await import('./streamLayerView');
        //         // @ts-ignore GeoBlazor Pro Only
        //         return await buildJsStreamLayerView(dotNetObject, layerId, viewId);
        //     } catch (e) {
        //         throw e;
        //     }
        default:
            return sanitize(dotNetObject);
    }
}

export async function buildDotNetLayerView(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject?.layer)) {
        return null;
    }

    let dnLayerView: any;

    switch (jsObject?.layer?.type) {
        case 'csv':
            let {buildDotNetCSVLayerView} = await import('./cSVLayerView');
            dnLayerView = await buildDotNetCSVLayerView(jsObject, viewId);
            break;
        case 'feature':
            let {buildDotNetFeatureLayerView} = await import('./featureLayerView');
            dnLayerView = await buildDotNetFeatureLayerView(jsObject, viewId);
            break;
        case 'geojson':
            let {buildDotNetGeoJSONLayerView} = await import('./geoJSONLayerView');
            dnLayerView = await buildDotNetGeoJSONLayerView(jsObject, viewId);
            break;
        case 'geo-rss':
            let {buildDotNetGeoRSSLayerView} = await import('./geoRSSLayerView');
            dnLayerView = await buildDotNetGeoRSSLayerView(jsObject, viewId);
            break;
        case 'graphics':
            let {buildDotNetGraphicsLayerView} = await import('./graphicsLayerView');
            dnLayerView = await buildDotNetGraphicsLayerView(jsObject, viewId);
            break;
        case 'imagery':
            let {buildDotNetImageryLayerView} = await import('./imageryLayerView');
            dnLayerView = await buildDotNetImageryLayerView(jsObject, viewId);
            break;
        case 'kml':
            let {buildDotNetKMLLayerView} = await import('./kMLLayerView');
            dnLayerView = await buildDotNetKMLLayerView(jsObject, viewId);
            break;
        case 'wfs':
            let {buildDotNetWFSLayerView} = await import('./wFSLayerView');
            dnLayerView = await buildDotNetWFSLayerView(jsObject, viewId);
            break;
        // case 'building-scene':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetBuildingSceneLayerView} = await import('./buildingSceneLayerView');
        //         dnLayerView = await buildDotNetBuildingSceneLayerView(jsObject);
        //     } catch (e) {
        //         throw new Error('Feature only available in GeoBlazor Pro');
        //     }
        //     break;
        // case 'catalog':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetCatalogLayerView} = await import('./catalogLayerView');
        //         dnLayerView = await buildDotNetCatalogLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'catalog-dynamic-group':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetCatalogDynamicGroupLayerView} = await import('./catalogDynamicGroupLayerView');
        //         dnLayerView = await buildDotNetCatalogDynamicGroupLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'catalog-footprint':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetCatalogFootprintLayerView} = await import('./catalogFootprintLayerView');
        //         dnLayerView = await buildDotNetCatalogFootprintLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'dimension':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetDimensionLayerView} = await import('./dimensionLayerView');
        //         dnLayerView = await buildDotNetDimensionLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'media':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetMediaLayerView} = await import('./mediaLayerView');
        //         dnLayerView = await buildDotNetMediaLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'ogc-feature':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetOGCFeatureLayerView} = await import('./oGCFeatureLayerView');
        //         dnLayerView = await buildDotNetOGCFeatureLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'point-cloud':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetPointCloudLayerView} = await import('./pointCloudLayerView');
        //         dnLayerView = await buildDotNetPointCloudLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'scene':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetSceneLayerView} = await import('./sceneLayerView');
        //         dnLayerView = await buildDotNetSceneLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        // case 'stream':
        //     try {
        //         // @ts-ignore GeoBlazor Pro only
        //         let {buildDotNetStreamLayerView} = await import('./streamLayerView');
        //         dnLayerView = await buildDotNetStreamLayerView(jsObject);
        //     } catch (e) {
        //         throw e;
        //     }
        //     break;
        default:
            dnLayerView = {};
            if (hasValue(jsObject.spatialReferenceSupported)) {
                dnLayerView.spatialReferenceSupported = jsObject.spatialReferenceSupported;
            }
            if (hasValue(jsObject.suspended)) {
                dnLayerView.suspended = jsObject.suspended;
            }
            if (hasValue(jsObject.updating)) {
                dnLayerView.updating = jsObject.updating;
            }
            if (hasValue(jsObject.visibleAtCurrentScale)) {
                dnLayerView.visibleAtCurrentScale = jsObject.visibleAtCurrentScale;
            }
            if (hasValue(jsObject.visibleAtCurrentTimeExtent)) {
                dnLayerView.visibleAtCurrentTimeExtent = jsObject.visibleAtCurrentTimeExtent;
            }

            let layerId = lookupGeoBlazorId(jsObject.layer);
            if (!hasValue(layerId) && hasValue(viewId)) {
                let dotNetRef = dotNetRefs[viewId!];
                layerId = await dotNetRef.invokeMethodAsync('GetId');
            }

            dnLayerView.layerId = layerId;
    }

    dnLayerView.type = jsObject.layer.type;

    return dnLayerView;
}

