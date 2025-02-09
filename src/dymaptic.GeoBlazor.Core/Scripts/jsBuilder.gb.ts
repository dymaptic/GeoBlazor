// region imports
import { hasValue, jsObjectRefs, arcGisObjectRefs } from './arcGisJsInterop';
import {
    buildJsExtent,
    buildJsPortalItem,
    buildJsPoint,
    buildJsFeatureEffect,
    buildJsField,
    buildJsPopupTemplate,
    buildJsRenderer,
    buildJsSymbol,
    buildJsGraphic,
    buildJsFormTemplate,
    buildJsFeatureTemplate,
    buildJsSublayer,
    buildJsDimensionalDefinition,
    buildJsMultidimensionalSubset
} from './jsBuilder';

// region functions
export async function buildJsWebTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: WebTileLayer } = await import('@arcgis/core/layers/WebTileLayer');
    let jsWebTileLayer = new WebTileLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsWebTileLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsWebTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsWebTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsWebTileLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsWebTileLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsWebTileLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsWebTileLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.effect)) {
        jsWebTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsWebTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsWebTileLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsWebTileLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsWebTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsWebTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsWebTileLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.subDomains)) {
        jsWebTileLayer.subDomains = dotNetObject.subDomains;
    }
    if (hasValue(dotNetObject.title)) {
        jsWebTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.urlTemplate)) {
        jsWebTileLayer.urlTemplate = dotNetObject.urlTemplate;
    }
    jsWebTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: WebTileLayerWrapper } = await import('./webTileLayer');
    let webTileLayerWrapper = new WebTileLayerWrapper(jsWebTileLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(webTileLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = webTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWebTileLayer;
    return jsWebTileLayer;
}

export async function buildJsTileInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: TileInfo } = await import('@arcgis/core/layers/support/TileInfo');
    let jsTileInfo = new TileInfo();
    if (hasValue(dotNetObject.lods)) {
        jsTileInfo.lods = dotNetObject.lods.map(async i => await buildJsLOD(i)) as any;
    }
    if (hasValue(dotNetObject.origin)) {
        jsTileInfo.origin = buildJsPoint(dotNetObject.origin) as any;
    }
    if (hasValue(dotNetObject.dpi)) {
        jsTileInfo.dpi = dotNetObject.dpi;
    }
    if (hasValue(dotNetObject.format)) {
        jsTileInfo.format = dotNetObject.format;
    }
    if (hasValue(dotNetObject.isWrappable)) {
        jsTileInfo.isWrappable = dotNetObject.isWrappable;
    }
    if (hasValue(dotNetObject.size)) {
        jsTileInfo.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsTileInfo.spatialReference = dotNetObject.spatialReference;
    }
    let { default: TileInfoWrapper } = await import('./tileInfo');
    let tileInfoWrapper = new TileInfoWrapper(jsTileInfo);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(tileInfoWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = tileInfoWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTileInfo;
    return jsTileInfo;
}

export async function buildJsLOD(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: LOD } = await import('@arcgis/core/layers/support/LOD');
    let jsLOD = new LOD();
    if (hasValue(dotNetObject.level)) {
        jsLOD.level = dotNetObject.level;
    }
    if (hasValue(dotNetObject.levelValue)) {
        jsLOD.levelValue = dotNetObject.levelValue;
    }
    if (hasValue(dotNetObject.resolution)) {
        jsLOD.resolution = dotNetObject.resolution;
    }
    if (hasValue(dotNetObject.scale)) {
        jsLOD.scale = dotNetObject.scale;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLOD);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsLOD;
    arcGisObjectRefs[dotNetObject.id] = jsLOD;
    return jsLOD;
}

export async function buildJsTimeExtent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
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
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(timeExtentWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = timeExtentWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTimeExtent;
    return jsTimeExtent;
}

export async function buildJsPortalFolder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: PortalFolder } = await import('@arcgis/core/portal/PortalFolder');
    let jsPortalFolder = new PortalFolder();
    if (hasValue(dotNetObject.created)) {
        jsPortalFolder.created = dotNetObject.created;
    }
    if (hasValue(dotNetObject.portalFolderId)) {
        jsPortalFolder.id = dotNetObject.portalFolderId;
    }
    if (hasValue(dotNetObject.title)) {
        jsPortalFolder.title = dotNetObject.title;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPortalFolder);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsPortalFolder;
    arcGisObjectRefs[dotNetObject.id] = jsPortalFolder;
    return jsPortalFolder;
}

