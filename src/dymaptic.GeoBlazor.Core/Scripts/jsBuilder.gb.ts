// region imports
import { hasValue, jsObjectRefs, arcGisObjectRefs } from './arcGisJsInterop';
import {
    buildJsPortalItem,
    buildJsFeatureEffect,
    buildJsPopupTemplate,
    buildJsRenderer,
    buildJsFormTemplate,
    buildJsMultidimensionalSubset
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
    if (hasValue(dotNetObject.id)) {
        jsWebTileLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.effect)) {
        jsWebTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsWebTileLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsWebTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsWebTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsWebTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        jsWebTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsWebTileLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.lods)) {
        jsTileInfo.lods = dotNetObject.lods;
    }
    if (hasValue(dotNetObject.origin)) {
        jsTileInfo.origin = dotNetObject.origin;
    }
    if (hasValue(dotNetObject.size)) {
        jsTileInfo.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsTileInfo.spatialReference = dotNetObject.spatialReference;
    }
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
    if (hasValue(dotNetObject.created)) {
        jsPortalFolder.created = dotNetObject.created;
    }
    if (hasValue(dotNetObject.id)) {
        jsPortalFolder.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.title)) {
        jsPortalFolder.title = dotNetObject.title;
    }
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
    if (hasValue(dotNetObject.id)) {
        jsCSVLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsCSVLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.definitionExpression)) {
        jsCSVLayer.definitionExpression = dotNetObject.definitionExpression;
    }
    if (hasValue(dotNetObject.effect)) {
        jsCSVLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.elevationInfo)) {
        jsCSVLayer.elevationInfo = dotNetObject.elevationInfo;
    }
    if (hasValue(dotNetObject.fields)) {
        jsCSVLayer.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsCSVLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsCSVLayer.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsCSVLayer.labelingInfo = dotNetObject.labelingInfo;
    }
    if (hasValue(dotNetObject.labelsVisible)) {
        jsCSVLayer.labelsVisible = dotNetObject.labelsVisible;
    }
    if (hasValue(dotNetObject.latitudeField)) {
        jsCSVLayer.latitudeField = dotNetObject.latitudeField;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsCSVLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsCSVLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.longitudeField)) {
        jsCSVLayer.longitudeField = dotNetObject.longitudeField;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsCSVLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsCSVLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.objectIdField)) {
        jsCSVLayer.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsCSVLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsCSVLayer.orderBy = dotNetObject.orderBy;
    }
    if (hasValue(dotNetObject.outFields)) {
        jsCSVLayer.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsCSVLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsCSVLayer.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsCSVLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
        jsCSVLayer.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsCSVLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsCSVLayer.timeOffset = dotNetObject.timeOffset;
    }
    if (hasValue(dotNetObject.title)) {
        jsCSVLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsCSVLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsCSVLayer.useViewTime = dotNetObject.useViewTime;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsCSVLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.end)) {
        jsTimeExtent.end = dotNetObject.end;
    }
    if (hasValue(dotNetObject.start)) {
        jsTimeExtent.start = dotNetObject.start;
    }
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
    if (hasValue(dotNetObject.endField)) {
        jsTimeInfo.endField = dotNetObject.endField;
    }
    if (hasValue(dotNetObject.fullTimeExtent)) {
        jsTimeInfo.fullTimeExtent = dotNetObject.fullTimeExtent;
    }
    if (hasValue(dotNetObject.interval)) {
        jsTimeInfo.interval = dotNetObject.interval;
    }
    if (hasValue(dotNetObject.startField)) {
        jsTimeInfo.startField = dotNetObject.startField;
    }
    if (hasValue(dotNetObject.stops)) {
        jsTimeInfo.stops = dotNetObject.stops;
    }
    if (hasValue(dotNetObject.timeZone)) {
        jsTimeInfo.timeZone = dotNetObject.timeZone;
    }
    if (hasValue(dotNetObject.trackIdField)) {
        jsTimeInfo.trackIdField = dotNetObject.trackIdField;
    }
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsTimeInfo);
    jsObjectRefs[dotNetObject.id] = jsTimeInfo;
    arcGisObjectRefs[dotNetObject.id] = jsTimeInfo;
    return jsTimeInfo;
}

