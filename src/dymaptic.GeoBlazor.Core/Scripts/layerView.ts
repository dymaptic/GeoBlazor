import {hasValue} from "./arcGisJsInterop";

export async function buildJsLayerView(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject?.layer)) {
        return null;
    }
    
    switch (dotNetObject.layer.type) {
        case 'feature':
            let { buildJsFeatureLayerView } = await import('./featureLayerView');
            return await buildJsFeatureLayerView(dotNetObject);
        case 'graphics':
            let { buildJsGraphicsLayerView } = await import('./graphicsLayerView');
            return await buildJsGraphicsLayerView(dotNetObject);
        case 'imagery':
            let { buildJsImageryLayerView } = await import('./imageryLayerView');
            return await buildJsImageryLayerView(dotNetObject);
        case 'kml':
            let { buildJsKMLLayerView } = await import('./kMLLayerView');
            return await buildJsKMLLayerView(dotNetObject);
        case 'building-scene':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsBuildingSceneLayerView } = await import('./buildingSceneLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsBuildingSceneLayerView(dotNetObject);
        case 'catalog':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsCatalogLayerView } = await import('./catalogLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsCatalogLayerView(dotNetObject);
        case 'dimension':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsDimensionLayerView } = await import('./dimensionLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsDimensionLayerView(dotNetObject);
        case 'media':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsMediaLayerView } = await import('./mediaLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsMediaLayerView(dotNetObject);
        case 'point-cloud':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsPointCloudLayerView } = await import('./pointCloudLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsPointCloudLayerView(dotNetObject);
        case 'scene':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsSceneLayerView } = await import('./sceneLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsSceneLayerView(dotNetObject);
        case 'stream':
            // @ts-ignore GeoBlazor Pro Only
            let { buildJsStreamLayerView } = await import('./streamLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildJsStreamLayerView(dotNetObject);
        default:
            let { buildJsLayerViewGenerated } = await import('./layerView.gb');
            return await buildJsLayerViewGenerated(dotNetObject);
}

export async function buildDotNetLayerView(jsObject: any): Promise<any> {
    switch (jsObject?.layer?.type) {
        case 'feature':
            let { buildDotNetFeatureLayerView } = await import('./featureLayerView');
            return await buildDotNetFeatureLayerView(jsObject);
        case 'graphics':
            let { buildDotNetGraphicsLayerView } = await import('./graphicsLayerView');
            return await buildDotNetGraphicsLayerView(jsObject);
        case 'imagery':
            let { buildDotNetImageryLayerView } = await import('./imageryLayerView');
            return await buildDotNetImageryLayerView(jsObject);
        case 'kml':
            let { buildDotNetKMLLayerView } = await import('./kMLLayerView');
            return await buildDotNetKMLLayerView(jsObject);
        case 'building-scene':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetBuildingSceneLayerView } = await import('./buildingSceneLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetBuildingSceneLayerView(jsObject);
        case 'catalog':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetCatalogLayerView } = await import('./catalogLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetCatalogLayerView(jsObject);
        case 'dimension':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetDimensionLayerView } = await import('./dimensionLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetDimensionLayerView(jsObject);
        case 'media':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetMediaLayerView } = await import('./mediaLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetMediaLayerView(jsObject);
        case 'point-cloud':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetPointCloudLayerView } = await import('./pointCloudLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetPointCloudLayerView(jsObject);
        case 'scene':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetSceneLayerView } = await import('./sceneLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetSceneLayerView(jsObject);
        case 'stream':
            // @ts-ignore GeoBlazor Pro Only
            let { buildDotNetStreamLayerView } = await import('./streamLayerView');
            // @ts-ignore GeoBlazor Pro Only
            return await buildDotNetStreamLayerView(jsObject);
        default:
            let {buildDotNetLayerViewGenerated} = await import('./layerView.gb');
            return await buildDotNetLayerViewGenerated(jsObject);
    }
}