export async function buildJsCSVLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: CSVLayer } = await import('@arcgis/core/layers/CSVLayer');
    let jsCSVLayer = new CSVLayer();
    if (hasValue(dotNetObject.elevationInfo)) {
        jsCSVLayer.elevationInfo = await buildJsCSVLayerElevationInfo(dotNetObject.elevationInfo) as any;
    }
    if (hasValue(dotNetObject.featureEffect)) {
        jsCSVLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.fields)) {
        jsCSVLayer.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsCSVLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsCSVLayer.labelingInfo = dotNetObject.labelingInfo.map(async i => await buildJsLabel(i)) as any;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsCSVLayer.orderBy = dotNetObject.orderBy.map(async i => await buildJsOrderedLayerOrderBy(i)) as any;
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
    if (hasValue(dotNetObject.timeOffset)) {
        jsCSVLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsCSVLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsCSVLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsCSVLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsCSVLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsCSVLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.definitionExpression)) {
        jsCSVLayer.definitionExpression = dotNetObject.definitionExpression;
    }
    if (hasValue(dotNetObject.delimiter)) {
        jsCSVLayer.delimiter = dotNetObject.delimiter;
    }
    if (hasValue(dotNetObject.displayField)) {
        jsCSVLayer.displayField = dotNetObject.displayField;
    }
    if (hasValue(dotNetObject.effect)) {
        jsCSVLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.featureReduction)) {
        jsCSVLayer.featureReduction = dotNetObject.featureReduction;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsCSVLayer.geometryType = dotNetObject.geometryType;
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
    if (hasValue(dotNetObject.title)) {
        jsCSVLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsCSVLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsCSVLayer.useViewTime = dotNetObject.useViewTime;
    }
    jsCSVLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: CSVLayerWrapper } = await import('./cSVLayer');
    let cSVLayerWrapper = new CSVLayerWrapper(jsCSVLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(cSVLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = cSVLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayer;
    return jsCSVLayer;
}

export async function buildJsCSVLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsCSVLayerElevationInfo = {
    featureExpressionInfo: await buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject.featureExpressionInfo) as any,
        mode: dotNetObject.mode,
        offset: dotNetObject.offset,
        unit: dotNetObject.unit,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCSVLayerElevationInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsCSVLayerElevationInfo;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayerElevationInfo;
    return jsCSVLayerElevationInfo;
}

export async function buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsCSVLayerElevationInfoFeatureExpressionInfo = {
        expression: dotNetObject.expression,
        title: dotNetObject.title,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCSVLayerElevationInfoFeatureExpressionInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsCSVLayerElevationInfoFeatureExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayerElevationInfoFeatureExpressionInfo;
    return jsCSVLayerElevationInfoFeatureExpressionInfo;
}

export async function buildJsLabel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let Label = __esri.LabelClass;
    let jsLabel = new Label();
    if (hasValue(dotNetObject.symbol)) {
        jsLabel.symbol = buildJsSymbol(dotNetObject.symbol) as any;
    }
    if (hasValue(dotNetObject.allowOverrun)) {
        jsLabel.allowOverrun = dotNetObject.allowOverrun;
    }
    if (hasValue(dotNetObject.deconflictionStrategy)) {
        jsLabel.deconflictionStrategy = dotNetObject.deconflictionStrategy;
    }
    if (hasValue(dotNetObject.labelExpression)) {
        jsLabel.labelExpression = dotNetObject.labelExpression;
    }
    if (hasValue(dotNetObject.labelExpressionInfo)) {
        jsLabel.labelExpressionInfo = dotNetObject.labelExpressionInfo;
    }
    if (hasValue(dotNetObject.labelPlacement)) {
        jsLabel.labelPlacement = dotNetObject.labelPlacement;
    }
    if (hasValue(dotNetObject.labelPosition)) {
        jsLabel.labelPosition = dotNetObject.labelPosition;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsLabel.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsLabel.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.repeatLabel)) {
        jsLabel.repeatLabel = dotNetObject.repeatLabel;
    }
    if (hasValue(dotNetObject.repeatLabelDistance)) {
        jsLabel.repeatLabelDistance = dotNetObject.repeatLabelDistance;
    }
    if (hasValue(dotNetObject.useCodedValues)) {
        jsLabel.useCodedValues = dotNetObject.useCodedValues;
    }
    if (hasValue(dotNetObject.where)) {
        jsLabel.where = dotNetObject.where;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLabel);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsLabel;
    arcGisObjectRefs[dotNetObject.id] = jsLabel;
    return jsLabel;
}

export async function buildJsOrderedLayerOrderBy(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsOrderedLayerOrderBy = {
        field: dotNetObject.field,
        order: dotNetObject.order,
        valueExpression: dotNetObject.valueExpression,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsOrderedLayerOrderBy);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsOrderedLayerOrderBy;
    arcGisObjectRefs[dotNetObject.id] = jsOrderedLayerOrderBy;
    return jsOrderedLayerOrderBy;
}

export async function buildJsTimeInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: TimeInfo } = await import('@arcgis/core/layers/support/TimeInfo');
    let jsTimeInfo = new TimeInfo();
    if (hasValue(dotNetObject.fullTimeExtent)) {
        jsTimeInfo.fullTimeExtent = await buildJsTimeExtent(dotNetObject.fullTimeExtent) as any;
    }
    if (hasValue(dotNetObject.interval)) {
        jsTimeInfo.interval = await buildJsTimeInterval(dotNetObject.interval) as any;
    }
    if (hasValue(dotNetObject.endField)) {
        jsTimeInfo.endField = dotNetObject.endField;
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
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTimeInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsTimeInfo;
    arcGisObjectRefs[dotNetObject.id] = jsTimeInfo;
    return jsTimeInfo;
}

export async function buildJsTimeInterval(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: TimeInterval } = await import('@arcgis/core/TimeInterval');
    let jsTimeInterval = new TimeInterval();
    if (hasValue(dotNetObject.unit)) {
        jsTimeInterval.unit = dotNetObject.unit;
    }
    if (hasValue(dotNetObject.value)) {
        jsTimeInterval.value = dotNetObject.value;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTimeInterval);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsTimeInterval;
    arcGisObjectRefs[dotNetObject.id] = jsTimeInterval;
    return jsTimeInterval;
}

