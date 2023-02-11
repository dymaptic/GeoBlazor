import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import Graphic from "@arcgis/core/Graphic";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Point from "@arcgis/core/geometry/Point";
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import Renderer from "@arcgis/core/renderers/Renderer";
import Field from "@arcgis/core/layers/support/Field";
import Font from "@arcgis/core/symbols/Font";
import {
    DotNetAttachmentsPopupContent,
    DotNetBarChartMediaInfo,
    DotNetChartMediaInfoValue,
    DotNetColumnChartMediaInfo,
    DotNetElementExpressionInfo,
    DotNetExpressionInfo,
    DotNetExpressionPopupContent,
    DotNetExtent,
    DotNetFieldInfo,
    DotNetFieldInfoFormat,
    DotNetFieldsPopupContent,
    DotNetGeometry,
    DotNetImageMediaInfo,
    DotNetImageMediaInfoValue,
    DotNetLineChartMediaInfo,
    DotNetMediaInfo,
    DotNetMediaPopupContent,
    DotNetPictureMarkerSymbol,
    DotNetPieChartMediaInfo,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupContent,
    DotNetPopupTemplate,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetSimpleFillSymbol,
    DotNetSimpleLineSymbol,
    DotNetSimpleMarkerSymbol,
    DotNetSpatialReference,
    DotNetSymbol,
    DotNetTextPopupContent, DotNetTextSymbol,
    DotNetTopFeaturesQuery
} from "./definitions";
import ViewClickEvent = __esri.ViewClickEvent;
import PictureMarkerSymbol from "@arcgis/core/symbols/PictureMarkerSymbol";
import Popup from "@arcgis/core/widgets/Popup";
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;
import Query from "@arcgis/core/rest/support/Query";
import ContentProperties = __esri.ContentProperties;
import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import TextContent from "@arcgis/core/popup/content/TextContent";
import FieldInfo from "@arcgis/core/popup/FieldInfo";
import FieldInfoFormat from "@arcgis/core/popup/support/FieldInfoFormat";
import MediaContent from "@arcgis/core/popup/content/MediaContent";
import BarChartMediaInfo from "@arcgis/core/popup/content/BarChartMediaInfo";
import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import ChartMediaInfoValue from "@arcgis/core/popup/content/support/ChartMediaInfoValue";
import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import ImageMediaInfo from "@arcgis/core/popup/content/ImageMediaInfo";
import LineChartMediaInfo from "@arcgis/core/popup/content/LineChartMediaInfo";
import PieChartMediaInfo from "@arcgis/core/popup/content/PieChartMediaInfo";
import AttachmentsContent from "@arcgis/core/popup/content/AttachmentsContent";
import ExpressionContent from "@arcgis/core/popup/content/ExpressionContent";
import ElementExpressionInfoProperties = __esri.ElementExpressionInfoProperties;
import Layer from "@arcgis/core/layers/Layer";
import RelationshipQuery from "@arcgis/core/rest/support/RelationshipQuery";
import TopFeaturesQuery from "@arcgis/core/rest/support/TopFeaturesQuery";
import popupExpressionInfo from "@arcgis/core/popup/ExpressionInfo";
import GraphicWrapper from "./graphic";
import SimpleMarkerSymbol from "@arcgis/core/symbols/SimpleMarkerSymbol";
import Symbol from "@arcgis/core/symbols/Symbol";
import SimpleFillSymbol from "@arcgis/core/symbols/SimpleFillSymbol";
import SimpleLineSymbol from "@arcgis/core/symbols/SimpleLineSymbol";
import ElementExpressionInfo from "@arcgis/core/popup/ElementExpressionInfo";
import ChartMediaInfoValueSeries from "@arcgis/core/popup/content/support/ChartMediaInfoValueSeries";

export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    if (dotNetSpatialReference === undefined || dotNetSpatialReference === null) {
        return new SpatialReference({wkid: 4326});
    }
    let jsSpatialRef = new SpatialReference();
    if (dotNetSpatialReference.wkid !== null) {
        jsSpatialRef.wkid = dotNetSpatialReference.wkid;
    } else if (dotNetSpatialReference.wkt !== null) {
        jsSpatialRef.wkt = dotNetSpatialReference.wkt;
    } else {
        jsSpatialRef.wkid = 4326;
    }

    return jsSpatialRef;
}

