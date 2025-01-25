// region imports
import { hasValue, jsObjectRefs, arcGisObjectRefs } from './arcGisJsInterop';
import {
    buildJsPortalItem,
    buildJsFeatureEffect,
    buildJsPopupTemplate,
    buildJsRenderer,
    buildJsFormTemplate,
    buildJsMultidimensionalSubset,
    buildJsExtent
} from './jsBuilder';

// region functions
export async function buildJsWebTileLayer(dotNetObject: any): Promise<any> {
    let { default: WebTileLayer } = await import('@arcgis/core/layers/WebTileLayer');
    let jsWebTileLayer = new WebTileLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsWebTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsWebTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    jsWebTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: WebTileLayerWrapper } = await import('./webTileLayer');
    let webTileLayerWrapper = new WebTileLayerWrapper(jsWebTileLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', webTileLayerWrapper);
    jsObjectRefs[dotNetObject.id] = webTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWebTileLayer;
    return jsWebTileLayer;
}

export async function buildJsTileInfo(dotNetObject: any): Promise<any> {
    let { default: TileInfo } = await import('@arcgis/core/layers/support/TileInfo');
    let jsTileInfo = new TileInfo();
    let { default: TileInfoWrapper } = await import('./tileInfo');
    let tileInfoWrapper = new TileInfoWrapper(jsTileInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', tileInfoWrapper);
    jsObjectRefs[dotNetObject.id] = tileInfoWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTileInfo;
    return jsTileInfo;
}

export async function buildJsPortalFolder(dotNetObject: any): Promise<any> {
    let { default: PortalFolder } = await import('@arcgis/core/portal/PortalFolder');
    let jsPortalFolder = new PortalFolder();
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsPortalFolder);
    jsObjectRefs[dotNetObject.id] = jsPortalFolder;
    arcGisObjectRefs[dotNetObject.id] = jsPortalFolder;
    return jsPortalFolder;
}

export async function buildJsCSVLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: CSVLayer } = await import('@arcgis/core/layers/CSVLayer');
    let jsCSVLayer = new CSVLayer();
    if (hasValue(dotNetObject.featureEffect)) {
        jsCSVLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsCSVLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsCSVLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsCSVLayer.renderer = buildJsRenderer(dotNetObject.renderer) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsCSVLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsCSVLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    jsCSVLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: CSVLayerWrapper } = await import('./cSVLayer');
    let cSVLayerWrapper = new CSVLayerWrapper(jsCSVLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', cSVLayerWrapper);
    jsObjectRefs[dotNetObject.id] = cSVLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayer;
    return jsCSVLayer;
}

export async function buildJsTimeExtent(dotNetObject: any): Promise<any> {
    let { default: TimeExtent } = await import('@arcgis/core/TimeExtent');
    let jsTimeExtent = new TimeExtent();
    let { default: TimeExtentWrapper } = await import('./timeExtent');
    let timeExtentWrapper = new TimeExtentWrapper(jsTimeExtent);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', timeExtentWrapper);
    jsObjectRefs[dotNetObject.id] = timeExtentWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTimeExtent;
    return jsTimeExtent;
}

export async function buildJsTimeInfo(dotNetObject: any): Promise<any> {
    let { default: TimeInfo } = await import('@arcgis/core/layers/support/TimeInfo');
    let jsTimeInfo = new TimeInfo();
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsTimeInfo);
    jsObjectRefs[dotNetObject.id] = jsTimeInfo;
    arcGisObjectRefs[dotNetObject.id] = jsTimeInfo;
    return jsTimeInfo;
}