export async function buildJsGraphicsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: GraphicsLayer } = await import('@arcgis/core/layers/GraphicsLayer');
    let jsGraphicsLayer = new GraphicsLayer();
    if (hasValue(dotNetObject.elevationInfo)) {
        jsGraphicsLayer.elevationInfo = await buildJsGraphicsLayerElevationInfo(dotNetObject.elevationInfo) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsGraphicsLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.graphics)) {
        jsGraphicsLayer.graphics = dotNetObject.graphics.map(i => buildJsGraphic(i, layerId, viewId)) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGraphicsLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsGraphicsLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsGraphicsLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsGraphicsLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsGraphicsLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsGraphicsLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsGraphicsLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsGraphicsLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsGraphicsLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.screenSizePerspectiveEnabled)) {
        jsGraphicsLayer.screenSizePerspectiveEnabled = dotNetObject.screenSizePerspectiveEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        jsGraphicsLayer.title = dotNetObject.title;
    }
    let { default: GraphicsLayerWrapper } = await import('./graphicsLayer');
    let graphicsLayerWrapper = new GraphicsLayerWrapper(jsGraphicsLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(graphicsLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = graphicsLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGraphicsLayer;
    return jsGraphicsLayer;
}

export async function buildJsGraphicsLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsGraphicsLayerElevationInfo = {
    featureExpressionInfo: await buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject.featureExpressionInfo) as any,
        mode: dotNetObject.mode,
        offset: dotNetObject.offset,
        unit: dotNetObject.unit,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGraphicsLayerElevationInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsGraphicsLayerElevationInfo;
    arcGisObjectRefs[dotNetObject.id] = jsGraphicsLayerElevationInfo;
    return jsGraphicsLayerElevationInfo;
}

export async function buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsGraphicsLayerElevationInfoFeatureExpressionInfo = {
        expression: dotNetObject.expression,
        title: dotNetObject.title,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGraphicsLayerElevationInfoFeatureExpressionInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsGraphicsLayerElevationInfoFeatureExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jsGraphicsLayerElevationInfoFeatureExpressionInfo;
    return jsGraphicsLayerElevationInfoFeatureExpressionInfo;
}

export async function buildJsGeoRSSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: GeoRSSLayer } = await import('@arcgis/core/layers/GeoRSSLayer');
    let jsGeoRSSLayer = new GeoRSSLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsGeoRSSLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.lineSymbol)) {
        jsGeoRSSLayer.lineSymbol = await buildJsSimpleLineSymbol(dotNetObject.lineSymbol) as any;
    }
    if (hasValue(dotNetObject.pointSymbol)) {
        jsGeoRSSLayer.pointSymbol = await buildJsMarkerSymbol(dotNetObject.pointSymbol) as any;
    }
    if (hasValue(dotNetObject.polygonSymbol)) {
        jsGeoRSSLayer.polygonSymbol = await buildJsSimpleFillSymbol(dotNetObject.polygonSymbol) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGeoRSSLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsGeoRSSLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsGeoRSSLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsGeoRSSLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsGeoRSSLayer.legendEnabled = dotNetObject.legendEnabled;
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
    if (hasValue(dotNetObject.refreshInterval)) {
        jsGeoRSSLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.title)) {
        jsGeoRSSLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsGeoRSSLayer.url = dotNetObject.url;
    }
    jsGeoRSSLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: GeoRSSLayerWrapper } = await import('./geoRSSLayer');
    let geoRSSLayerWrapper = new GeoRSSLayerWrapper(jsGeoRSSLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(geoRSSLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = geoRSSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGeoRSSLayer;
    return jsGeoRSSLayer;
}

export async function buildJsSimpleLineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: SimpleLineSymbol } = await import('@arcgis/core/symbols/SimpleLineSymbol');
    let jsSimpleLineSymbol = new SimpleLineSymbol();
    if (hasValue(dotNetObject.marker)) {
        jsSimpleLineSymbol.marker = await buildJsLineSymbolMarker(dotNetObject.marker) as any;
    }
    if (hasValue(dotNetObject.cap)) {
        jsSimpleLineSymbol.cap = dotNetObject.cap;
    }
    if (hasValue(dotNetObject.color)) {
        jsSimpleLineSymbol.color = dotNetObject.color;
    }
    if (hasValue(dotNetObject.join)) {
        jsSimpleLineSymbol.join = dotNetObject.join;
    }
    if (hasValue(dotNetObject.miterLimit)) {
        jsSimpleLineSymbol.miterLimit = dotNetObject.miterLimit;
    }
    if (hasValue(dotNetObject.style)) {
        jsSimpleLineSymbol.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.type)) {
        jsSimpleLineSymbol.type = dotNetObject.type;
    }
    if (hasValue(dotNetObject.width)) {
        jsSimpleLineSymbol.width = dotNetObject.width;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSimpleLineSymbol);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsSimpleLineSymbol;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleLineSymbol;
    return jsSimpleLineSymbol;
}

export async function buildJsLineSymbolMarker(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: LineSymbolMarker } = await import('@arcgis/core/symbols/LineSymbolMarker');
    let jsLineSymbolMarker = new LineSymbolMarker();
    if (hasValue(dotNetObject.color)) {
        jsLineSymbolMarker.color = await buildJsColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.placement)) {
        jsLineSymbolMarker.placement = dotNetObject.placement;
    }
    if (hasValue(dotNetObject.style)) {
        jsLineSymbolMarker.style = dotNetObject.style;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLineSymbolMarker);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsLineSymbolMarker;
    arcGisObjectRefs[dotNetObject.id] = jsLineSymbolMarker;
    return jsLineSymbolMarker;
}

