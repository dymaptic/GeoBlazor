// override generated code in this file
import {arcGisObjectRefs, disposeMapComponent, hasValue, removeCircularReferences} from "./arcGisJsInterop";

export async function buildJsWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    if (hasValue(dotNetObject.id) && arcGisObjectRefs.hasOwnProperty(dotNetObject.id!)) {
        return arcGisObjectRefs[dotNetObject.id!];
    }

    switch (dotNetObject.type) {
        case 'area-measurement2-d':
            let {buildJsAreaMeasurement2DWidget} = await import('./areaMeasurement2DWidget');
            return await buildJsAreaMeasurement2DWidget(dotNetObject, layerId, viewId);
        case 'basemap-gallery':
            let {buildJsBasemapGalleryWidget} = await import('./basemapGalleryWidget');
            return await buildJsBasemapGalleryWidget(dotNetObject, layerId, viewId);
        case 'basemap-layer-list':
            let {buildJsBasemapLayerListWidget} = await import('./basemapLayerListWidget');
            return await buildJsBasemapLayerListWidget(dotNetObject, layerId, viewId);
        case 'basemap-toggle':
            let {buildJsBasemapToggleWidget} = await import('./basemapToggleWidget');
            return await buildJsBasemapToggleWidget(dotNetObject, layerId, viewId);
        case 'bookmarks':
            let {buildJsBookmarksWidget} = await import('./bookmarksWidget');
            return await buildJsBookmarksWidget(dotNetObject, layerId, viewId);
        case 'compass':
            let {buildJsCompassWidget} = await import('./compassWidget');
            return await buildJsCompassWidget(dotNetObject, layerId, viewId);
        case 'distance-measurement-2d':
            let {buildJsDistanceMeasurement2DWidget} = await import('./distanceMeasurement2DWidget');
            return await buildJsDistanceMeasurement2DWidget(dotNetObject, layerId, viewId);
        case 'expand':
            let {buildJsExpandWidget} = await import('./expandWidget');
            return await buildJsExpandWidget(dotNetObject, layerId, viewId);
        case 'home':
            let {buildJsHomeWidget} = await import('./homeWidget');
            return await buildJsHomeWidget(dotNetObject, layerId, viewId);
        case 'layer-list':
            let {buildJsLayerListWidget} = await import('./layerListWidget');
            return await buildJsLayerListWidget(dotNetObject, layerId, viewId);
        case 'legend':
            let {buildJsLegendWidget} = await import('./legendWidget');
            return await buildJsLegendWidget(dotNetObject, layerId, viewId);
        case 'list-item-panel':
            let {buildJsListItemPanelWidget} = await import('./listItemPanelWidget');
            return await buildJsListItemPanelWidget(dotNetObject, layerId, viewId);
        case 'locate':
            let {buildJsLocateWidget} = await import('./locateWidget');
            return await buildJsLocateWidget(dotNetObject, layerId, viewId);
        case 'measurement':
            let {buildJsMeasurementWidget} = await import('./measurementWidget');
            return await buildJsMeasurementWidget(dotNetObject, layerId, viewId);
        case 'popup':
            let {buildJsPopupWidget} = await import('./popupWidget');
            return await buildJsPopupWidget(dotNetObject, layerId, viewId);
        case 'scale-bar':
            let {buildJsScaleBarWidget} = await import('./scaleBarWidget');
            return await buildJsScaleBarWidget(dotNetObject, layerId, viewId);
        case 'search':
            let {buildJsSearchWidget} = await import('./searchWidget');
            return await buildJsSearchWidget(dotNetObject, layerId, viewId);
        case 'slider':
            let {buildJsSliderWidget} = await import('./sliderWidget');
            return await buildJsSliderWidget(dotNetObject, layerId, viewId);
        case 'zoom':
            let {buildJsZoomWidget} = await import('./zoomWidget');
            return await buildJsZoomWidget(dotNetObject, layerId, viewId);
        case 'catalog-layer-list':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsCatalogLayerListWidget} = await import('./catalogLayerListWidget');
                return await buildJsCatalogLayerListWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'editor':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsEditorWidget} = await import('./editorWidget');
                return await buildJsEditorWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'feature':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsFeatureWidget} = await import('./featureWidget');
                return await buildJsFeatureWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'feature-form':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsFeatureFormWidget} = await import('./featureFormWidget');
                return await buildJsFeatureFormWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'feature-templates':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsFeatureTemplatesWidget} = await import('./featureTemplatesWidget');
                return await buildJsFeatureTemplatesWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'print':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsPrintWidget} = await import('./printWidget');
                return await buildJsPrintWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'sketch':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsSketchWidget} = await import('./sketchWidget');
                return await buildJsSketchWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'swipe':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsSwipeWidget} = await import('./swipeWidget');
                return await buildJsSwipeWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'table-list-item-panel':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsTableListItemPanelWidget} = await import('./tableListItemPanelWidget');
                return await buildJsTableListItemPanelWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'table-list':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsTableListWidget} = await import('./tableListWidget');
                return await buildJsTableListWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'time-slider':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsTimeSliderWidget} = await import('./timeSliderWidget');
                return await buildJsTimeSliderWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        case 'track':
            try {
                // @ts-ignore only available in GeoBlazor Pro
                let {buildJsTrackWidget} = await import('./trackWidget');
                return await buildJsTrackWidget(dotNetObject, layerId, viewId);
            } catch (e) {
                throw e;
            }
        default:
            let {id, dotNetComponentReference, ...sanitizedDotNetObject} = dotNetObject;
            return sanitizedDotNetObject;
    }
}

export async function buildDotNetWidget(jsObject: any): Promise<any> {
    return removeCircularReferences(jsObject);
}