export async function buildJsGraphicsLayer(dotNetObject: any): Promise<any> {
    let { default: GraphicsLayer } = await import('@arcgis/core/layers/GraphicsLayer');
    let jsGraphicsLayer = new GraphicsLayer();
    let { default: GraphicsLayerWrapper } = await import('./graphicsLayer');
    let graphicsLayerWrapper = new GraphicsLayerWrapper(jsGraphicsLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', graphicsLayerWrapper);
    jsObjectRefs[dotNetObject.id] = graphicsLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGraphicsLayer;
    return jsGraphicsLayer;
}

export async function buildJsGeoRSSLayer(dotNetObject: any): Promise<any> {
    let { default: GeoRSSLayer } = await import('@arcgis/core/layers/GeoRSSLayer');
    let jsGeoRSSLayer = new GeoRSSLayer();
    jsGeoRSSLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: GeoRSSLayerWrapper } = await import('./geoRSSLayer');
    let geoRSSLayerWrapper = new GeoRSSLayerWrapper(jsGeoRSSLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', geoRSSLayerWrapper);
    jsObjectRefs[dotNetObject.id] = geoRSSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGeoRSSLayer;
    return jsGeoRSSLayer;
}

export async function buildJsBaseTileLayer(dotNetObject: any): Promise<any> {
    let { default: BaseTileLayer } = await import('@arcgis/core/layers/BaseTileLayer');
    let jsBaseTileLayer = new BaseTileLayer();
    if (hasValue(dotNetObject.tileInfo)) {
        jsBaseTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    jsBaseTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: BaseTileLayerWrapper } = await import('./baseTileLayer');
    let baseTileLayerWrapper = new BaseTileLayerWrapper(jsBaseTileLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', baseTileLayerWrapper);
    jsObjectRefs[dotNetObject.id] = baseTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBaseTileLayer;
    return jsBaseTileLayer;
}

export async function buildJsFeatureLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: FeatureLayer } = await import('@arcgis/core/layers/FeatureLayer');
    let jsFeatureLayer = new FeatureLayer();
    if (hasValue(dotNetObject.featureEffect)) {
        jsFeatureLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.formTemplate)) {
        jsFeatureLayer.formTemplate = buildJsFormTemplate(dotNetObject.formTemplate) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsFeatureLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsFeatureLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsFeatureLayer.renderer = buildJsRenderer(dotNetObject.renderer) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsFeatureLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsFeatureLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    jsFeatureLayer.on('edits', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsEdits', evt);
    });
    
    jsFeatureLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: FeatureLayerWrapper } = await import('./featureLayer');
    let featureLayerWrapper = new FeatureLayerWrapper(jsFeatureLayer);
    
    // @ts-ignore
    let jsRef = DotNet.createJSObjectReference(featureLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsRef);
    jsObjectRefs[dotNetObject.id] = featureLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayer;
    return jsFeatureLayer;
}