export async function buildJsMarkerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: MarkerSymbol } = await import('@arcgis/core/symbols/MarkerSymbol');
    let jsMarkerSymbol = new MarkerSymbol();
    if (hasValue(dotNetObject.color)) {
        jsMarkerSymbol.color = await buildJsColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.angle)) {
        jsMarkerSymbol.angle = dotNetObject.angle;
    }
    if (hasValue(dotNetObject.type)) {
        jsMarkerSymbol.type = dotNetObject.type;
    }
    if (hasValue(dotNetObject.xoffset)) {
        jsMarkerSymbol.xoffset = dotNetObject.xoffset;
    }
    if (hasValue(dotNetObject.yoffset)) {
        jsMarkerSymbol.yoffset = dotNetObject.yoffset;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMarkerSymbol);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsMarkerSymbol;
    arcGisObjectRefs[dotNetObject.id] = jsMarkerSymbol;
    return jsMarkerSymbol;
}

export async function buildJsSimpleFillSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: SimpleFillSymbol } = await import('@arcgis/core/symbols/SimpleFillSymbol');
    let jsSimpleFillSymbol = new SimpleFillSymbol();
    if (hasValue(dotNetObject.color)) {
        jsSimpleFillSymbol.color = dotNetObject.color;
    }
    if (hasValue(dotNetObject.outline)) {
        jsSimpleFillSymbol.outline = dotNetObject.outline;
    }
    if (hasValue(dotNetObject.style)) {
        jsSimpleFillSymbol.style = dotNetObject.style;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSimpleFillSymbol);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsSimpleFillSymbol;
    arcGisObjectRefs[dotNetObject.id] = jsSimpleFillSymbol;
    return jsSimpleFillSymbol;
}

export async function buildJsBaseTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: BaseTileLayer } = await import('@arcgis/core/layers/BaseTileLayer');
    let jsBaseTileLayer = new BaseTileLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsBaseTileLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsBaseTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsBaseTileLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsBaseTileLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsBaseTileLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsBaseTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsBaseTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsBaseTileLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsBaseTileLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsBaseTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsBaseTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsBaseTileLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsBaseTileLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.title)) {
        jsBaseTileLayer.title = dotNetObject.title;
    }
    jsBaseTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: BaseTileLayerWrapper } = await import('./baseTileLayer');
    let baseTileLayerWrapper = new BaseTileLayerWrapper(jsBaseTileLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(baseTileLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = baseTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBaseTileLayer;
    return jsBaseTileLayer;
}

export async function buildJsFeatureLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: FeatureLayer } = await import('@arcgis/core/layers/FeatureLayer');
    let jsFeatureLayer = new FeatureLayer();
    if (hasValue(dotNetObject.elevationInfo)) {
        jsFeatureLayer.elevationInfo = await buildJsFeatureLayerBaseElevationInfo(dotNetObject.elevationInfo) as any;
    }
    if (hasValue(dotNetObject.featureEffect)) {
        jsFeatureLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.fields)) {
        jsFeatureLayer.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.floorInfo)) {
        jsFeatureLayer.floorInfo = await buildJsLayerFloorInfo(dotNetObject.floorInfo) as any;
    }
    if (hasValue(dotNetObject.formTemplate)) {
        jsFeatureLayer.formTemplate = buildJsFormTemplate(dotNetObject.formTemplate) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsFeatureLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsFeatureLayer.labelingInfo = dotNetObject.labelingInfo.map(async i => await buildJsLabel(i)) as any;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsFeatureLayer.orderBy = dotNetObject.orderBy.map(async i => await buildJsOrderedLayerOrderBy(i)) as any;
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
    if (hasValue(dotNetObject.source)) {
        jsFeatureLayer.source = dotNetObject.source.map(i => buildJsGraphic(i, layerId, viewId)) as any;
    }
    if (hasValue(dotNetObject.templates)) {
        jsFeatureLayer.templates = dotNetObject.templates.map(i => buildJsFeatureTemplate(i, viewId)) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsFeatureLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsFeatureLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsFeatureLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsFeatureLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.apiKey)) {
        jsFeatureLayer.apiKey = dotNetObject.apiKey;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsFeatureLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsFeatureLayer.blendMode = dotNetObject.blendMode;
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
    if (hasValue(dotNetObject.definitionExpression)) {
        jsFeatureLayer.definitionExpression = dotNetObject.definitionExpression;
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
    if (hasValue(dotNetObject.effect)) {
        jsFeatureLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.featureReduction)) {
        jsFeatureLayer.featureReduction = dotNetObject.featureReduction;
    }
    if (hasValue(dotNetObject.gdbVersion)) {
        jsFeatureLayer.gdbVersion = dotNetObject.gdbVersion;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsFeatureLayer.geometryType = dotNetObject.geometryType;
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
    if (hasValue(dotNetObject.labelsVisible)) {
        jsFeatureLayer.labelsVisible = dotNetObject.labelsVisible;
    }
    if (hasValue(dotNetObject.layerIndex)) {
        jsFeatureLayer.layerId = dotNetObject.layerIndex;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsFeatureLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsFeatureLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsFeatureLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsFeatureLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.objectIdField)) {
        jsFeatureLayer.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsFeatureLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.outFields)) {
        jsFeatureLayer.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsFeatureLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsFeatureLayer.popupEnabled = dotNetObject.popupEnabled;
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
    if (hasValue(dotNetObject.sourceJSON)) {
        jsFeatureLayer.sourceJSON = dotNetObject.sourceJSON;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsFeatureLayer.spatialReference = dotNetObject.spatialReference;
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
    jsFeatureLayer.on('edits', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsEdits', evt);
    });
    
    jsFeatureLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: FeatureLayerWrapper } = await import('./featureLayer');
    let featureLayerWrapper = new FeatureLayerWrapper(jsFeatureLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(featureLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = featureLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayer;
    return jsFeatureLayer;
}

export async function buildJsFeatureLayerBaseElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsFeatureLayerBaseElevationInfo = {
    featureExpressionInfo: await buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfo(dotNetObject.featureExpressionInfo) as any,
        mode: dotNetObject.mode,
        offset: dotNetObject.offset,
        unit: dotNetObject.unit,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureLayerBaseElevationInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfo;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfo;
    return jsFeatureLayerBaseElevationInfo;
}

export async function buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsFeatureLayerBaseElevationInfoFeatureExpressionInfo = {
        expression: dotNetObject.expression,
        title: dotNetObject.title,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureLayerBaseElevationInfoFeatureExpressionInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
    return jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
}

export async function buildJsLayerFloorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: LayerFloorInfo } = await import('@arcgis/core/layers/support/LayerFloorInfo');
    let jsLayerFloorInfo = new LayerFloorInfo();
    if (hasValue(dotNetObject.floorField)) {
        jsLayerFloorInfo.floorField = dotNetObject.floorField;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLayerFloorInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsLayerFloorInfo;
    arcGisObjectRefs[dotNetObject.id] = jsLayerFloorInfo;
    return jsLayerFloorInfo;
}