export function buildJsExtent(dotNetExtent: DotNetExtent, currentSpatialReference: SpatialReference | null): Extent {
    let extent = new Extent();
    if (dotNetExtent.xmax !== undefined && dotNetExtent.xmax !== null) {
        extent.xmax = dotNetExtent.xmax;
    }
    if (dotNetExtent.xmin !== undefined && dotNetExtent.xmin !== null) {
        extent.xmin = dotNetExtent.xmin;
    }
    if (dotNetExtent.ymax !== undefined && dotNetExtent.ymax !== null) {
        extent.ymax = dotNetExtent.ymax;
    }
    if (dotNetExtent.ymin !== undefined && dotNetExtent.ymin !== null) {
        extent.ymin = dotNetExtent.ymin;
    }
    if (dotNetExtent.zmax !== undefined && dotNetExtent.zmax !== null) {
        extent.zmax = dotNetExtent.zmax;
    }
    if (dotNetExtent.zmin !== undefined && dotNetExtent.zmin !== null) {
        extent.zmin = dotNetExtent.zmin;
    }
    if (dotNetExtent.mmax !== undefined && dotNetExtent.mmax !== null) {
        extent.mmax = dotNetExtent.mmax;
    }
    if (dotNetExtent.mmin !== undefined && dotNetExtent.mmin !== null) {
        extent.mmin = dotNetExtent.mmin;
    }
    if (dotNetExtent.spatialReference !== undefined && dotNetExtent.spatialReference !== null) {
        extent.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        extent.spatialReference = currentSpatialReference;
    }
    
    return extent;
}

export async function buildJsGraphic(graphicObject: any, register: boolean): Promise<Graphic | null> {
    const graphic = new Graphic({
        geometry: buildJsGeometry(graphicObject.geometry) as Geometry ?? null,
        attributes: graphicObject.attributes ?? null,
        symbol: buildJsSymbol(graphicObject.symbol) as Symbol ?? null,
    });

    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate);
    }
    
    if (graphicObject.layerId !== undefined && graphicObject.layerId !== null) {
        let layer = arcGisObjectRefs[graphicObject.layerId] as Layer;
        graphic.layer = layer;
    }

    if (graphicObject.dotNetGraphicReference !== undefined ) {
        let wrapper = new GraphicWrapper(graphic);
        // @ts-ignore
        let objectRef = DotNet.createJSObjectReference(wrapper);
        await graphicObject.dotNetGraphicReference.invokeMethodAsync("OnGraphicCreated", objectRef);
    }
    if (register) {
        arcGisObjectRefs[graphicObject.id] = graphic;
    }
    return graphic;
}

export function buildJsPopupTemplate(popupTemplateObject: DotNetPopupTemplate): PopupTemplate {
    let content;
    if (popupTemplateObject.stringContent !== undefined && popupTemplateObject.stringContent !== null) {
        content = popupTemplateObject.stringContent;
    } else {
        content = popupTemplateObject.content?.map(c => buildJsPopupContent(c));
    }
    let template = new PopupTemplate({
        title: popupTemplateObject.title ?? undefined,
        content: content ?? undefined,
        outFields: popupTemplateObject.outFields ?? undefined,
        overwriteActions: popupTemplateObject.overwriteActions ?? false,
        returnGeometry: popupTemplateObject.returnGeometry ?? false
    });
    
    if (popupTemplateObject.fieldInfos !== undefined && popupTemplateObject.fieldInfos !== null) {
        template.fieldInfos = popupTemplateObject.fieldInfos.map(f => buildJsFieldInfo(f));
    }
    
    if (popupTemplateObject.expressionInfos !== undefined && popupTemplateObject.expressionInfos !== null) {
        template.expressionInfos = popupTemplateObject.expressionInfos.map(e => buildJsExpressionInfo(e));
    }
    
    return template;
}