export async function buildJsKMLLayer(dotNetObject: any): Promise<any> {
    let { default: KMLLayer } = await import('@arcgis/core/layers/KMLLayer');
    let jsKMLLayer = new KMLLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsKMLLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    let { default: KMLLayerWrapper } = await import('./kMLLayer');
    let kMLLayerWrapper = new KMLLayerWrapper(jsKMLLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', kMLLayerWrapper);
    jsObjectRefs[dotNetObject.id] = kMLLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsKMLLayer;
    return jsKMLLayer;
}

export async function buildJsVectorTileLayer(dotNetObject: any): Promise<any> {
    let { default: VectorTileLayer } = await import('@arcgis/core/layers/VectorTileLayer');
    let jsVectorTileLayer = new VectorTileLayer();
    if (hasValue(dotNetObject.tileInfo)) {
        jsVectorTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    let { default: VectorTileLayerWrapper } = await import('./vectorTileLayer');
    let vectorTileLayerWrapper = new VectorTileLayerWrapper(jsVectorTileLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', vectorTileLayerWrapper);
    jsObjectRefs[dotNetObject.id] = vectorTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsVectorTileLayer;
    return jsVectorTileLayer;
}

export async function buildJsTileLayer(dotNetObject: any): Promise<any> {
    let { default: TileLayer } = await import('@arcgis/core/layers/TileLayer');
    let jsTileLayer = new TileLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    jsTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: TileLayerWrapper } = await import('./tileLayer');
    let tileLayerWrapper = new TileLayerWrapper(jsTileLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', tileLayerWrapper);
    jsObjectRefs[dotNetObject.id] = tileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTileLayer;
    return jsTileLayer;
}

export async function buildJsGeoJSONLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: GeoJSONLayer } = await import('@arcgis/core/layers/GeoJSONLayer');
    let jsGeoJSONLayer = new GeoJSONLayer();
    if (hasValue(dotNetObject.featureEffect)) {
        jsGeoJSONLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsGeoJSONLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsGeoJSONLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsGeoJSONLayer.renderer = buildJsRenderer(dotNetObject.renderer) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsGeoJSONLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsGeoJSONLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    jsGeoJSONLayer.on('edits', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsEdits', evt);
    });
    
    jsGeoJSONLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: GeoJSONLayerWrapper } = await import('./geoJSONLayer');
    let geoJSONLayerWrapper = new GeoJSONLayerWrapper(jsGeoJSONLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', geoJSONLayerWrapper);
    jsObjectRefs[dotNetObject.id] = geoJSONLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGeoJSONLayer;
    return jsGeoJSONLayer;
}

export async function buildJsElevationLayer(dotNetObject: any): Promise<any> {
    let { default: ElevationLayer } = await import('@arcgis/core/layers/ElevationLayer');
    let jsElevationLayer = new ElevationLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsElevationLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsElevationLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    let { default: ElevationLayerWrapper } = await import('./elevationLayer');
    let elevationLayerWrapper = new ElevationLayerWrapper(jsElevationLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', elevationLayerWrapper);
    jsObjectRefs[dotNetObject.id] = elevationLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsElevationLayer;
    return jsElevationLayer;
}

export async function buildJsImageryTileLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { default: ImageryTileLayer } = await import('@arcgis/core/layers/ImageryTileLayer');
    let jsImageryTileLayer = new ImageryTileLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsImageryTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.rasterFunction)) {
        jsImageryTileLayer.rasterFunction = await buildJsRasterFunction(dotNetObject.rasterFunction) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsImageryTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    let { default: ImageryTileLayerWrapper } = await import('./imageryTileLayer');
    let imageryTileLayerWrapper = new ImageryTileLayerWrapper(jsImageryTileLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', imageryTileLayerWrapper);
    jsObjectRefs[dotNetObject.id] = imageryTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsImageryTileLayer;
    return jsImageryTileLayer;
}

export async function buildJsRasterFunction(dotNetObject: any): Promise<any> {
    let { default: RasterFunction } = await import('@arcgis/core/layers/support/RasterFunction');
    let jsRasterFunction = new RasterFunction();
    if (hasValue(dotNetObject.functionArguments)) {
        jsRasterFunction.functionArguments = dotNetObject.functionArguments;
    }
    if (hasValue(dotNetObject.functionName)) {
        jsRasterFunction.functionName = dotNetObject.functionName;
    }
    if (hasValue(dotNetObject.rasterFunctionDefinition)) {
        jsRasterFunction.rasterFunctionDefinition = dotNetObject.rasterFunctionDefinition;
    }
    if (hasValue(dotNetObject.variableName)) {
        jsRasterFunction.variableName = dotNetObject.variableName;
    }
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsRasterFunction);
    jsObjectRefs[dotNetObject.id] = jsRasterFunction;
    arcGisObjectRefs[dotNetObject.id] = jsRasterFunction;
    return jsRasterFunction;
}

export async function buildJsImageryLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: ImageryLayer } = await import('@arcgis/core/layers/ImageryLayer');
    let jsImageryLayer = new ImageryLayer();
    if (hasValue(dotNetObject.multidimensionalSubset)) {
        jsImageryLayer.multidimensionalSubset = buildJsMultidimensionalSubset(dotNetObject.multidimensionalSubset) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsImageryLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsImageryLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.rasterFunction)) {
        jsImageryLayer.rasterFunction = await buildJsRasterFunction(dotNetObject.rasterFunction) as any;
    }
    jsImageryLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: ImageryLayerWrapper } = await import('./imageryLayer');
    let imageryLayerWrapper = new ImageryLayerWrapper(jsImageryLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', imageryLayerWrapper);
    jsObjectRefs[dotNetObject.id] = imageryLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsImageryLayer;
    return jsImageryLayer;
}