export async function buildJsGraphicsLayer(dotNetObject: any): Promise<any> {
    let { default: GraphicsLayer } = await import('@arcgis/core/layers/GraphicsLayer');
    let jsGraphicsLayer = new GraphicsLayer();
    if (hasValue(dotNetObject.id)) {
        jsGraphicsLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.elevationInfo)) {
        jsGraphicsLayer.elevationInfo = dotNetObject.elevationInfo;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsGraphicsLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsGraphicsLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsGraphicsLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsGraphicsLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        jsGraphicsLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGraphicsLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
    }
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
    if (hasValue(dotNetObject.id)) {
        jsGeoRSSLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsGeoRSSLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsGeoRSSLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsGeoRSSLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsGeoRSSLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.lineSymbol)) {
        jsGeoRSSLayer.lineSymbol = dotNetObject.lineSymbol;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsGeoRSSLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsGeoRSSLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsGeoRSSLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsGeoRSSLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsGeoRSSLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.pointSymbol)) {
        jsGeoRSSLayer.pointSymbol = dotNetObject.pointSymbol;
    }
    if (hasValue(dotNetObject.polygonSymbol)) {
        jsGeoRSSLayer.polygonSymbol = dotNetObject.polygonSymbol;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsGeoRSSLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.title)) {
        jsGeoRSSLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGeoRSSLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
    }
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
    if (hasValue(dotNetObject.id)) {
        jsBaseTileLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsBaseTileLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsBaseTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsBaseTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsBaseTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsBaseTileLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.title)) {
        jsBaseTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsBaseTileLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsFeatureLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.charts)) {
        jsFeatureLayer.charts = dotNetObject.charts;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsFeatureLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsFeatureLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.dateFieldsTimeZone)) {
        jsFeatureLayer.dateFieldsTimeZone = dotNetObject.dateFieldsTimeZone;
    }
    if (hasValue(dotNetObject.displayField)) {
        jsFeatureLayer.displayField = dotNetObject.displayField;
    }
    if (hasValue(dotNetObject.dynamicDataSource)) {
        jsFeatureLayer.dynamicDataSource = dotNetObject.dynamicDataSource;
    }
    if (hasValue(dotNetObject.editingEnabled)) {
        jsFeatureLayer.editingEnabled = dotNetObject.editingEnabled;
    }
    if (hasValue(dotNetObject.elevationInfo)) {
        jsFeatureLayer.elevationInfo = dotNetObject.elevationInfo;
    }
    if (hasValue(dotNetObject.fields)) {
        jsFeatureLayer.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.floorInfo)) {
        jsFeatureLayer.floorInfo = dotNetObject.floorInfo;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsFeatureLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.gdbVersion)) {
        jsFeatureLayer.gdbVersion = dotNetObject.gdbVersion;
    }
    if (hasValue(dotNetObject.hasM)) {
        jsFeatureLayer.hasM = dotNetObject.hasM;
    }
    if (hasValue(dotNetObject.hasZ)) {
        jsFeatureLayer.hasZ = dotNetObject.hasZ;
    }
    if (hasValue(dotNetObject.historicMoment)) {
        jsFeatureLayer.historicMoment = dotNetObject.historicMoment;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsFeatureLayer.labelingInfo = dotNetObject.labelingInfo;
    }
    if (hasValue(dotNetObject.labelsVisible)) {
        jsFeatureLayer.labelsVisible = dotNetObject.labelsVisible;
    }
    if (hasValue(dotNetObject.layerId)) {
        jsFeatureLayer.layerId = dotNetObject.layerId;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsFeatureLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsFeatureLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsFeatureLayer.orderBy = dotNetObject.orderBy;
    }
    if (hasValue(dotNetObject.outFields)) {
        jsFeatureLayer.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsFeatureLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsFeatureLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.returnM)) {
        jsFeatureLayer.returnM = dotNetObject.returnM;
    }
    if (hasValue(dotNetObject.returnZ)) {
        jsFeatureLayer.returnZ = dotNetObject.returnZ;
    }
    if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
        jsFeatureLayer.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
    }
    if (hasValue(dotNetObject.source)) {
        jsFeatureLayer.source = dotNetObject.source;
    }
    if (hasValue(dotNetObject.sourceJSON)) {
        jsFeatureLayer.sourceJSON = dotNetObject.sourceJSON;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsFeatureLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.templates)) {
        jsFeatureLayer.templates = dotNetObject.templates;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsFeatureLayer.timeOffset = dotNetObject.timeOffset;
    }
    if (hasValue(dotNetObject.title)) {
        jsFeatureLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.typeIdField)) {
        jsFeatureLayer.typeIdField = dotNetObject.typeIdField;
    }
    if (hasValue(dotNetObject.types)) {
        jsFeatureLayer.types = dotNetObject.types;
    }
    if (hasValue(dotNetObject.url)) {
        jsFeatureLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsFeatureLayer.useViewTime = dotNetObject.useViewTime;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsFeatureLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
    }
    jsFeatureLayer.on('edits', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsEdits', evt);
    });
    
    jsFeatureLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: FeatureLayerWrapper } = await import('./featureLayer');
    let featureLayerWrapper = new FeatureLayerWrapper(jsFeatureLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', featureLayerWrapper);
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
    if (hasValue(dotNetObject.id)) {
        jsKMLLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsKMLLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsKMLLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsKMLLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsKMLLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsKMLLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsKMLLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsKMLLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsKMLLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.sublayers)) {
        jsKMLLayer.sublayers = dotNetObject.sublayers;
    }
    if (hasValue(dotNetObject.title)) {
        jsKMLLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsKMLLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsKMLLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.apiKey)) {
        jsVectorTileLayer.apiKey = dotNetObject.apiKey;
    }
    if (hasValue(dotNetObject.id)) {
        jsVectorTileLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsVectorTileLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsVectorTileLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.effect)) {
        jsVectorTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsVectorTileLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.initialExtent)) {
        jsVectorTileLayer.initialExtent = dotNetObject.initialExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsVectorTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsVectorTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsVectorTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.style)) {
        jsVectorTileLayer.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.title)) {
        jsVectorTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsVectorTileLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsTileLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsTileLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsTileLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsTileLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsTileLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.resampling)) {
        jsTileLayer.resampling = dotNetObject.resampling;
    }
    if (hasValue(dotNetObject.subtables)) {
        jsTileLayer.subtables = dotNetObject.subtables;
    }
    if (hasValue(dotNetObject.title)) {
        jsTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsTileLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsTileLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsGeoJSONLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsGeoJSONLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsGeoJSONLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.definitionExpression)) {
        jsGeoJSONLayer.definitionExpression = dotNetObject.definitionExpression;
    }
    if (hasValue(dotNetObject.displayField)) {
        jsGeoJSONLayer.displayField = dotNetObject.displayField;
    }
    if (hasValue(dotNetObject.editingEnabled)) {
        jsGeoJSONLayer.editingEnabled = dotNetObject.editingEnabled;
    }
    if (hasValue(dotNetObject.effect)) {
        jsGeoJSONLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.elevationInfo)) {
        jsGeoJSONLayer.elevationInfo = dotNetObject.elevationInfo;
    }
    if (hasValue(dotNetObject.fields)) {
        jsGeoJSONLayer.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsGeoJSONLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsGeoJSONLayer.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsGeoJSONLayer.labelingInfo = dotNetObject.labelingInfo;
    }
    if (hasValue(dotNetObject.labelsVisible)) {
        jsGeoJSONLayer.labelsVisible = dotNetObject.labelsVisible;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsGeoJSONLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsGeoJSONLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsGeoJSONLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsGeoJSONLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.objectIdField)) {
        jsGeoJSONLayer.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsGeoJSONLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsGeoJSONLayer.orderBy = dotNetObject.orderBy;
    }
    if (hasValue(dotNetObject.outFields)) {
        jsGeoJSONLayer.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsGeoJSONLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsGeoJSONLayer.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsGeoJSONLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
        jsGeoJSONLayer.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsGeoJSONLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.templates)) {
        jsGeoJSONLayer.templates = dotNetObject.templates;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsGeoJSONLayer.timeOffset = dotNetObject.timeOffset;
    }
    if (hasValue(dotNetObject.title)) {
        jsGeoJSONLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsGeoJSONLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsGeoJSONLayer.useViewTime = dotNetObject.useViewTime;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGeoJSONLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsElevationLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsElevationLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsElevationLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsElevationLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsElevationLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsElevationLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        jsElevationLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsElevationLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsElevationLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
    }
    let { default: ElevationLayerWrapper } = await import('./elevationLayer');
    let elevationLayerWrapper = new ElevationLayerWrapper(jsElevationLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', elevationLayerWrapper);
    jsObjectRefs[dotNetObject.id] = elevationLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsElevationLayer;
    return jsElevationLayer;
}