export function buildJsPopupContent(popupContentObject: DotNetPopupContent): ContentProperties | null {
    switch (popupContentObject?.type) {
        case "fields":
            let dnFieldsContent = popupContentObject as DotNetFieldsPopupContent;
            let fieldsContent = new FieldsContent({
                description: dnFieldsContent.description ?? '',
                title: dnFieldsContent.title ?? ''
            });
            if (dnFieldsContent.fieldInfos !== undefined && dnFieldsContent.fieldInfos !== null &&
                dnFieldsContent.fieldInfos.length > 0) {
                fieldsContent.fieldInfos = dnFieldsContent.fieldInfos.map(f => buildJsFieldInfo(f));
            }
            
            return fieldsContent;
        case "text":
            let dnTextContent = popupContentObject as DotNetTextPopupContent;
            let textContent = new TextContent({
                text: dnTextContent.text ?? null
            });
            
            return textContent;
        case "media":
            let dnMediaContent = popupContentObject as DotNetMediaPopupContent;
            let mediaContent = new MediaContent();
            if (dnMediaContent.mediaInfos !== undefined && dnMediaContent.mediaInfos !== null &&
                dnMediaContent.mediaInfos.length > 0) {
                mediaContent.mediaInfos = dnMediaContent.mediaInfos.map(m => buildJsMediaInfo(m));
            }
            return mediaContent;
        case "attachments":
            let dnAttachmentsContent = popupContentObject as DotNetAttachmentsPopupContent;
            let attachmentsContent = new AttachmentsContent({
                description: dnAttachmentsContent.description ?? '',
                title: dnAttachmentsContent.title ?? '',
                displayType: dnAttachmentsContent.displayType as any ?? "auto",
            });
            return attachmentsContent;
        case "expression":
            let dnExpressionContent = popupContentObject as DotNetExpressionPopupContent;
            let expressionContent = new ExpressionContent();
            if (dnExpressionContent.expressionInfo !== undefined && dnExpressionContent.expressionInfo !== null) {
                expressionContent.expressionInfo = buildJsElementExpressionInfo(dnExpressionContent.expressionInfo);
            }
            return expressionContent;
    }
    return null;
}

export function buildJsFieldInfo(fieldInfoObject: DotNetFieldInfo): FieldInfo {
    let fieldInfo = new FieldInfo({
        fieldName: fieldInfoObject.fieldName ?? '',
        label: fieldInfoObject.label ?? '',
        tooltip: fieldInfoObject.tooltip ?? '',
        stringFieldOption: fieldInfoObject.stringFieldOption as any ?? "text-box",
        visible: fieldInfoObject.visible ?? true,
        isEditable: fieldInfoObject.isEditable ?? false
    });
    
    if (fieldInfoObject.format !== undefined && fieldInfoObject.format !== null) {
        fieldInfo.format = buildJsFieldInfoFormat(fieldInfoObject.format);
    }
    
    return fieldInfo;
}

export function buildJsFieldInfoFormat(formatObject: DotNetFieldInfoFormat): FieldInfoFormat {
    return new FieldInfoFormat({
        dateFormat: formatObject.dateFormat as any ?? undefined,
        places: formatObject.places ?? undefined,
        digitSeparator: formatObject.digitSeparator ?? undefined
    });
}

export function buildJsExpressionInfo(expressionInfoObject: DotNetExpressionInfo): popupExpressionInfo {
    return {
        name: expressionInfoObject.name ?? undefined,
        title: expressionInfoObject.title ?? undefined,
        expression: expressionInfoObject.expression ?? undefined,
        returnType: expressionInfoObject.returnType as any ?? undefined
    } as popupExpressionInfo;
}