export async function buildJsKMLLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: KMLLayer } = await import('@arcgis/core/layers/KMLLayer');
    let jsKMLLayer = new KMLLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsKMLLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsKMLLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.sublayers)) {
        jsKMLLayer.sublayers = dotNetObject.sublayers.map(async i => await buildJsKMLSublayer(i)) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsKMLLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsKMLLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsKMLLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.effect)) {
        jsKMLLayer.effect = dotNetObject.effect;
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
    if (hasValue(dotNetObject.title)) {
        jsKMLLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsKMLLayer.url = dotNetObject.url;
    }
    let { default: KMLLayerWrapper } = await import('./kMLLayer');
    let kMLLayerWrapper = new KMLLayerWrapper(jsKMLLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(kMLLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = kMLLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsKMLLayer;
    return jsKMLLayer;
}

export async function buildJsKMLSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: KMLSublayer } = await import('@arcgis/core/layers/support/KMLSublayer');
    let jsKMLSublayer = new KMLSublayer();
    if (hasValue(dotNetObject.description)) {
        jsKMLSublayer.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.kMLSublayerId)) {
        jsKMLSublayer.id = dotNetObject.kMLSublayerId;
    }
    if (hasValue(dotNetObject.networkLink)) {
        jsKMLSublayer.networkLink = dotNetObject.networkLink;
    }
    if (hasValue(dotNetObject.title)) {
        jsKMLSublayer.title = dotNetObject.title;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsKMLSublayer);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsKMLSublayer;
    arcGisObjectRefs[dotNetObject.id] = jsKMLSublayer;
    return jsKMLSublayer;
}