export async function buildJsImageryTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
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
    if (hasValue(dotNetObject.id)) {
        jsImageryTileLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.bandIds)) {
        jsImageryTileLayer.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsImageryTileLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsImageryTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition)) {
        jsImageryTileLayer.multidimensionalDefinition = dotNetObject.multidimensionalDefinition;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsImageryTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsImageryTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsImageryTileLayer.renderer = dotNetObject.renderer;
    }
    if (hasValue(dotNetObject.source)) {
        jsImageryTileLayer.source = dotNetObject.source;
    }
    if (hasValue(dotNetObject.title)) {
        jsImageryTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsImageryTileLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsImageryTileLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.outputPixelType)) {
        jsRasterFunction.outputPixelType = dotNetObject.outputPixelType;
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
    if (hasValue(dotNetObject.id)) {
        jsImageryLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.bandIds)) {
        jsImageryLayer.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.capabilities)) {
        jsImageryLayer.capabilities = dotNetObject.capabilities;
    }
    if (hasValue(dotNetObject.compressionQuality)) {
        jsImageryLayer.compressionQuality = dotNetObject.compressionQuality;
    }
    if (hasValue(dotNetObject.fields)) {
        jsImageryLayer.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsImageryLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.interpolation)) {
        jsImageryLayer.interpolation = dotNetObject.interpolation;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsImageryLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.mosaicRule)) {
        jsImageryLayer.mosaicRule = dotNetObject.mosaicRule;
    }
    if (hasValue(dotNetObject.noData)) {
        jsImageryLayer.noData = dotNetObject.noData;
    }
    if (hasValue(dotNetObject.noDataInterpretation)) {
        jsImageryLayer.noDataInterpretation = dotNetObject.noDataInterpretation;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsImageryLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsImageryLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.pixelFilter)) {
        jsImageryLayer.pixelFilter = dotNetObject.pixelFilter;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsImageryLayer.renderer = dotNetObject.renderer;
    }
    if (hasValue(dotNetObject.renderingRule)) {
        jsImageryLayer.renderingRule = dotNetObject.renderingRule;
    }
    if (hasValue(dotNetObject.sourceJSON)) {
        jsImageryLayer.sourceJSON = dotNetObject.sourceJSON;
    }
    if (hasValue(dotNetObject.title)) {
        jsImageryLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsImageryLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsImageryLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsWCSLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.bandIds)) {
        jsWCSLayer.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsWCSLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsWCSLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.coverageId)) {
        jsWCSLayer.coverageId = dotNetObject.coverageId;
    }
    if (hasValue(dotNetObject.coverageInfo)) {
        jsWCSLayer.coverageInfo = dotNetObject.coverageInfo;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsWCSLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.effect)) {
        jsWCSLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsWCSLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.interpolation)) {
        jsWCSLayer.interpolation = dotNetObject.interpolation;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsWCSLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsWCSLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsWCSLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsWCSLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition)) {
        jsWCSLayer.multidimensionalDefinition = dotNetObject.multidimensionalDefinition;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsWCSLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsWCSLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsWCSLayer.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.rasterFields)) {
        jsWCSLayer.rasterFields = dotNetObject.rasterFields;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsWCSLayer.renderer = dotNetObject.renderer;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsWCSLayer.timeOffset = dotNetObject.timeOffset;
    }
    if (hasValue(dotNetObject.title)) {
        jsWCSLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsWCSLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsWCSLayer.useViewTime = dotNetObject.useViewTime;
    }
    if (hasValue(dotNetObject.version)) {
        jsWCSLayer.version = dotNetObject.version;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsWCSLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
    }
    let { default: WCSLayerWrapper } = await import('./wCSLayer');
    let wCSLayerWrapper = new WCSLayerWrapper(jsWCSLayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', wCSLayerWrapper);
    jsObjectRefs[dotNetObject.id] = wCSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWCSLayer;
    return jsWCSLayer;
}