export function buildJsSymbol(symbol: DotNetSymbol | null): Symbol | null {
    if (symbol === null || symbol === undefined) {
        return null;
    }
    switch (symbol.type) {
        case "simple-marker":
            let dnSimpleMarkerSymbol = symbol as DotNetSimpleMarkerSymbol;
            let jsSimpleMarkerSymbol = new SimpleMarkerSymbol({
                color: dnSimpleMarkerSymbol.color ?? [255, 255, 255, 0.25],
                path: dnSimpleMarkerSymbol.path ?? undefined,
                size: dnSimpleMarkerSymbol.size ?? 12,
                style: dnSimpleMarkerSymbol.style as any ?? "circle",
                xoffset: dnSimpleMarkerSymbol.xoffset ?? 0,
                yoffset: dnSimpleMarkerSymbol.yoffset ?? 0
            });
            
            if (dnSimpleMarkerSymbol.outline !== undefined && dnSimpleMarkerSymbol.outline !== null) {
                jsSimpleMarkerSymbol.outline = buildJsSymbol(dnSimpleMarkerSymbol.outline) as any;
            }
            return jsSimpleMarkerSymbol;
        case "simple-line":
            let dnSimpleLineSymbol = symbol as DotNetSimpleLineSymbol;
            let jsSimpleLineSymbol = new SimpleLineSymbol({
                color: dnSimpleLineSymbol.color ?? "black",
                cap: dnSimpleLineSymbol.cap as any ?? "round",
                join: dnSimpleLineSymbol.join as any ?? "round",
                marker: dnSimpleLineSymbol.marker as any ?? null,
                miterLimit: dnSimpleLineSymbol.miterLimit ?? 2,
                style: dnSimpleLineSymbol.style as any ?? "solid",
                width: dnSimpleLineSymbol.width ?? 0.75
            });
            
            return jsSimpleLineSymbol;
        case "picture-marker":
            let dnPictureMarkerSymbol = symbol as DotNetPictureMarkerSymbol;
            let jsPictureMarkerSymbol = new PictureMarkerSymbol({
                angle: dnPictureMarkerSymbol.angle ?? 0,
                xoffset: dnPictureMarkerSymbol.xoffset ?? 0,
                yoffset: dnPictureMarkerSymbol.yoffset ?? 0,
                height: dnPictureMarkerSymbol.height ?? 12,
                width: dnPictureMarkerSymbol.width ?? 12,
                url: dnPictureMarkerSymbol.url
            });
            
            return jsPictureMarkerSymbol;
            
        case "simple-fill":
            let dnSimpleFillSymbol = symbol as DotNetSimpleFillSymbol;
            let jsSimpleFillSymbol = new SimpleFillSymbol({
                color: dnSimpleFillSymbol.color ?? [0, 0, 0, 0.25],
                style: dnSimpleFillSymbol.style as any ?? "solid"
            });
            
            if (dnSimpleFillSymbol.outline !== undefined && dnSimpleFillSymbol.outline !== null) {
                jsSimpleFillSymbol.outline = buildJsSymbol(dnSimpleFillSymbol.outline) as any;
            }
            return jsSimpleFillSymbol;
        case "text":
            let dotNetTextSymbol = symbol as DotNetTextSymbol;
            let jsTextSymbol = new TextSymbol({
                color: dotNetTextSymbol.color ?? "black",
                haloColor: dotNetTextSymbol.haloColor ?? undefined,
                haloSize: dotNetTextSymbol.haloSize ?? undefined,
                text: dotNetTextSymbol.text ?? undefined
            });
            if (dotNetTextSymbol.font !== undefined && dotNetTextSymbol.font !== null) {
                jsTextSymbol.font = buildJsFont(dotNetTextSymbol.font);
            }

            return jsTextSymbol;
    }
    
    delete symbol["id"];
    return symbol as any;
}

export function buildJsGeometry(geometry: DotNetGeometry): Geometry | null {
    if (geometry === undefined || geometry?.type === undefined || geometry?.type === null) return null;
    switch (geometry.type) {
        case "point":
            return buildJsPoint(geometry as DotNetPoint);
        case "polyline":
            return buildJsPolyline(geometry as DotNetPolyline);
        case "polygon":
            return buildJsPolygon(geometry as DotNetPolygon);
        case "extent":
            return buildJsExtent(geometry as DotNetExtent, null);
    }

    return geometry as any;
}

export function buildJsPoint(dnPoint: DotNetPoint): Point | null {
    if (dnPoint === undefined || dnPoint === null) return null;
    let point = new Point({
        latitude: dnPoint.latitude ?? undefined,
        longitude: dnPoint.longitude ?? undefined,
        x: dnPoint.x ?? undefined,
        y: dnPoint.y ?? undefined
    });
    
    if (dnPoint.spatialReference !== undefined && dnPoint.spatialReference !== null) {
        point.spatialReference = buildJsSpatialReference(dnPoint.spatialReference);
    } else {
        point.spatialReference = new SpatialReference({wkid: 4326});
    }
    
    return point;
}