export async function buildJsVectorTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: VectorTileLayer } = await import('@arcgis/core/layers/VectorTileLayer');
    let jsVectorTileLayer = new VectorTileLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsVectorTileLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.initialExtent)) {
        jsVectorTileLayer.initialExtent = buildJsExtent(dotNetObject.initialExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsVectorTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsVectorTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsVectorTileLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.apiKey)) {
        jsVectorTileLayer.apiKey = dotNetObject.apiKey;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsVectorTileLayer.id = dotNetObject.arcGISLayerId;
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
    if (hasValue(dotNetObject.listMode)) {
        jsVectorTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsVectorTileLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsVectorTileLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsVectorTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsVectorTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsVectorTileLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.style)) {
        jsVectorTileLayer.style = dotNetObject.style;
    }
    if (hasValue(dotNetObject.title)) {
        jsVectorTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsVectorTileLayer.url = dotNetObject.url;
    }
    let { default: VectorTileLayerWrapper } = await import('./vectorTileLayer');
    let vectorTileLayerWrapper = new VectorTileLayerWrapper(jsVectorTileLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(vectorTileLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = vectorTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsVectorTileLayer;
    return jsVectorTileLayer;
}

export async function buildJsTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: TileLayer } = await import('@arcgis/core/layers/TileLayer');
    let jsTileLayer = new TileLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsTileLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.subtables)) {
        jsTileLayer.subtables = dotNetObject.subtables.map(i => buildJsSublayer(i)) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsTileLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.apiKey)) {
        jsTileLayer.apiKey = dotNetObject.apiKey;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsTileLayer.id = dotNetObject.arcGISLayerId;
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
    if (hasValue(dotNetObject.effect)) {
        jsTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsTileLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsTileLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsTileLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsTileLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.resampling)) {
        jsTileLayer.resampling = dotNetObject.resampling;
    }
    if (hasValue(dotNetObject.tileServers)) {
        jsTileLayer.tileServers = dotNetObject.tileServers;
    }
    if (hasValue(dotNetObject.title)) {
        jsTileLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsTileLayer.url = dotNetObject.url;
    }
    jsTileLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: TileLayerWrapper } = await import('./tileLayer');
    let tileLayerWrapper = new TileLayerWrapper(jsTileLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(tileLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = tileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsTileLayer;
    return jsTileLayer;
}

export async function buildJsGeoJSONLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: GeoJSONLayer } = await import('@arcgis/core/layers/GeoJSONLayer');
    let jsGeoJSONLayer = new GeoJSONLayer();
    if (hasValue(dotNetObject.elevationInfo)) {
        jsGeoJSONLayer.elevationInfo = await buildJsGeoJSONLayerElevationInfo(dotNetObject.elevationInfo) as any;
    }
    if (hasValue(dotNetObject.featureEffect)) {
        jsGeoJSONLayer.featureEffect = buildJsFeatureEffect(dotNetObject.featureEffect) as any;
    }
    if (hasValue(dotNetObject.fields)) {
        jsGeoJSONLayer.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsGeoJSONLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.labelingInfo)) {
        jsGeoJSONLayer.labelingInfo = dotNetObject.labelingInfo.map(async i => await buildJsLabel(i)) as any;
    }
    if (hasValue(dotNetObject.orderBy)) {
        jsGeoJSONLayer.orderBy = dotNetObject.orderBy.map(async i => await buildJsOrderedLayerOrderBy(i)) as any;
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
    if (hasValue(dotNetObject.templates)) {
        jsGeoJSONLayer.templates = dotNetObject.templates.map(i => buildJsFeatureTemplate(i, viewId)) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsGeoJSONLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsGeoJSONLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsGeoJSONLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsGeoJSONLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsGeoJSONLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsGeoJSONLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsGeoJSONLayer.copyright = dotNetObject.copyright;
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
    if (hasValue(dotNetObject.featureReduction)) {
        jsGeoJSONLayer.featureReduction = dotNetObject.featureReduction;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsGeoJSONLayer.geometryType = dotNetObject.geometryType;
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
    if (hasValue(dotNetObject.title)) {
        jsGeoJSONLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsGeoJSONLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsGeoJSONLayer.useViewTime = dotNetObject.useViewTime;
    }
    jsGeoJSONLayer.on('edits', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsEdits', evt);
    });
    
    jsGeoJSONLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: GeoJSONLayerWrapper } = await import('./geoJSONLayer');
    let geoJSONLayerWrapper = new GeoJSONLayerWrapper(jsGeoJSONLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(geoJSONLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = geoJSONLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsGeoJSONLayer;
    return jsGeoJSONLayer;
}

export async function buildJsGeoJSONLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsGeoJSONLayerElevationInfo = {
    featureExpressionInfo: await buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject.featureExpressionInfo) as any,
        mode: dotNetObject.mode,
        offset: dotNetObject.offset,
        unit: dotNetObject.unit,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGeoJSONLayerElevationInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsGeoJSONLayerElevationInfo;
    arcGisObjectRefs[dotNetObject.id] = jsGeoJSONLayerElevationInfo;
    return jsGeoJSONLayerElevationInfo;
}

export async function buildJsGeoJSONLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsGeoJSONLayerElevationInfoFeatureExpressionInfo = {
        expression: dotNetObject.expression,
        title: dotNetObject.title,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGeoJSONLayerElevationInfoFeatureExpressionInfo);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsGeoJSONLayerElevationInfoFeatureExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jsGeoJSONLayerElevationInfoFeatureExpressionInfo;
    return jsGeoJSONLayerElevationInfoFeatureExpressionInfo;
}

export async function buildJsElevationLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: ElevationLayer } = await import('@arcgis/core/layers/ElevationLayer');
    let jsElevationLayer = new ElevationLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsElevationLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsElevationLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsElevationLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsElevationLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsElevationLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsElevationLayer.copyright = dotNetObject.copyright;
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
    let { default: ElevationLayerWrapper } = await import('./elevationLayer');
    let elevationLayerWrapper = new ElevationLayerWrapper(jsElevationLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(elevationLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = elevationLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsElevationLayer;
    return jsElevationLayer;
}

export async function buildJsImageryTileLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: ImageryTileLayer } = await import('@arcgis/core/layers/ImageryTileLayer');
    let jsImageryTileLayer = new ImageryTileLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsImageryTileLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition)) {
        jsImageryTileLayer.multidimensionalDefinition = dotNetObject.multidimensionalDefinition.map(i => buildJsDimensionalDefinition(i)) as any;
    }
    if (hasValue(dotNetObject.multidimensionalSubset)) {
        jsImageryTileLayer.multidimensionalSubset = buildJsMultidimensionalSubset(dotNetObject.multidimensionalSubset) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        jsImageryTileLayer.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsImageryTileLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.rasterFunction)) {
        jsImageryTileLayer.rasterFunction = await buildJsRasterFunction(dotNetObject.rasterFunction) as any;
    }
    if (hasValue(dotNetObject.tileInfo)) {
        jsImageryTileLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsImageryTileLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsImageryTileLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsImageryTileLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsImageryTileLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsImageryTileLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.bandIds)) {
        jsImageryTileLayer.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsImageryTileLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsImageryTileLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsImageryTileLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.effect)) {
        jsImageryTileLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.interpolation)) {
        jsImageryTileLayer.interpolation = dotNetObject.interpolation;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsImageryTileLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsImageryTileLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsImageryTileLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsImageryTileLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsImageryTileLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsImageryTileLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsImageryTileLayer.popupEnabled = dotNetObject.popupEnabled;
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
    if (hasValue(dotNetObject.useViewTime)) {
        jsImageryTileLayer.useViewTime = dotNetObject.useViewTime;
    }
    let { default: ImageryTileLayerWrapper } = await import('./imageryTileLayer');
    let imageryTileLayerWrapper = new ImageryTileLayerWrapper(jsImageryTileLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(imageryTileLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = imageryTileLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsImageryTileLayer;
    return jsImageryTileLayer;
}

export async function buildJsRasterFunction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
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
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsRasterFunction);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsRasterFunction;
    arcGisObjectRefs[dotNetObject.id] = jsRasterFunction;
    return jsRasterFunction;
}