export async function buildJsBingMapsLayer(dotNetObject: any): Promise<any> {
    let { default: BingMapsLayer } = await import('@arcgis/core/layers/BingMapsLayer');
    let jsBingMapsLayer = new BingMapsLayer();
    if (hasValue(dotNetObject.tileInfo)) {
        jsBingMapsLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.id)) {
        jsBingMapsLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsBingMapsLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsBingMapsLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsBingMapsLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.key)) {
        jsBingMapsLayer.key = dotNetObject.key;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsBingMapsLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsBingMapsLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsBingMapsLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsBingMapsLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsBingMapsLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsBingMapsLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsBingMapsLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.title)) {
        jsBingMapsLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsBingMapsLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.id)) {
        jsMapImageLayer.id = dotNetObject.id;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsMapImageLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.dpi)) {
        jsMapImageLayer.dpi = dotNetObject.dpi;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsMapImageLayer.fullExtent = dotNetObject.fullExtent;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsMapImageLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsMapImageLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsMapImageLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.sublayers)) {
        jsMapImageLayer.sublayers = dotNetObject.sublayers;
    }
    if (hasValue(dotNetObject.subtables)) {
        jsMapImageLayer.subtables = dotNetObject.subtables;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsMapImageLayer.timeOffset = dotNetObject.timeOffset;
    }
    if (hasValue(dotNetObject.title)) {
        jsMapImageLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsMapImageLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsMapImageLayer.visibilityTimeExtent = dotNetObject.visibilityTimeExtent;
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
    if (hasValue(dotNetObject.path)) {
        jsPortalItemResource.path = dotNetObject.path;
    }
    let { default: PortalItemResourceWrapper } = await import('./portalItemResource');
    let portalItemResourceWrapper = new PortalItemResourceWrapper(jsPortalItemResource);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', portalItemResourceWrapper);
    jsObjectRefs[dotNetObject.id] = portalItemResourceWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsPortalItemResource;
    return jsPortalItemResource;
}