export function buildJsPolyline(dnPolyline: DotNetPolyline): Polyline | null {
    if (dnPolyline === undefined || dnPolyline === null) return null;
    let polyline = new Polyline({
        paths: dnPolyline.paths ?? undefined
    });
    if (dnPolyline.spatialReference !== undefined && dnPolyline.spatialReference !== null) {
        polyline.spatialReference = buildJsSpatialReference(dnPolyline.spatialReference);
    } else {
        polyline.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polyline;
}

export function buildJsPolygon(dnPolygon: DotNetPolygon): Polygon | null {
    if (dnPolygon === undefined || dnPolygon === null) return null;
    let polygon = new Polygon({
        rings: dnPolygon.rings ?? undefined
    });
    if (dnPolygon.spatialReference !== undefined && dnPolygon.spatialReference !== null) {
        polygon.spatialReference = buildJsSpatialReference(dnPolygon.spatialReference);
    } else {
        polygon.spatialReference = new SpatialReference({wkid: 4326});
    }
    return polygon;
}


export function buildJsRenderer(dotNetRenderer: any): Renderer | null {
    if (dotNetRenderer === undefined || dotNetRenderer?.symbol === undefined ||
        dotNetRenderer?.symbol === null) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let renderer = new SimpleRenderer();
            renderer.visualVariables = dotNetRenderer.visualVariables;
            renderer.symbol = buildJsSymbol(dotNetSymbol) as Symbol;
    }

    return dotNetRenderer
}


export function buildJsFields(dotNetFields: any): Array<Field> {
    let fields : Array<Field> = [];
    dotNetFields.forEach(dnField => {
        let field = new Field();
        for (const prop in dnField) {
            if (Object.prototype.hasOwnProperty.call(dnField, prop) && prop !== 'id') {
                field[prop] = dnField[prop];
            }
        }
        fields.push(field);
    });
    
    return fields;
}

export function buildJsViewClickEvent(dotNetClickEvent: any): ViewClickEvent {
    return {
        type: dotNetClickEvent.type,
        mapPoint: buildJsPoint(dotNetClickEvent.mapPoint) as Point,
        x: dotNetClickEvent.x,
        y: dotNetClickEvent.y,
        button: dotNetClickEvent.button ?? undefined,
        buttons: dotNetClickEvent.buttons ?? undefined,
        timestamp: dotNetClickEvent.timestamp ?? undefined
    } as ViewClickEvent
}

export async function buildJsPopup(dotNetPopup: any) : Promise<Popup> {
    let popup = new Popup({
        actions: dotNetPopup.actions ?? [],
        alignment: dotNetPopup.alignment ?? "auto",
        content: dotNetPopup.content ?? null,
        title: dotNetPopup.title ?? null,
        visible: dotNetPopup.visible ?? false,
        dockEnabled: dotNetPopup.dockEnabled ?? false,
        autoCloseEnabled: dotNetPopup.autoCloseEnabled ?? false,
        autoOpenEnabled: dotNetPopup.autoOpenEnabled ?? true,
        collapseEnabled: dotNetPopup.collapseEnabled ?? true,
        collapsed: dotNetPopup.collapsed ?? false,
        defaultPopupTemplateEnabled: dotNetPopup.defaultPopupTemplateEnabled ?? false,
        headingLevel: dotNetPopup.headingLevel ?? 2,
        highlightEnabled: dotNetPopup.highlightEnabled ?? true,
        label: dotNetPopup.label ?? '',
        spinnerEnabled: dotNetPopup.spinnerEnabled ?? true
    });
    
    if (dotNetPopup.location !== undefined && dotNetPopup.location !== null) {
        popup.location = buildJsPoint(dotNetPopup.location) as Point;
    }
    
    if (dotNetPopup.dockOptions !== undefined && dotNetPopup.dockOptions !== null) {
        popup.dockOptions = buildJsDockOptions(dotNetPopup.dockOptions);
    }
    
    if (dotNetPopup.features !== undefined && dotNetPopup.features !== null) {
        let features: Graphic[] = [];
        for (const f of dotNetPopup.features) {
            delete f.dotNetGraphicReference;
            let graphic = await buildJsGraphic(f, false) as Graphic;
            features.push(graphic);
        }
        popup.features = features;
    }
    
    if (dotNetPopup.visibleElements !== undefined && dotNetPopup.visibleElements !== null) {
        popup.visibleElements = dotNetPopup.visibleElements;
    }
    
    return popup;
}

function buildJsDockOptions(dotNetDockOptions: any) : PopupDockOptions {
    let dockOptions: PopupDockOptions = {
        buttonEnabled: dotNetDockOptions.buttonEnabled ?? undefined,
        position: dotNetDockOptions.position ?? undefined,
        breakpoint: dotNetDockOptions.breakPoint ?? true
    };
    
    return dockOptions as PopupDockOptions;
}