export async function buildJsImageryLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: ImageryLayer } = await import('@arcgis/core/layers/ImageryLayer');
    let jsImageryLayer = new ImageryLayer();
    if (hasValue(dotNetObject.capabilities)) {
        jsImageryLayer.capabilities = await buildJsArcGISImageServiceCapabilities(dotNetObject.capabilities) as any;
    }
    if (hasValue(dotNetObject.fields)) {
        jsImageryLayer.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        jsImageryLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.multidimensionalSubset)) {
        jsImageryLayer.multidimensionalSubset = buildJsMultidimensionalSubset(dotNetObject.multidimensionalSubset) as any;
    }
    if (hasValue(dotNetObject.hasPixelFilter) && dotNetObject.hasPixelFilter) {
        jsImageryLayer.pixelFilter = (pixelData) => {
            dotNetObject.invokeMethodAsync('OnJsPixelFilter', pixelData);
        };
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
    if (hasValue(dotNetObject.renderingRule)) {
        jsImageryLayer.renderingRule = await buildJsRasterFunction(dotNetObject.renderingRule) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsImageryLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsImageryLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsImageryLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsImageryLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsImageryLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.bandIds)) {
        jsImageryLayer.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsImageryLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.compressionQuality)) {
        jsImageryLayer.compressionQuality = dotNetObject.compressionQuality;
    }
    if (hasValue(dotNetObject.compressionTolerance)) {
        jsImageryLayer.compressionTolerance = dotNetObject.compressionTolerance;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsImageryLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsImageryLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.definitionExpression)) {
        jsImageryLayer.definitionExpression = dotNetObject.definitionExpression;
    }
    if (hasValue(dotNetObject.effect)) {
        jsImageryLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.format)) {
        jsImageryLayer.format = dotNetObject.format;
    }
    if (hasValue(dotNetObject.hasMultidimensions)) {
        jsImageryLayer.hasMultidimensions = dotNetObject.hasMultidimensions;
    }
    if (hasValue(dotNetObject.imageMaxHeight)) {
        jsImageryLayer.imageMaxHeight = dotNetObject.imageMaxHeight;
    }
    if (hasValue(dotNetObject.imageMaxWidth)) {
        jsImageryLayer.imageMaxWidth = dotNetObject.imageMaxWidth;
    }
    if (hasValue(dotNetObject.interpolation)) {
        jsImageryLayer.interpolation = dotNetObject.interpolation;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsImageryLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsImageryLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsImageryLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsImageryLayer.minScale = dotNetObject.minScale;
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
    if (hasValue(dotNetObject.objectIdField)) {
        jsImageryLayer.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsImageryLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsImageryLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.pixelType)) {
        jsImageryLayer.pixelType = dotNetObject.pixelType;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsImageryLayer.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsImageryLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsImageryLayer.renderer = dotNetObject.renderer;
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
    if (hasValue(dotNetObject.useViewTime)) {
        jsImageryLayer.useViewTime = dotNetObject.useViewTime;
    }
    jsImageryLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: ImageryLayerWrapper } = await import('./imageryLayer');
    let imageryLayerWrapper = new ImageryLayerWrapper(jsImageryLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(imageryLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = imageryLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsImageryLayer;
    return jsImageryLayer;
}

export async function buildJsArcGISImageServiceCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsArcGISImageServiceCapabilities = {
    mensuration: await buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject.mensuration) as any,
    operations: await buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject.operations) as any,
        query: dotNetObject.query,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsArcGISImageServiceCapabilities);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilities;
    arcGisObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilities;
    return jsArcGISImageServiceCapabilities;
}

export async function buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsArcGISImageServiceCapabilitiesMensuration = {
        supports3D: dotNetObject.supports3D,
        supportsAreaAndPerimeter: dotNetObject.supportsAreaAndPerimeter,
        supportsDistanceAndAngle: dotNetObject.supportsDistanceAndAngle,
        supportsHeightFromBaseAndTop: dotNetObject.supportsHeightFromBaseAndTop,
        supportsHeightFromBaseAndTopShadow: dotNetObject.supportsHeightFromBaseAndTopShadow,
        supportsHeightFromTopAndTopShadow: dotNetObject.supportsHeightFromTopAndTopShadow,
        supportsPointOrCentroid: dotNetObject.supportsPointOrCentroid,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsArcGISImageServiceCapabilitiesMensuration);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilitiesMensuration;
    arcGisObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilitiesMensuration;
    return jsArcGISImageServiceCapabilitiesMensuration;
}

export async function buildJsArcGISImageServiceCapabilitiesOperations(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsArcGISImageServiceCapabilitiesOperations = {
        supportsCalculateVolume: dotNetObject.supportsCalculateVolume,
        supportsComputeHistograms: dotNetObject.supportsComputeHistograms,
        supportsComputePixelLocation: dotNetObject.supportsComputePixelLocation,
        supportsComputeStatisticsHistograms: dotNetObject.supportsComputeStatisticsHistograms,
        supportsDownload: dotNetObject.supportsDownload,
        supportsExportImage: dotNetObject.supportsExportImage,
        supportsFindImages: dotNetObject.supportsFindImages,
        supportsGetImageUrl: dotNetObject.supportsGetImageUrl,
        supportsGetSamples: dotNetObject.supportsGetSamples,
        supportsIdentify: dotNetObject.supportsIdentify,
        supportsImageToMap: dotNetObject.supportsImageToMap,
        supportsImageToMapMultiray: dotNetObject.supportsImageToMapMultiray,
        supportsMapToImage: dotNetObject.supportsMapToImage,
        supportsMeasure: dotNetObject.supportsMeasure,
        supportsProject: dotNetObject.supportsProject,
        supportsQuery: dotNetObject.supportsQuery,
        supportsQueryBoundary: dotNetObject.supportsQueryBoundary,
        supportsQueryGPSInfo: dotNetObject.supportsQueryGPSInfo,
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsArcGISImageServiceCapabilitiesOperations);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilitiesOperations;
    arcGisObjectRefs[dotNetObject.id] = jsArcGISImageServiceCapabilitiesOperations;
    return jsArcGISImageServiceCapabilitiesOperations;
}