export async function buildJsWCSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: WCSLayer } = await import('@arcgis/core/layers/WCSLayer');
    let jsWCSLayer = new WCSLayer();
    if (hasValue(dotNetObject.coverageInfo)) {
        jsWCSLayer.coverageInfo = await buildJsCoverageInfo(dotNetObject.coverageInfo) as any;
    }
    if (hasValue(dotNetObject.multidimensionalSubset)) {
        jsWCSLayer.multidimensionalSubset = buildJsMultidimensionalSubset(dotNetObject.multidimensionalSubset) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsWCSLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsWCSLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsWCSLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsWCSLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    let { default: WCSLayerWrapper } = await import('./wCSLayer');
    let wCSLayerWrapper = new WCSLayerWrapper(jsWCSLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', wCSLayerWrapper);
    jsObjectRefs[dotNetObject.id] = wCSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWCSLayer;
    return jsWCSLayer;
}

export async function buildJsCoverageInfo(dotNetObject: any): Promise<any> {
    let jsCoverageInfo = {
        rasterInfo: await buildJsRasterInfo(dotNetObject.rasterInfo) as any,
    }
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsCoverageInfo);
    jsObjectRefs[dotNetObject.id] = jsCoverageInfo;
    arcGisObjectRefs[dotNetObject.id] = jsCoverageInfo;
    return jsCoverageInfo;
}

export async function buildJsRasterInfo(dotNetObject: any): Promise<any> {
    let { default: RasterInfo } = await import('@arcgis/core/layers/support/RasterInfo');
    let jsRasterInfo = new RasterInfo();
    if (hasValue(dotNetObject.extent)) {
        jsRasterInfo.extent = buildJsExtent(dotNetObject.extent) as any;
    }
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsRasterInfo);
    jsObjectRefs[dotNetObject.id] = jsRasterInfo;
    arcGisObjectRefs[dotNetObject.id] = jsRasterInfo;
    return jsRasterInfo;
}

export async function buildJsBingMapsLayer(dotNetObject: any): Promise<any> {
    let { default: BingMapsLayer } = await import('@arcgis/core/layers/BingMapsLayer');
    let jsBingMapsLayer = new BingMapsLayer();
    if (hasValue(dotNetObject.tileInfo)) {
        jsBingMapsLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    jsBingMapsLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: BingMapsLayerWrapper } = await import('./bingMapsLayer');
    let bingMapsLayerWrapper = new BingMapsLayerWrapper(jsBingMapsLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', bingMapsLayerWrapper);
    jsObjectRefs[dotNetObject.id] = bingMapsLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBingMapsLayer;
    return jsBingMapsLayer;
}

export async function buildJsMapImageLayer(dotNetObject: any): Promise<any> {
    let { default: MapImageLayer } = await import('@arcgis/core/layers/MapImageLayer');
    let jsMapImageLayer = new MapImageLayer();
    if (hasValue(dotNetObject.portalItem)) {
        jsMapImageLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    jsMapImageLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: MapImageLayerWrapper } = await import('./mapImageLayer');
    let mapImageLayerWrapper = new MapImageLayerWrapper(jsMapImageLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', mapImageLayerWrapper);
    jsObjectRefs[dotNetObject.id] = mapImageLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsMapImageLayer;
    return jsMapImageLayer;
}

export async function buildJsPortalItemResource(dotNetObject: any): Promise<any> {
    let { default: PortalItemResource } = await import('@arcgis/core/portal/PortalItemResource');
    let jsPortalItemResource = new PortalItemResource();
    if (hasValue(dotNetObject.portalItem)) {
        jsPortalItemResource.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    let { default: PortalItemResourceWrapper } = await import('./portalItemResource');
    let portalItemResourceWrapper = new PortalItemResourceWrapper(jsPortalItemResource);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', portalItemResourceWrapper);
    jsObjectRefs[dotNetObject.id] = portalItemResourceWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsPortalItemResource;
    return jsPortalItemResource;
}

