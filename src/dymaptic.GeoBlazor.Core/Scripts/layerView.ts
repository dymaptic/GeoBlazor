import {arcGisObjectRefs, hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";

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
        case 'building-scene':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsBuildingSceneLayerView} = await import('./buildingSceneLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsBuildingSceneLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'catalog':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsCatalogLayerView} = await import('./catalogLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsCatalogLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'catalog-dynamic-group':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsCatalogDynamicGroupLayerView} = await import('./catalogDynamicGroupLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsCatalogDynamicGroupLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'catalog-footprint':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsCatalogFootprintLayerView} = await import('./catalogFootprintLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsCatalogFootprintLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'dimension':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsDimensionLayerView} = await import('./dimensionLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsDimensionLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'media':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsMediaLayerView} = await import('./mediaLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsMediaLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'ogc-feature':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsOGCFeatureLayerView} = await import('./oGCFeatureLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsOGCFeatureLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'point-cloud':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsPointCloudLayerView} = await import('./pointCloudLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsPointCloudLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'scene':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsSceneLayerView} = await import('./sceneLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsSceneLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        case 'stream':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsStreamLayerView} = await import('./streamLayerView');
                // @ts-ignore GeoBlazor Pro Only
                return await buildJsStreamLayerView(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
        default:
            let {id, dotNetComponentReference, ...sanitizedDotNetObject} = dotNetObject;
            return sanitizedDotNetObject;
    }
}

export async function buildDotNetLayerView(jsObject: any): Promise<any> {
    if (!hasValue(jsObject?.layer)) {
        return null;
    }

    let layerId = lookupGeoBlazorId(jsObject.layer);
    let dnLayerView: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };

    switch (jsObject?.layer?.type) {
        case 'csv':
            let {buildDotNetCSVLayerView} = await import('./cSVLayerView');
            dnLayerView = await buildDotNetCSVLayerView(jsObject);
            break;
        case 'feature':
            let {buildDotNetFeatureLayerView} = await import('./featureLayerView');
            dnLayerView = await buildDotNetFeatureLayerView(jsObject);
            break;
        case 'geojson':
            let {buildDotNetGeoJSONLayerView} = await import('./geoJSONLayerView');
            dnLayerView = await buildDotNetGeoJSONLayerView(jsObject);
            break;
        case 'geo-rss':
            let {buildDotNetGeoRSSLayerView} = await import('./geoRSSLayerView');
            dnLayerView = await buildDotNetGeoRSSLayerView(jsObject);
            break;
        case 'graphics':
            let {buildDotNetGraphicsLayerView} = await import('./graphicsLayerView');
            dnLayerView = await buildDotNetGraphicsLayerView(jsObject);
            break;
        case 'imagery':
            let {buildDotNetImageryLayerView} = await import('./imageryLayerView');
            dnLayerView = await buildDotNetImageryLayerView(jsObject);
            break;
        case 'kml':
            let {buildDotNetKMLLayerView} = await import('./kMLLayerView');
            dnLayerView = await buildDotNetKMLLayerView(jsObject);
            break;
        case 'wfs':
            let {buildDotNetWFSLayerView} = await import('./wFSLayerView');
            dnLayerView = await buildDotNetWFSLayerView(jsObject);
            break;
        case 'building-scene':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetBuildingSceneLayerView} = await import('./buildingSceneLayerView');
                dnLayerView = await buildDotNetBuildingSceneLayerView(jsObject);
            } catch {
                throw new Error('Feature only available in GeoBlazor Pro');
            }
            break;
        case 'catalog':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogLayerView} = await import('./catalogLayerView');
                dnLayerView = await buildDotNetCatalogLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'catalog-dynamic-group':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogDynamicGroupLayerView} = await import('./catalogDynamicGroupLayerView');
                dnLayerView = await buildDotNetCatalogDynamicGroupLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'catalog-footprint':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetCatalogFootprintLayerView} = await import('./catalogFootprintLayerView');
                dnLayerView = await buildDotNetCatalogFootprintLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'dimension':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetDimensionLayerView} = await import('./dimensionLayerView');
                dnLayerView = await buildDotNetDimensionLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'media':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetMediaLayerView} = await import('./mediaLayerView');
                dnLayerView = await buildDotNetMediaLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'ogc-feature':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetOGCFeatureLayerView} = await import('./oGCFeatureLayerView');
                dnLayerView = await buildDotNetOGCFeatureLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'point-cloud':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetPointCloudLayerView} = await import('./pointCloudLayerView');
                dnLayerView = await buildDotNetPointCloudLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'scene':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetSceneLayerView} = await import('./sceneLayerView');
                dnLayerView = await buildDotNetSceneLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        case 'stream':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildDotNetStreamLayerView} = await import('./streamLayerView');
                dnLayerView = await buildDotNetStreamLayerView(jsObject);
            } catch {
                throw new Error("Feature only available in GeoBlazor Pro");
            }
            break;
        default:
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

            if (Object.values(arcGisObjectRefs).includes(jsObject)) {
                for (const k of Object.keys(arcGisObjectRefs)) {
                    if (arcGisObjectRefs[k] === jsObject) {
                        dnLayerView.id = k;
                        break;
                    }
                }
            }
    }

    dnLayerView.type = jsObject.layer.type;
    dnLayerView.layerId = layerId;

    return dnLayerView;
}
