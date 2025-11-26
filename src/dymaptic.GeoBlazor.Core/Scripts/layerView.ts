import Layer from "@arcgis/core/layers/Layer";
import {arcGisObjectRefs, dotNetRefs, hasValue, jsObjectRefs, lookupGeoBlazorId, Pro} from './geoBlazorCore';
import MapView from "@arcgis/core/views/MapView";
import SceneView from "@arcgis/core/views/SceneView";

export async function buildJsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject?.layer)) {
        return null;
    }
    
    if (arcGisObjectRefs.hasOwnProperty(dotNetObject.id)) {
        return arcGisObjectRefs[dotNetObject.id];
    }
    
    let jsLayerView: any | null = null;
    if (hasValue(layerId) && arcGisObjectRefs.hasOwnProperty(layerId!)) {
        let layer = arcGisObjectRefs[layerId!] as Layer;
        let view = arcGisObjectRefs[viewId!] as MapView | SceneView;
        jsLayerView = await layer.createLayerView(view);
        let wrapper = await buildJsLayerViewWrapper(jsLayerView);
        arcGisObjectRefs[dotNetObject.id] = jsLayerView;
        jsObjectRefs[dotNetObject.id] = wrapper;
        return jsLayerView;
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
        case 'imagery-tile':
            let {buildDotNetImageryTileLayerView} = await import('./imageryTileLayerView');
            dnLayerView = await buildDotNetImageryTileLayerView(jsObject, viewId);
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
        //     if (Pro) {
        //         try {
        //             // @ts-ignore GeoBlazor Pro only
        //             let {buildDotNetBuildingSceneLayerView} = await import('./buildingSceneLayerView');
        //             dnLayerView = await buildDotNetBuildingSceneLayerView(jsObject);
        //         } catch (e) {
        //             throw new Error('Feature only available in GeoBlazor Pro');
        //         }
        //     }
        //     break;
        case 'ogc-feature':
            if (Pro) {
                try {
                    // @ts-ignore GeoBlazor Pro Only
                    let {buildDotNetOGCFeatureLayerView} = await import('./oGCFeatureLayerView');
                    dnLayerView = await buildDotNetOGCFeatureLayerView(jsObject, viewId);
                } catch (e) {
                    throw e;
                }
            }
            break;
        case 'catalog':
            if (Pro) {
                try {
                    // @ts-ignore GeoBlazor Pro Only
                    let {buildDotNetCatalogLayerView} = await import('./catalogLayerView');
                    dnLayerView = await buildDotNetCatalogLayerView(jsObject, viewId);
                } catch (e) {
                    throw e;
                }
            }
            break;
        case 'catalog-footprint':
            if (Pro) {
                try {
                    // @ts-ignore GeoBlazor Pro Only
                    let {buildDotNetCatalogFootprintLayerView} = await import('./catalogFootprintLayerView');
                    dnLayerView = await buildDotNetCatalogFootprintLayerView(jsObject, viewId);
                } catch (e) {
                    throw e;
                }
            }
            break;
        case 'catalog-dynamic-group':
            if (Pro) {
                try {
                    // @ts-ignore GeoBlazor Pro Only
                    let {buildDotNetCatalogDynamicGroupLayerView} = await import('./catalogDynamicGroupLayerView');
                    dnLayerView = await buildDotNetCatalogDynamicGroupLayerView(jsObject, viewId);
                } catch (e) {
                    throw e;
                }
            }
            break;
        // case 'point-cloud':
        //     if (Pro) {
        //         try {
        //             // @ts-ignore GeoBlazor Pro Only
        //             let {buildDotNetPointCloudLayerView} = await import('./pointCloudLayerView');
        //             dnLayerView = await buildDotNetPointCloudLayerView(jsObject, viewId);
        //         } catch (e) {
        //             throw e;
        //         }
        //     }
        //     break;
        // case 'scene':
        //     if (Pro) {
        //         try {
        //             // @ts-ignore GeoBlazor Pro Only
        //             let {buildDotNetSceneLayerView} = await import('./sceneLayerView');
        //             dnLayerView = await buildDotNetSceneLayerView(jsObject, viewId);
        //         } catch (e) {
        //             throw e;
        //         }
        //     }
        //     break;
        // case 'stream':
        //     if (Pro) {
        //         try {
        //             // @ts-ignore GeoBlazor Pro Only
        //             let {buildDotNetStreamLayerView} = await import('./streamLayerView');
        //             dnLayerView = await buildDotNetStreamLayerView(jsObject, viewId);
        //         } catch (e) {
        //             throw e;
        //         }
        //     }
        //     break;
        // case 'media':
        //     if (Pro) {
        //         try {
        //             // @ts-ignore GeoBlazor Pro Only
        //             let {buildDotNetMediaLayerView} = await import('./mediaLayerView');
        //             dnLayerView = await buildDotNetMediaLayerView(jsObject, viewId);
        //         } catch (e) {
        //             throw e;
        //         }
        //     }
        //     break;
        case 'vector-tile':
            let {buildDotNetVectorTileLayerView} = await import('./vectorTileLayerView');
            dnLayerView = await buildDotNetVectorTileLayerView(jsObject, viewId);
            break;
    }
    
    if (!hasValue(dnLayerView)) {
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


export async function buildJsLayerViewWrapper(jsLayerView: any): Promise<any> {
    if (!hasValue(jsLayerView)) {
        return null;
    }

    let geoBlazorId = lookupGeoBlazorId(jsLayerView);
    if (hasValue(geoBlazorId) && jsObjectRefs.hasOwnProperty(geoBlazorId!)) {
        return jsObjectRefs[geoBlazorId!];
    }
    
    switch (jsLayerView.layer?.type) {
        case 'csv': {
            let {default: CSVLayerViewWrapper} = await import('./cSVLayerView');
            return new CSVLayerViewWrapper(jsLayerView);
        }
        case 'feature': {
            let {default: FeatureLayerViewWrapper} = await import('./featureLayerView');
            return new FeatureLayerViewWrapper(jsLayerView);
        }
        case 'geojson': {
            let {default: GeoJSONLayerViewWrapper} = await import('./geoJSONLayerView');
            return new GeoJSONLayerViewWrapper(jsLayerView);
        }
        case 'geo-rss': {
            let {default: GeoRSSLayerViewWrapper} = await import('./geoRSSLayerView');
            return new GeoRSSLayerViewWrapper(jsLayerView);
        }
        case 'graphics': {
            let {default: GraphicsLayerViewWrapper} = await import('./graphicsLayerView');
            return new GraphicsLayerViewWrapper(jsLayerView);
        }
        case 'imagery': {
            let {default: ImageryLayerViewWrapper} = await import('./imageryLayerView');
            return new ImageryLayerViewWrapper(jsLayerView);
        }
        case 'imagery-tile': {
            let {default: ImageryTileLayerViewWrapper} = await import('./imageryTileLayerView');
            return new ImageryTileLayerViewWrapper(jsLayerView);
        }
        case 'kml': {
            let {default: KMLLayerViewWrapper} = await import('./kMLLayerView');
            return new KMLLayerViewWrapper(jsLayerView);
        }
        case 'wfs': {
            let {default: WFSLayerViewWrapper} = await import('./wFSLayerView');
            return new WFSLayerViewWrapper(jsLayerView);
        }
        case 'ogc-feature': {
            if (!Pro) return jsLayerView;
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {default: OGCFeatureLayerViewWrapper} = await import('./oGCFeatureLayerView');
                return new OGCFeatureLayerViewWrapper(jsLayerView);
            } catch (e) {
                throw e;
            }
        }
        case 'catalog': {
            if (!Pro) return jsLayerView;
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {default: CatalogLayerViewWrapper} = await import('./catalogLayerView');
                return new CatalogLayerViewWrapper(jsLayerView);
            } catch (e) {
                throw e;
            }
        }
        case 'catalog-footprint': {
            if (!Pro) return jsLayerView;
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {default: CatalogFootprintLayerViewWrapper} = await import('./catalogFootprintLayerView');
                return new CatalogFootprintLayerViewWrapper(jsLayerView);
            } catch (e) {
                throw e;
            }
        }
        case 'catalog-dynamic-group': {
            if (!Pro) return jsLayerView;
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {default: CatalogDynamicGroupLayerViewWrapper} = await import('./catalogDynamicGroupLayerView');
                return new CatalogDynamicGroupLayerViewWrapper(jsLayerView);
            } catch (e) {
                throw e;
            }
        }
        case 'group': {
            if (!Pro) return jsLayerView;
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {default: GroupLayerViewWrapper} = await import('./groupLayerView');
                return new GroupLayerViewWrapper(jsLayerView);
            } catch (e) {
                throw e;
            }
        }
        // case 'point-cloud': {
        //     if (!Pro) return jsLayerView;
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {default: PointCloudLayerViewWrapper} = await import('./pointCloudLayerView');
        //         return new PointCloudLayerViewWrapper(jsLayerView);
        //     } catch (e) {
        //         throw e;
        //     }
        // }
        // case 'scene': {
        //     if (!Pro) return jsLayerView;
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {default: SceneLayerViewWrapper} = await import('./sceneLayerView');
        //         return new SceneLayerViewWrapper(jsLayerView);
        //     } catch (e) {
        //         throw e;
        //     }
        // }
        // case 'stream': {
        //     if (!Pro) return jsLayerView;
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {default: StreamLayerViewWrapper} = await import('./streamLayerView');
        //         return new StreamLayerViewWrapper(jsLayerView);
        //     } catch (e) {
        //         throw e;
        //     }
        // }
        // case 'media': {
        //     if (!Pro) return jsLayerView;
        //     try {
        //         // @ts-ignore GeoBlazor Pro Only
        //         let {default: MediaLayerViewWrapper} = await import('./mediaLayerView');
        //         return new MediaLayerViewWrapper(jsLayerView);
        //     } catch (e) {
        //         throw e;
        //     }
        // }
        case 'vector-tile': {
            let {default: VectorTileLayerViewWrapper} = await import('./vectorTileLayerView');
            return new VectorTileLayerViewWrapper(jsLayerView);
        }
        // Add other cases as needed, following the same pattern as above.
        default:
            // just return the view object as is
            return jsLayerView;
    }
}