export async function buildJsPopupOptions(dotNetPopupOptions: any) : Promise<PopupOpenOptions> {
    let options: PopupOpenOptions = {};

    if (dotNetPopupOptions.title !== undefined && dotNetPopupOptions.title !== null) {
        options.title = dotNetPopupOptions.title;
    }
    if (dotNetPopupOptions.stringContent !== undefined && dotNetPopupOptions.stringContent !== null) {
        options.content = dotNetPopupOptions.content;
    }
    if (dotNetPopupOptions.fetchFeatures !== undefined && dotNetPopupOptions.fetchFeatures !== null) {
        options.fetchFeatures = dotNetPopupOptions.fetchFeatures;
    }
    
    if (dotNetPopupOptions.featureMenuOpen !== undefined && dotNetPopupOptions.featureMenuOpen !== null) {
        options.featureMenuOpen = dotNetPopupOptions.featureMenuOpen;
    }
    
    if (dotNetPopupOptions.updateLocationEnabled !== undefined && dotNetPopupOptions.updateLocationEnabled !== null) {
        options.updateLocationEnabled = dotNetPopupOptions.updateLocationEnabled;
    }
    
    if (dotNetPopupOptions.collapsed !== undefined && dotNetPopupOptions.collapsed !== null) {
        options.collapsed = dotNetPopupOptions.collapsed;
    }
    
    if (dotNetPopupOptions.shouldFocus !== undefined && dotNetPopupOptions.shouldFocus !== null) {
        options.shouldFocus = dotNetPopupOptions.shouldFocus;
    }
    
    if (dotNetPopupOptions.location !== undefined && dotNetPopupOptions.location !== null) {
        options.location = buildJsPoint(dotNetPopupOptions.location) as Point;
    }
    
    if (dotNetPopupOptions.features !== undefined && dotNetPopupOptions.features !== null) {
        let features: Graphic[] = [];
        for (const f of dotNetPopupOptions.features) {
            delete f.dotNetGraphicReference;
            features.push(await buildJsGraphic(f, false) as Graphic);
        }
        options.features = features;
    }
    
    return options;
}

function buildJsFont(dotNetFont: any) : Font {
    let font = new Font();
    font.size = dotNetFont.size ?? 9;
    font.family = dotNetFont.family ?? "sans-serif";
    font.style = dotNetFont.style ?? "normal";
    font.weight = dotNetFont.weight ?? "normal";
    
    return font;
}

export function buildJsQuery(dotNetQuery: DotNetQuery): Query {
    let query: any = new Query({
        where: dotNetQuery.where ?? undefined,
        spatialRelationship: dotNetQuery.spatialRelationship as any ?? "intersects",
        distance: dotNetQuery.distance ?? undefined,
        units: dotNetQuery.units as any ?? null,
        returnGeometry: dotNetQuery.returnGeometry ?? false,
        outFields: dotNetQuery.outFields ?? null,
        orderByFields: dotNetQuery.orderByFields ?? undefined,
        outStatistics: dotNetQuery.outStatistics ?? undefined,
        groupByFieldsForStatistics: dotNetQuery.groupByFieldsForStatistics ?? undefined,
        returnDistinctValues: dotNetQuery.returnDistinctValues ?? false,
        returnZ: dotNetQuery.returnZ ?? undefined,
        returnExceededLimitFeatures: dotNetQuery.returnExceededLimitFeatures ?? true,
        num: dotNetQuery.num ?? undefined,
        objectIds: dotNetQuery.objectIds ?? undefined,
        timeExtent: dotNetQuery.timeExtent ?? undefined,
        maxAllowableOffset: dotNetQuery.maxAllowableOffset ?? undefined,
        geometryPrecision: dotNetQuery.geometryPrecision ?? undefined,
        aggregateIds: dotNetQuery.aggregateIds ?? undefined,
        cacheHint: dotNetQuery.cacheHint ?? undefined,
        datumTransformation: dotNetQuery.datumTransformation ?? undefined,
        gdbVersion: dotNetQuery.gdbVersion ?? undefined,
        having: dotNetQuery.having ?? undefined,
        historicMoment: dotNetQuery.historicMoment ?? undefined,
        maxRecordCountFactor: dotNetQuery.maxRecordCountFactor ?? 1,
        text: dotNetQuery.text ?? null,
        parameterValues: dotNetQuery.parameterValues ?? undefined,
        quantizationParameters: dotNetQuery.quantizationParameters ?? undefined,
        rangeValues: dotNetQuery.rangeValues ?? undefined,
        relationParameter: dotNetQuery.relationParameter ?? undefined,
        returnCentroid: dotNetQuery.returnCentroid ?? false,
        returnM: dotNetQuery.returnM ?? undefined,
        returnQueryGeometry: dotNetQuery.returnQueryGeometry ?? false,
        sqlFormat: dotNetQuery.sqlFormat as any ?? "none",
        start: dotNetQuery.start ?? undefined
    });
    
    if (dotNetQuery.geometry !== undefined && dotNetQuery.geometry !== null) {
        query.geometry = buildJsGeometry(dotNetQuery.geometry) as Geometry;
    }
    
    if (dotNetQuery.outSpatialReference !== undefined && dotNetQuery.outSpatialReference !== null) {
        query.outSpatialReference = buildJsSpatialReference(dotNetQuery.outSpatialReference);
    }
    
    return query as Query;
}