export async function buildJsPixelFilterFunction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsPixelFilterFunction = {
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPixelFilterFunction);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = jsPixelFilterFunction;
    arcGisObjectRefs[dotNetObject.id] = jsPixelFilterFunction;
    return jsPixelFilterFunction;
}

export async function buildJsWCSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: WCSLayer } = await import('@arcgis/core/layers/WCSLayer');
    let jsWCSLayer = new WCSLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsWCSLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition)) {
        jsWCSLayer.multidimensionalDefinition = dotNetObject.multidimensionalDefinition.map(i => buildJsDimensionalDefinition(i)) as any;
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
    if (hasValue(dotNetObject.rasterFields)) {
        jsWCSLayer.rasterFields = dotNetObject.rasterFields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsWCSLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsWCSLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsWCSLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsWCSLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsWCSLayer.id = dotNetObject.arcGISLayerId;
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
    if (hasValue(dotNetObject.opacity)) {
        jsWCSLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsWCSLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        jsWCSLayer.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.renderer)) {
        jsWCSLayer.renderer = dotNetObject.renderer;
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
    let { default: WCSLayerWrapper } = await import('./wCSLayer');
    let wCSLayerWrapper = new WCSLayerWrapper(jsWCSLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(wCSLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = wCSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWCSLayer;
    return jsWCSLayer;
}

export async function buildJsBingMapsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: BingMapsLayer } = await import('@arcgis/core/layers/BingMapsLayer');
    let jsBingMapsLayer = new BingMapsLayer();
    if (hasValue(dotNetObject.tileInfo)) {
        jsBingMapsLayer.tileInfo = await buildJsTileInfo(dotNetObject.tileInfo) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsBingMapsLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsBingMapsLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.culture)) {
        jsBingMapsLayer.culture = dotNetObject.culture;
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
    if (hasValue(dotNetObject.region)) {
        jsBingMapsLayer.region = dotNetObject.region;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        jsBingMapsLayer.spatialReference = dotNetObject.spatialReference;
    }
    if (hasValue(dotNetObject.style)) {
        jsBingMapsLayer.style = dotNetObject.style;
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
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(bingMapsLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = bingMapsLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBingMapsLayer;
    return jsBingMapsLayer;
}

export async function buildJsMapImageLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { default: MapImageLayer } = await import('@arcgis/core/layers/MapImageLayer');
    let jsMapImageLayer = new MapImageLayer();
    if (hasValue(dotNetObject.fullExtent)) {
        jsMapImageLayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        jsMapImageLayer.portalItem = buildJsPortalItem(dotNetObject.portalItem) as any;
    }
    if (hasValue(dotNetObject.sublayers)) {
        jsMapImageLayer.sublayers = dotNetObject.sublayers.map(i => buildJsSublayer(i)) as any;
    }
    if (hasValue(dotNetObject.subtables)) {
        jsMapImageLayer.subtables = dotNetObject.subtables.map(i => buildJsSublayer(i)) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        jsMapImageLayer.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        jsMapImageLayer.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        jsMapImageLayer.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        jsMapImageLayer.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }
    if (hasValue(dotNetObject.arcGISLayerId)) {
        jsMapImageLayer.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.blendMode)) {
        jsMapImageLayer.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        jsMapImageLayer.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.customParameters)) {
        jsMapImageLayer.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.dpi)) {
        jsMapImageLayer.dpi = dotNetObject.dpi;
    }
    if (hasValue(dotNetObject.effect)) {
        jsMapImageLayer.effect = dotNetObject.effect;
    }
    if (hasValue(dotNetObject.gdbVersion)) {
        jsMapImageLayer.gdbVersion = dotNetObject.gdbVersion;
    }
    if (hasValue(dotNetObject.imageFormat)) {
        jsMapImageLayer.imageFormat = dotNetObject.imageFormat;
    }
    if (hasValue(dotNetObject.imageMaxHeight)) {
        jsMapImageLayer.imageMaxHeight = dotNetObject.imageMaxHeight;
    }
    if (hasValue(dotNetObject.imageMaxWidth)) {
        jsMapImageLayer.imageMaxWidth = dotNetObject.imageMaxWidth;
    }
    if (hasValue(dotNetObject.imageTransparency)) {
        jsMapImageLayer.imageTransparency = dotNetObject.imageTransparency;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        jsMapImageLayer.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        jsMapImageLayer.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsMapImageLayer.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsMapImageLayer.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsMapImageLayer.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        jsMapImageLayer.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsMapImageLayer.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.title)) {
        jsMapImageLayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        jsMapImageLayer.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        jsMapImageLayer.useViewTime = dotNetObject.useViewTime;
    }
    jsMapImageLayer.on('refresh', async (evt: any) => {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsRefresh', evt);
    });
    
    let { default: MapImageLayerWrapper } = await import('./mapImageLayer');
    let mapImageLayerWrapper = new MapImageLayerWrapper(jsMapImageLayer);
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(mapImageLayerWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = mapImageLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsMapImageLayer;
    return jsMapImageLayer;
}