export function buildJsRelationshipQuery(dotNetRelationshipQuery: DotNetRelationshipQuery): RelationshipQuery
{
    // copy all values from the dotnet object to the js object
    let relationshipQuery = new RelationshipQuery({
        cacheHint: dotNetRelationshipQuery.cacheHint ?? undefined,
        gdbVersion: dotNetRelationshipQuery.gdbVersion ?? undefined,
        geometryPrecision: dotNetRelationshipQuery.geometryPrecision ?? undefined,
        historicMoment: dotNetRelationshipQuery.historicMoment ?? undefined,
        maxAllowableOffset: dotNetRelationshipQuery.maxAllowableOffset ?? undefined,
        num: dotNetRelationshipQuery.num ?? undefined,
        objectIds: dotNetRelationshipQuery.objectIds ?? undefined,
        orderByFields: dotNetRelationshipQuery.orderByFields ?? undefined,
        outFields: dotNetRelationshipQuery.outFields ?? undefined,
        returnGeometry: dotNetRelationshipQuery.returnGeometry ?? undefined,
        returnM: dotNetRelationshipQuery.returnM ?? undefined,
        returnZ: dotNetRelationshipQuery.returnZ ?? undefined,
        start: dotNetRelationshipQuery.start ?? undefined,
        where: dotNetRelationshipQuery.where ?? undefined
    });
    
    if (dotNetRelationshipQuery.outSpatialReference !== undefined && dotNetRelationshipQuery.outSpatialReference !== null) {
        relationshipQuery.outSpatialReference = buildJsSpatialReference(dotNetRelationshipQuery.outSpatialReference);
    }
    
    return relationshipQuery as RelationshipQuery;
}

export function buildJsTopFeaturesQuery(dnQuery: DotNetTopFeaturesQuery): TopFeaturesQuery {
    let query = new TopFeaturesQuery({
        cacheHint: dnQuery.cacheHint ?? undefined,
        distance: dnQuery.distance ?? undefined,
        geometryPrecision: dnQuery.geometryPrecision ?? undefined,
        maxAllowableOffset: dnQuery.maxAllowableOffset ?? undefined,
        num: dnQuery.num ?? undefined,
        objectIds: dnQuery.objectIds ?? undefined,
        orderByFields: dnQuery.orderByFields ?? undefined,
        outFields: dnQuery.outFields ?? null,
        returnGeometry: dnQuery.returnGeometry ?? false,
        returnM: dnQuery.returnM ?? undefined,
        returnZ: dnQuery.returnZ ?? undefined,
        spatialRelationship: dnQuery.spatialRelationship as any ?? "intersects",
        start: dnQuery.start ?? undefined,
        timeExtent: dnQuery.timeExtent ?? undefined,
        topFilter: dnQuery.topFilter as any ?? undefined,
        units: dnQuery.units as any ?? null
    });
    
    if (dnQuery.where !== undefined && dnQuery.where !== null) {
        query.where = dnQuery.where;
    }
    
    if (dnQuery.geometry !== undefined && dnQuery.geometry !== null) {
        query.geometry = buildJsGeometry(dnQuery.geometry) as Geometry;
    }

    if (dnQuery.outSpatialReference !== undefined && dnQuery.outSpatialReference !== null) {
        query.outSpatialReference = buildJsSpatialReference(dnQuery.outSpatialReference);
    }
    
    return query as TopFeaturesQuery;
}

export function buildJsMediaInfo(dotNetMediaInfo: DotNetMediaInfo): any {
    switch (dotNetMediaInfo?.type){
        case "bar-chart":
            let dotNetBarChartMediaInfo = dotNetMediaInfo as DotNetBarChartMediaInfo;
            return {
                type: "bar-chart",
                altText: dotNetBarChartMediaInfo.altText ?? undefined,
                caption: dotNetBarChartMediaInfo.caption ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetBarChartMediaInfo.value)
            } as BarChartMediaInfo;
        case "column-chart":
            let dotNetColumnChartMediaInfo = dotNetMediaInfo as DotNetColumnChartMediaInfo;
            return {
                type: "column-chart",
                altText: dotNetColumnChartMediaInfo.altText ?? undefined,
                caption: dotNetColumnChartMediaInfo.caption ?? undefined,
                title: dotNetColumnChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetColumnChartMediaInfo.value)
            } as ColumnChartMediaInfo;
        case "image":
            let dotNetImageMediaInfo = dotNetMediaInfo as DotNetImageMediaInfo;
            return {
                type: "image",
                altText: dotNetImageMediaInfo.altText ?? undefined,
                caption: dotNetImageMediaInfo.caption ?? undefined,
                title: dotNetImageMediaInfo.title ?? undefined,
                refreshInterval: dotNetImageMediaInfo.refreshInterval ?? undefined,
                value: buildJsImageMediaInfoValue(dotNetImageMediaInfo.value)
            } as ImageMediaInfo;
        case "line-chart":
            let dotNetLineChartMediaInfo = dotNetMediaInfo as DotNetLineChartMediaInfo;
            return {
                type: "line-chart",
                altText: dotNetLineChartMediaInfo.altText ?? undefined,
                caption: dotNetLineChartMediaInfo.caption ?? undefined,
                title: dotNetLineChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetLineChartMediaInfo.value)
            } as LineChartMediaInfo;
        case "pie-chart":
            let dotNetPieChartMediaInfo = dotNetMediaInfo as DotNetPieChartMediaInfo;
            return {
                type: "pie-chart",
                altText: dotNetPieChartMediaInfo.altText ?? undefined,
                caption: dotNetPieChartMediaInfo.caption ?? undefined,
                title: dotNetPieChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetPieChartMediaInfo.value)
            } as PieChartMediaInfo;
    }
}

export function buildJsChartMediaInfoValue(dotNetChartMediaInfoValue: DotNetChartMediaInfoValue): ChartMediaInfoValue {
    let value = new ChartMediaInfoValue({
        fields: dotNetChartMediaInfoValue?.fields ?? undefined,
        normalizeField: dotNetChartMediaInfoValue?.normalizeField ?? undefined,
        tooltipField: dotNetChartMediaInfoValue?.tooltipField ?? undefined
    });
    
    if (dotNetChartMediaInfoValue?.series !== undefined && dotNetChartMediaInfoValue?.series !== null) {
        value.series = dotNetChartMediaInfoValue.series.map(s => {
            let series = new ChartMediaInfoValueSeries({
                tooltip: s.tooltip ?? undefined,
                value: s.value ?? undefined,
                fieldName: s.fieldName ?? undefined
            });
            return series;
        });
    }
    return value;
}

export function buildJsImageMediaInfoValue(dotNetImageMediaInfoValue: DotNetImageMediaInfoValue): ImageMediaInfoValue {
    return {
        sourceURL: dotNetImageMediaInfoValue.sourceURL ?? undefined,
        linkURL: dotNetImageMediaInfoValue.linkURL ?? undefined
    } as ImageMediaInfoValue;
}

export function buildJsElementExpressionInfo(dotNetExpressionInfo: DotNetElementExpressionInfo): ElementExpressionInfo {
    let info = new ElementExpressionInfo({
        expression: dotNetExpressionInfo.expression ?? undefined,
        returnType: dotNetExpressionInfo.returnType as any ?? undefined,
        title: dotNetExpressionInfo.title ?? undefined
    });
    
    return info;
}